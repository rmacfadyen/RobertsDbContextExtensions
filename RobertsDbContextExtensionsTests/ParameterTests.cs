using RobertsDbContextExtensions;
using RobertsDbContextExtensionsTests.Fixtures;
using RobertsDbContextExtensionsTests.Models;
using System.Collections.Generic;
using Xunit;


namespace RobertsDbContextExtensionsTests
{
    /// <summary>
    /// These tests show that specifying parameters are actually passed
    /// to the database correctly (verified by round trip). 
    /// 
    /// It's important to be aware you can pass positional paramaters
    /// that get names p0, p1, .. pN:
    ///     ctx.ExecuteScalar<int>(Sql, 1, "b", 99); // p0, p1, p3
    ///     
    /// You can also pass named parameters using anonymous classes:
    ///     ctx.ExecuteScalar<int>(Sql, new {
    ///         FirstParm = 1,
    ///         Second = "b",
    ///         Last = 99
    ///     });
    /// 
    /// You can also pass named parameters via a dictionary of either
    /// objects or strings:
    ///     var d = new Dictionary<string, object>() = {
    ///         { "FirstParm", 1 },
    ///         { "Second", "b" },
    ///         { "Last", 99 }
    ///     };
    ///     ctx.ExecuteScalar<int>(Sql, d);
    ///     
    /// Lastly you should be aware that passing a NULL value parameter the
    /// type of the parameter is always passed as STRING.
    /// </summary>
    public class ParameterTests : IClassFixture<TestDbContextFixture>
    {
        TestDbContext ctx;

        public ParameterTests(TestDbContextFixture testDbContextFixture)
        {
            this.ctx = testDbContextFixture.CreateDbContext();
        }

        /// <summary>
        /// Under the hood string parameters are a bit tricky. A string is
        /// an object (not a primitive type) but need to be treated as a
        /// primative.
        /// </summary>
        [Fact]
        public void UnnameParameters()
        {
            var Sql = "select @p0 ";

            var i = ctx.ExecuteScalar<int>(Sql, 1701);
            Assert.Equal(1701, i);

            var s = ctx.ExecuteScalar<string>(Sql, "123");
            Assert.Equal("123", s);

            var s2 = ctx.ExecuteScalar<string>(Sql, new Dictionary<string, string> { { "p0", "123" } });
            Assert.Equal("123", s2);

            var i2 = ctx.ExecuteScalar<int>(Sql, new Dictionary<string, object> { { "p0", 1701 } });
            Assert.Equal(1701, i2);
        }

        /// <summary>
        /// Nulls are tricky beasts and this test is doubly tricky. Firstly
        /// we're passing in a NULL value for a parameter... which means
        /// the parameter is declared as a string with a null value. Secondly
        /// the ExecuteScalar is returning a nullable int, which is the passed
        /// parameter.
        /// </summary>
        [Fact]
        public void NullValueParameter()
        {
            var Sql = "select @p0 ";

            var i3 = ctx.ExecuteScalar<int?>(Sql, new Dictionary<string, object> { { "p0", null } });
            Assert.Null(i3);
        }

        enum Currency
        {
            CAD,
            USD
        }

        class PropMap
        {
            public Currency MoneyType { get; set; }
        }

        /// <summary>
        /// Test of an enum as an object property as a parameter. Must not be nullable on the return side.
        /// </summary>
        [Fact]
        public void PropertyParameter()
        {
            var Sql = "select @MoneyType ";

            var i3 = ctx.ExecuteScalar<Currency>(Sql, new PropMap {  MoneyType = Currency.USD });
            Assert.Equal(Currency.USD, i3);
        }


        class PropMapTwo
        {
            public string MoneyType { get; set; }
        }

        /// <summary>
        /// Test of an enum as an object property as a parameter. Must not be nullable on the return side.
        /// </summary>
        [Fact]
        public void PropertyParameterNullString()
        {
            var Sql = "select @MoneyType ";

            var i3 = ctx.ExecuteScalar<string>(Sql, new PropMapTwo { MoneyType = null });
            Assert.Null(i3);
        }
    }
}
