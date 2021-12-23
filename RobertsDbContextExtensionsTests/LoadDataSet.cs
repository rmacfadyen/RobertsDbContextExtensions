using RobertsDbContextExtensions;
using RobertsDbContextExtensionsTests.Fixtures;
using RobertsDbContextExtensionsTests.Models;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace RobertsDbContextExtensionsTests
{
    public class LoadDataSet : IClassFixture<TestDbContextFixture>
    {
        TestDbContext ctx;

        public LoadDataSet(TestDbContextFixture testDbContextFixture)
        {
            this.ctx = testDbContextFixture.CreateDbContext();
        }

        class TableOneProjection
        {
            public int Id { get; set; }
            public IList<TableTwoProjection> Twos { get; set; }
        }

        class TableTwoProjection
        {
            public int Id { get; set; }
            public int TableOneId { get; set; }
            public string FieldOne { get; set; }
        }

        class TableOneProjectionJustIds
        {
            public int Id { get; set; }
            public IList<int> Twos { get; set; }
        }
        class TableTwoProjectionJustId
        {
            public int OneId { get; set; }
        }



        [Fact]
        public void LoadSimpleDataset()
        {
            var sql = "select * from TableOne; select * from TableTwo";
            var cmd = ctx.CreateCommand(sql);
            var ds = ctx.LoadDataset<TableOneProjection, TableTwoProjection>(
                cmd,
                "OneId",
                (t1, children) => { t1.Twos = children; },
                "OneId"
            );

            Assert.NotNull(ds);
            Assert.Single(ds);
            Assert.NotEmpty(ds[0].Twos);
        }
        
        [Fact]
        public void LoadSimpleDatasetNoChildRows()
        {
            var sql = "select * from TableOne; select * from TableTwo where 1 = 0";
            var cmd = ctx.CreateCommand(sql);
            var ds = ctx.LoadDataset<TableOneProjection, TableTwoProjection>(
                cmd,
                "OneId",
                (t1, children) => { t1.Twos = children; },
                "OneId"
            );

            Assert.NotNull(ds);
            Assert.Single(ds);
            Assert.Empty(ds[0].Twos);
        }

        /// <summary>
        /// This is a silly test and only exists for code coverage OCD
        /// </summary>
        [Fact]
        public void LoadDatasetChildRowsAreInts()
        {
            var sql = "select * from TableOne; select OneId from TableTwo";
            var cmd = ctx.CreateCommand(sql);
            var ds = ctx.LoadDataset<TableOneProjectionJustIds, int>(
                cmd,
                "OneId",
                (t1, children) => { t1.Twos = children; },
                "OneId"
            );

            Assert.NotNull(ds);
            Assert.Single(ds);
            Assert.NotEmpty(ds[0].Twos);
        }


        [Fact]
        public void LoadClassicDataset()
        {
            var sql = "select * from TableOne; select * from TableTwo";
            var cmd = ctx.CreateCommand(sql);
            var ds = ctx.LoadDataset(cmd);

            Assert.NotNull(ds);
            Assert.Equal(2, ds.Tables.Count);
        }



        enum Currency
        {
            CAD = 0,
            USD = 1
        }

        class ParentTable
        {
            public int OneId { get; set; }
            public IList<ChildTable> Children { get; set; }
        }

        class ChildTable
        {
            public int OneId { get; set; }
            public Currency ChargedIn { get; set; }
        }

   

        [Fact]
        public void LoadDatasetWithEnum()
        {
            var sql = "select 1 as OneId; select 1 as OneId, 'USD' as ChargedIn";
            var cmd = ctx.CreateCommand(sql);
            var ds = ctx.LoadDataset<ParentTable, ChildTable>(
                cmd,
                "OneId",
                (t1, children) => { t1.Children = children; },
                "OneId"
            );

            Assert.NotNull(ds);
            Assert.Single(ds);
            Assert.NotEmpty(ds[0].Children);
            Assert.Equal(Currency.USD, ds[0].Children.First().ChargedIn);
        }

        [Fact]
        public void LoadDatasetWithEnumNull()
        {
            var sql = "select 1 as OneId; select 1 as OneId, null as ChargedIn";
            var cmd = ctx.CreateCommand(sql);
            var ds = ctx.LoadDataset<ParentTable, ChildTable>(
                cmd,
                "OneId",
                (t1, children) => { t1.Children = children; },
                "OneId"
            );

            Assert.NotNull(ds);
            Assert.Single(ds);
            Assert.NotEmpty(ds[0].Children);
            Assert.Equal(Currency.CAD, ds[0].Children.First().ChargedIn);
        }

        [Fact]
        public void LoadDatasetWithEnumEmptyString()
        {
            var sql = "select 1 as OneId; select 1 as OneId, '' as ChargedIn";
            var cmd = ctx.CreateCommand(sql);
            var ds = ctx.LoadDataset<ParentTable, ChildTable>(
                cmd,
                "OneId",
                (t1, children) => { t1.Children = children; },
                "OneId"
            );

            Assert.NotNull(ds);
            Assert.Single(ds);
            Assert.NotEmpty(ds[0].Children);
            Assert.Equal(Currency.CAD, ds[0].Children.First().ChargedIn);
        }


        class ParentTableNormal
        {
            public int OneId { get; set; }
            public IList<ChildTableNormal> Children { get; set; }
        }
        class ChildTableNormal
        {
            public int OneId { get; set; }
            public string FieldOne { get; set; }
        }
        [Fact]
        public void LoadDatasetWithEnumInvalid()
        {
            var sql = "select 1 as OneId; select 1 as OneId, getdate() as FieldOne";
            var cmd = ctx.CreateCommand(sql);
            Assert.Throws<System.ArgumentException>(() =>
            {
                var ds = ctx.LoadDataset<ParentTableNormal, ChildTableNormal>(
                    cmd,
                    "OneId",
                    (t1, children) => { 
                        t1.Children = children; },
                    "OneId"
                );
            });
        }
    }
}
