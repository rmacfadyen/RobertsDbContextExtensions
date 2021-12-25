using RobertsDbContextExtensions;
using RobertsDbContextExtensionsTests.Fixtures;
using RobertsDbContextExtensionsTests.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace RobertsDbContextExtensionsTests
{
    /// <summary>
    /// These tests started life as code coverage completion for the
    /// data converter class. 
    /// </summary>
    public class DataRecordConverterTests : IClassFixture<TestDbContextFixture>
    {
        TestDbContext ctx;

        public DataRecordConverterTests(TestDbContextFixture testDbContextFixture)
        {
            this.ctx = testDbContextFixture.CreateDbContext();
        }

        class SimpleProjection
        {
            public int FieldOne { get; set; }
        }

        /// <summary>
        /// This test shows that bad conversions between the result set
        /// and the destination property result in an invalid cast exception
        /// </summary>
        [Fact]
        public void InvalidCast()
        {
            Assert.Throws<System.InvalidCastException>(() =>
            {
                var t = ctx.ExecuteList<SimpleProjection>("select getdate() as FieldOne");
            });
        }

        /// <summary>
        /// This test shows that a NULL value in a result set can not
        /// be written into a non-nullable destination property
        /// </summary>
        [Fact]
        public void NullIntoNonNullable()
        {
            Assert.Throws<System.NullReferenceException>(() =>
            {
                var t = ctx.ExecuteList<SimpleProjection>("select null as FieldOne");
            });
        }


        /// <summary>
        /// Conversion errors will show the type names so this test shows
        /// that types names will be correctly displayed (instead of the mangled
        /// names you can see with generics).
        /// </summary>
        [Fact]
        public void DisplayNameTests()
        {
            Assert.Equal("Int32?", FastRecordConverter.GetDisplayName(typeof(int?)));
            Assert.Equal("List<Int32>", FastRecordConverter.GetDisplayName(typeof(List<int>)));
            Assert.Equal("Int32[]", FastRecordConverter.GetDisplayName(typeof(int[])));
            Assert.Equal("Int32[][]", FastRecordConverter.GetDisplayName(typeof(int[][])));
            Assert.Equal("Int32[,]", FastRecordConverter.GetDisplayName(typeof(int[,])));
            Assert.Equal("Array[]", FastRecordConverter.GetDisplayName(typeof(Array[])));
        }


        class SimpleProjectionPrivateSetter
        {
            public int FieldOne { get; private set; }
        }

        /// <summary>
        /// This test shows that if a destination property has a private
        /// setter it will still be initialized from the result set
        /// </summary>
        [Fact]
        public void PrivateSetter()
        {
            var t = ctx.ExecuteList<SimpleProjectionPrivateSetter>("select 1 as FieldOne");
            Assert.NotNull(t);
            Assert.NotEmpty(t);
            Assert.Equal(1, t.First().FieldOne);
        }

        class SimpleProjectionNoMatches
        {
            public int FieldOneTwo { get; }
        }

        /// <summary>
        /// This test shows that if there are no matches between the result
        /// set and the destination an exception is raised
        /// </summary>
        [Fact]
        public void NoMatches()
        {
            Assert.Throws<ArgumentException>(() => {
                var t = ctx.ExecuteList<SimpleProjectionNoMatches>("select 1 as FieldOne");
            });
        }

        class SimpleProjectionNoSetter
        {
            public int FieldOne { get; }
            public int FieldTwo { get; set; }
        }

        /// <summary>
        /// This test shows that a destination class without a setter ignores the property
        /// </summary>
        [Fact]
        public void NoSetterIgnored()
        {
            var t = ctx.ExecuteList<SimpleProjectionNoSetter>("select 1 as FieldOne, 2 as FieldTwo");
            Assert.NotNull(t);
            Assert.NotEmpty(t);
            Assert.Equal(default, t.First().FieldOne);
            Assert.Equal(2, t.First().FieldTwo);
        }


        class SimpleProjectionDynamicNoArray
        {
            public int FieldOne { get; set; }
            public int FieldTwo { get; set; }
        }

        /// <summary>
        /// This test shows that the destination class for a dynamic list must 
        /// include one "object[]" property to receive the loaded values
        /// </summary>
        [Fact]
        public void DynamicNoArray()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                var t = ctx.ExecuteDynamicList<SimpleProjectionDynamicNoArray>("select 1 as FieldOne, 2 as FieldTwo", new[] { "FieldThree" });
            });
        }

        class SimpleProjectionDynamic
        {
            public int FieldOne { get; set; }
            public int FieldTwo { get; set; }
            public object[] Fields { get; set; }
        }

        /// <summary>
        /// This test shows that if dynamic fields are specified they must exist in the result set
        /// </summary>
        [Fact]
        public void DynamicNoFieldsMatch()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                var t = ctx.ExecuteDynamicList<SimpleProjectionDynamic>("select 1 as FieldOne, 2 as FieldTwo", new[] { "FieldThree" });
            });
        }


        /// <summary>
        /// This tests shows that NULL values from dynamic fields are loaded into the object[]
        /// </summary>
        [Fact]
        public void DynamicNullValue()
        {
            var t = ctx.ExecuteDynamicList<SimpleProjectionDynamic>("select 1 as FieldOne, 2 as FieldTwo, null as FieldThree", new[] { "FieldThree" });
            Assert.NotNull(t);
            Assert.NotEmpty(t);
            Assert.Equal(1, t.First().FieldOne);
            Assert.Equal(2, t.First().FieldTwo);
            Assert.NotNull(t.First().Fields);
            Assert.Single(t.First().Fields);
            Assert.Null(t.First().Fields.First());
        }
    }
}
