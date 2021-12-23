using Microsoft.EntityFrameworkCore;
using System;

namespace RobertsDbContextExtensionsTests.Models
{
    public class TestDbContext : DbContext
    {
        public TestDbContext(DbContextOptions<TestDbContext> options) : base(options)
        {
        }

        public DbSet<TableOne> TableOne { get; set; }
        public DbSet<TableTwo> TableTwo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TableOne>().HasData(
                new TableOne
                {
                    OneId = 1,
                    byte1 = 1,
                    sbyte1 = 2,
                    short1 = 3,
                    ushort1 = 4,
                    int1 = 5,
                    uint1 = 6,
                    long1 = 7,
                    ulong1 = 8,
                    float1 = 9,
                    double1 = 10.10,
                    decimal1 = 11.11m,
                    bool1 = true,
                    string1 = "13",
                    char1 = 'n',
                    guid1 = Guid.Parse("790523b2-e6b6-4f56-a06e-3f6abd7ffafd"),
                    datetime1 = new DateTime(2021, 12, 1, 7, 30, 0, DateTimeKind.Local),
                    datetimeoffset1 = new DateTime(2021, 12, 2, 9, 30, 0, DateTimeKind.Local),
                    bytearray1 = new byte[] { 1, 2, 3, 4 },
                    //dateonly1 = new DateOnly(2021, 12, 1),
                    //timeonly1 = new TimeOnly(11, 30, 12, 100)
                }); ;


            modelBuilder.Entity<TableTwo>().HasData(
                new TableTwo
                {
                    TwoId = 1,
                    OneId = 1,
                    FieldOne = "one one one"
                });
        }
    }
}
