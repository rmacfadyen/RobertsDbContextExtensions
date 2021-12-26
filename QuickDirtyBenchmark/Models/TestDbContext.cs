using Microsoft.EntityFrameworkCore;
using System;

namespace QuickDirtyBenchmark.Models
{
    public class TestDbContext : DbContext
    {
        public TestDbContext(DbContextOptions<TestDbContext> options) : base(options)
        {
        }

        public DbSet<TableOne> TableOne { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TableOne>().HasData(
                new[] {
                    CreateRandomRow(1), CreateRandomRow(2), CreateRandomRow(3), CreateRandomRow(4), CreateRandomRow(5),
                    CreateRandomRow(6), CreateRandomRow(7), CreateRandomRow(8), CreateRandomRow(9), CreateRandomRow(10),
                    CreateRandomRow(11), CreateRandomRow(12), CreateRandomRow(13), CreateRandomRow(14), CreateRandomRow(15),
                    CreateRandomRow(16), CreateRandomRow(17), CreateRandomRow(18), CreateRandomRow(19), CreateRandomRow(20),
                    CreateRandomRow(21), CreateRandomRow(22), CreateRandomRow(23), CreateRandomRow(24), CreateRandomRow(25)
                }
            );
        }

        private static Random rnd = new Random();
        private static TableOne CreateRandomRow(int Id)
        {
            return new TableOne
            {
                OneId = Id,
                byte1 = (byte)rnd.Next(byte.MinValue, byte.MaxValue),
                sbyte1 = (sbyte)rnd.Next(sbyte.MinValue, sbyte.MaxValue),
                short1 = (short)rnd.Next(short.MinValue, short.MaxValue),
                ushort1 = (short)rnd.Next(ushort.MinValue, ushort.MaxValue),
                int1 = rnd.Next(int.MinValue, int.MaxValue),
                uint1 = (int)rnd.Next(int.MinValue, int.MaxValue),
                long1 = rnd.Next(int.MinValue, int.MaxValue),
                ulong1 = (ulong)rnd.Next(int.MinValue, int.MaxValue),
                float1 = (float)rnd.NextSingle(),
                double1 = rnd.NextDouble(),
                decimal1 = rnd.Next(int.MinValue, int.MaxValue),
                bool1 = rnd.Next(10) > 5,
                string1 = RandomString(rnd.Next(10, 127)),
                char1 = Convert.ToChar(rnd.Next(32, 127)),
                guid1 = Guid.NewGuid(),
                datetime1 = new DateTime(2021, 12, 1, 7, 30, 0, DateTimeKind.Local).AddDays(rnd.Next(sbyte.MinValue, sbyte.MaxValue)),
                datetimeoffset1 = new DateTime(2021, 12, 2, 9, 30, 0, DateTimeKind.Local).AddDays(rnd.Next(sbyte.MinValue, sbyte.MaxValue)),
            };
        }

        private static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[rnd.Next(s.Length)]).ToArray());
        }
    }
}
