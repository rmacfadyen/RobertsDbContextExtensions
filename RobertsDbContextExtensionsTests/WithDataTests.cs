using RobertsDbContextExtensions;
using RobertsDbContextExtensionsTests.Fixtures;
using RobertsDbContextExtensionsTests.Models;
using System;
using Xunit;

namespace RobertsDbContextExtensionsTests
{
    public class WithDataTests : IClassFixture<TestDbContextFixture>
    {
        TestDbContext ctx;

        public WithDataTests(TestDbContextFixture ctxFixture)
        {
            this.ctx = ctxFixture.CreateDbContext();
        }

        class SimpleProjection
        {
            public int OneId { get; set; }

            public byte byte1 { get; set; }
            public sbyte sbyte1 { get; set; }
            public short short1 { get; set; }
            public ushort ushort1 { get; set; }
            public int int1 { get; set; }
            public uint uint1 { get; set; }
            public long long1 { get; set; }
            public ulong ulong1 { get; set; }
            public float float1 { get; set; }
            public double double1 { get; set; }
            public decimal decimal1 { get; set; }
            public bool bool1 { get; set; }
            public string string1 { get; set; }
            public char char1 { get; set; }
            //public Guid guid1 { get; set; }
            public DateTime datetime1 { get; set; }
            //public DateTimeOffset datetimeoffset1 { get; set; }
            public byte[] bytearray1 { get; set; }
            //public DateOnly dateonly1 { get; set; }
            //public TimeOnly timeonly1 { get; set; }
        }

        [Fact]
        public void EmptyResultSetPrimitiveCount()
        {
            var l = ctx.ExecuteList<int>("select OneId from TableOne where OneId = 1");
            Assert.Equal(1, l.Count);
        }

        [Fact]
        public void EmptyResultSetObjectCount()
        {
            var l = ctx.ExecuteList<SimpleProjection>("select * from TableOne where OneId = 1");
            Assert.Equal(1, l.Count);
        }

        [Fact]
        public void EmptyResultSetPrimitiveValue()
        {
            var l = ctx.ExecuteScalar<int>("select OneId from TableOne where OneId = 1");
            Assert.Equal(1, l);
        }

        [Fact]
        public void EmptyResultSetNullablePrimitiveValue()
        {
            var l = ctx.ExecuteScalar<int?>("select OneId from TableOne where OneId = 1");
            Assert.True(l.HasValue);
            Assert.Equal(1, l.Value);
        }

        [Fact]
        public void EmptyResultSetObjectValue()
        {
            var l = ctx.ExecuteScalar<SimpleProjection>("select * from TableOne where OneId = 1");

            Assert.NotNull(l);
            Assert.Equal(1, l.byte1);
            Assert.Equal(2, l.sbyte1);
            Assert.Equal(3, l.short1);
            Assert.Equal(4, l.ushort1);
            Assert.Equal(5, l.int1);
            Assert.Equal("6", l.uint1.ToString());
            Assert.Equal(7, l.long1);
            Assert.Equal("8", l.ulong1.ToString());
            Assert.Equal(9, l.float1);
            Assert.Equal(10.10, l.double1);
            Assert.Equal(11.11m, l.decimal1);
            Assert.True(l.bool1);
            Assert.Equal("13", l.string1);
            Assert.Equal('n', l.char1);
            //Assert.Equal(Guid.Parse("790523b2-e6b6-4f56-a06e-3f6abd7ffafd"), l.guid1);
            Assert.Equal(new DateTime(2021, 12, 1, 7, 30, 0, DateTimeKind.Local), l.datetime1);
            //Assert.Equal(new DateTime(2021, 12, 2, 9, 30, 0, DateTimeKind.Local), l.datetimeoffset1);
            Assert.Equal(new byte[] { 1, 2, 3, 4 }, l.bytearray1);
            //Assert.Equal(new DateOnly(2021, 12, 1), l.dateonly1);
            //Assert.Equal(new TimeOnly(11, 30, 12, 100), l.timeonly1);
        }

        // enum
        // invalid cast for reading a record (field in db is string but in projection is int)
        // nulls in the db
        // nulls in dynamic list fields
        // projection with a readonly property trying to be populated from the db
        // projection with no matching columns
        // dynamic list no object[] property
        // dynamic column not present in query

    }
}
