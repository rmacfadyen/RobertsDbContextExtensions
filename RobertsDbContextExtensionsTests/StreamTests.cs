using RobertsDbContextExtensions;
using RobertsDbContextExtensionsTests.Fixtures;
using RobertsDbContextExtensionsTests.Models;
using System;
using System.IO;
using Xunit;

namespace RobertsDbContextExtensionsTests
{
    /// <summary>
    /// These tests excercise the read a stream from the database functionality
    /// </summary>
    public class StreamTests : IClassFixture<TestDbContextFixture>
    {
        TestDbContext ctx;

        public StreamTests(TestDbContextFixture testDbContextFixture)
        {
            this.ctx = testDbContextFixture.CreateDbContext();
        }

        /// <summary>
        /// Test that stream a blob of binary data from the database works
        /// </summary>
        [Fact]
        public void StreamTest()
        {
            using var s = ctx.ExecuteScalarStream("select bytearray1 from TableOne where OneId = 1");
            var ms = new MemoryStream();
            s.CopyTo(ms);
            var b = ms.ToArray();
            Assert.Equal(new byte[] { 1, 2, 3, 4 }, b);
        }


        /// <summary>
        /// Make sure the unsupported methods are always unsupported
        /// </summary>
        [Fact]
        public void StreamTestUnsupported()
        {
            using var s = ctx.ExecuteScalarStream("select bytearray1 from TableOne where OneId = 1");

            Assert.False(s.CanWrite);

            Assert.Throws<NotSupportedException>(() => s.Seek(1, SeekOrigin.End));
            Assert.Throws<NotSupportedException>(() => s.SetLength(1L));
            Assert.Throws<NotSupportedException>(() => s.Write(new byte[] { 1, 2 }, 0, 2));
            Assert.Throws<NotSupportedException>(() => s.Length);
            Assert.Throws<NotSupportedException>(() => s.Position);
            Assert.Throws<NotSupportedException>(() => s.Position = 2);
            Assert.Throws<NotSupportedException>(() => s.Flush());
        }
    }
}
