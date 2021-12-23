using RobertsDbContextExtensions;
using RobertsDbContextExtensionsTests.Fixtures;
using RobertsDbContextExtensionsTests.Models;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace RobertsDbContextExtensionsTests
{
    /// <summary>
    /// ExecuteDynamicList<> is a complicated bit of gear. Roughly speaking
    /// it is the equivelant of EFCore's "shadow properties". If you're 
    /// building a system where the specific fields to be queried are 
    /// determined at runtime then ExecuteDynamicList<> is for you. It 
    /// allows the "extra" fields to be dropped into an object array. Then
    /// the remainder of your code is responsible for knowing the mapping
    /// of which fields correspond to which array entry.
    /// </summary>
    public class DynamicListTests : IClassFixture<TestDbContextFixture>
    {
        TestDbContext ctx;

        public DynamicListTests(TestDbContextFixture testDbContextFixture)
        {
            this.ctx = testDbContextFixture.CreateDbContext();
        }

        class TableOneProjection
        {
            public int OneId { get; set; }
            public object[] Fields { get; set; }
        }
        class TableTwoProjection
        {
            public int TwoId { get; set; }
            public int OneId { get; set; }
            public string FieldOne { get; set; }
        }

        /// <summary>
        /// This test shows that ExecuteDynamicList<> correctly populates
        /// the object[] with the correct values
        /// </summary>
        [Fact]
        public void SingleTable()
        {
            var Results =
                ctx.ExecuteDynamicList<TableOneProjection>(
                    "select OneId, byte1, int1 from TableOne",
                    new[]
                    {
                        "byte1",
                        "int1"
                    });
            Assert.Equal(1, Results.Count);

            Assert.Equal(1, Results[0].OneId);

            Assert.Equal(typeof(byte), Results[0].Fields[0].GetType());
            Assert.Equal((byte)1, Results[0].Fields[0]);

            Assert.Equal(typeof(int), Results[0].Fields[1].GetType());
            Assert.Equal(5, Results[0].Fields[1]);
        }

        /// <summary>
        /// Multiple table dynamic lists are for when you want to combine
        /// a single dynamic list query with one or more regular queries.
        /// This test shows that the additional table is returned correctly.
        /// </summary>
        [Fact]
        public void MultiTable()
        {
            var Results =
                ctx.ExecuteDynamicList(
                    new[] { typeof(TableOneProjection), typeof(TableTwoProjection)},
                    "select OneId, byte1, int1 from TableOne; select * from TableTwo",
                    new[]
                    {
                        "byte1",
                        "int1"
                    });

            Assert.Equal(2, Results.Count);

            Assert.NotNull(Results[0] as IList<TableOneProjection>);
            Assert.NotNull(Results[1] as IList<TableTwoProjection>);

            var ListOfOnes = (Results[0] as IList<TableOneProjection>);
            Assert.Equal(1, ListOfOnes.First().OneId);

            Assert.Equal(typeof(byte), ListOfOnes.First().Fields[0].GetType());
            Assert.Equal((byte)1, ListOfOnes.First().Fields[0]);

            Assert.Equal(typeof(int), ListOfOnes.First().Fields[1].GetType());
            Assert.Equal(5, ListOfOnes.First().Fields[1]);
        }

    }
}
