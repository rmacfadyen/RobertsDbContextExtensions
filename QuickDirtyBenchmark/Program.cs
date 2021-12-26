using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RobertsDbContextExtensions;
using System.Diagnostics;

string ConnectionString;

bool UseLocalDb = true;


if (UseLocalDb)
{
    string projectDirectory = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\.."));
    ConnectionString = $@"Server=(LocalDB)\MSSQLLocalDB;Integrated Security=SSPI;Initial catalog=Bench;AttachDbFilename={projectDirectory}\Bench.mdf";
}
else
{
    ConnectionString = @"Server=.;Integrated Security=SSPI;Initial Catalog=testdb;";
}

Console.WriteLine("Preparing benchmark");

var builder = new DbContextOptionsBuilder<QuickDirtyBenchmark.Models.TestDbContext>();
builder.UseSqlServer(ConnectionString);



{
    //
    // Create and populate the table with 25 random records
    //
    using var cnEfCoreWarmup = new QuickDirtyBenchmark.Models.TestDbContext(builder.Options);
    cnEfCoreWarmup.Database.EnsureDeleted();
    cnEfCoreWarmup.Database.EnsureCreated();

    //
    // Read from the table
    //
    var n = (from t in cnEfCoreWarmup.TableOne select t).ToList();
    Console.WriteLine($"    EFCore warmed up, number of test rows {n.Count}");
    
    //
    // Create a connection and read from the table
    //
    var cnDapper = new SqlConnection(ConnectionString);
    var cmd = new CommandDefinition("select * from TableOne");
    var dt = cnDapper.Query<QuickDirtyBenchmark.Models.TableOne>(cmd).ToList();
    Console.WriteLine($"    Dapper warmed up, number of test rows {dt.Count}");

    //
    // Read from the table
    //
    var rt = cnEfCoreWarmup.ExecuteList<QuickDirtyBenchmark.Models.TableOne>("select * from TableOne");
    Console.WriteLine($"    Roberts warmed up, number of test rows {rt.Count}");
}
Console.WriteLine("Preparataions complete\n");

var Watch = new Stopwatch();

var Results = new List<RunResult>();

for (var Iteration = 0; Iteration < 10; Iteration += 1)
{

    Console.Write("EFCore 4 random records running...");
    Watch.Restart();
    {
        var rnd = new Random(1808);

        using var cnEfCore = new QuickDirtyBenchmark.Models.TestDbContext(builder.Options);
        for (var i = 0; i < 100000; i++)
        {
            var p0 = rnd.Next(1, 25);
            var p1 = rnd.Next(1, 25);
            var p2 = rnd.Next(1, 25);
            var p3 = rnd.Next(1, 25);
            // using contains takes 1 minute!!!
            // using t.OneId == id[0] || t.OneId == id[1] ... takes 1 minute!!!
            var l = (from t in cnEfCore.TableOne.AsNoTracking() where t.OneId == p0 || t.OneId == p1 || t.OneId == p2 || t.OneId == p3 select t).ToList().Last();
        }
    }
    Watch.Stop();
    Console.WriteLine($"\rEFCore 4 random records elapsed {Watch.Elapsed}");
    Results.Add(new RunResult { Iteration = Iteration, Engine = "EFCore", Testname = "4 random records", Elapsed = Watch.Elapsed });

    Console.Write("EFCore 1 random record running...");
    Watch.Restart();
    {
        var rnd = new Random(1808);

        using var cnEfCore = new QuickDirtyBenchmark.Models.TestDbContext(builder.Options);
        for (var i = 0; i < 100000; i++)
        {
            var p0 = rnd.Next(1, 25);
            var l = (from t in cnEfCore.TableOne.AsNoTracking() where t.OneId == p0 select t).Single();
        }
    }
    Watch.Stop();
    Console.WriteLine($"\rEFCore 1 random record elapsed {Watch.Elapsed}");
    Results.Add(new RunResult { Iteration = Iteration, Engine = "EFCore", Testname = "1 random record", Elapsed = Watch.Elapsed });


    Console.Write("EFCore all records running...");
    Watch.Restart();
    {
        var rnd = new Random(1808);

        using var cnEfCore = new QuickDirtyBenchmark.Models.TestDbContext(builder.Options);
        for (var i = 0; i < 100000; i++)
        {
            var l = (from t in cnEfCore.TableOne.AsNoTracking() select t).ToList().Last();
        }
    }
    Watch.Stop();
    Console.WriteLine($"\rEFCore all records elapsed {Watch.Elapsed}");
    Results.Add(new RunResult { Iteration = Iteration, Engine = "EFCore", Testname = "All records", Elapsed = Watch.Elapsed });




    Console.Write("\nRoberts 4 random records running...");
    Watch.Restart();
    {
        var rnd = new Random(1808);

        using var cnEfCore = new QuickDirtyBenchmark.Models.TestDbContext(builder.Options);
        var cn = cnEfCore.Database.GetDbConnection();
        for (var i = 0; i < 100000; i++)
        {
            var p0 = rnd.Next(1, 25);
            var p1 = rnd.Next(1, 25);
            var p2 = rnd.Next(1, 25);
            var p3 = rnd.Next(1, 25);
            using var cmd = cnEfCore.CreateCommand("select OneId, byte1, sbyte1, short1, ushort1, int1, uint1, long1, ulong1, float1, double1, decimal1, bool1, string1, char1, guid1, datetime1, datetimeoffset1, bytearray1 from TableOne where OneId = @p0 or OneId = @p1 or OneId = @p2 or OneId = @p3", p0, p1, p2, p3);
            var l = cnEfCore.ExecuteList<QuickDirtyBenchmark.Models.TableOne>(cmd).Last();
        }
    }
    Watch.Stop();
    Console.WriteLine($"\rRoberts 4 random records elapsed {Watch.Elapsed}");
    Results.Add(new RunResult { Iteration = Iteration, Engine = "Roberts", Testname = "4 random records", Elapsed = Watch.Elapsed });


    Console.Write("Roberts 1 random record running...");
    Watch.Restart();
    {
        var rnd = new Random(1808);

        using var cnEfCore = new QuickDirtyBenchmark.Models.TestDbContext(builder.Options);
        var cn = cnEfCore.Database.GetDbConnection();
        for (var i = 0; i < 100000; i++)
        {
            var p0 = rnd.Next(1, 25);
            using var cmd = cnEfCore.CreateCommand("select OneId, byte1, sbyte1, short1, ushort1, int1, uint1, long1, ulong1, float1, double1, decimal1, bool1, string1, char1, guid1, datetime1, datetimeoffset1, bytearray1 from TableOne where OneId = @p0", p0);
            var l = cnEfCore.ExecuteScalar<QuickDirtyBenchmark.Models.TableOne>(cmd);
        }
    }
    Watch.Stop();
    Console.WriteLine($"\rRoberts 1 random record elapsed {Watch.Elapsed}");
    Results.Add(new RunResult { Iteration = Iteration, Engine = "Roberts", Testname = "1 random record", Elapsed = Watch.Elapsed });


    Console.Write("Roberts all records running...");
    Watch.Restart();
    {
        var rnd = new Random(1808);

        using var cnEfCore = new QuickDirtyBenchmark.Models.TestDbContext(builder.Options);
        var cn = cnEfCore.Database.GetDbConnection();
        for (var i = 0; i < 100000; i++)
        {
            using var cmd = cnEfCore.CreateCommand("select OneId, byte1, sbyte1, short1, ushort1, int1, uint1, long1, ulong1, float1, double1, decimal1, bool1, string1, char1, guid1, datetime1, datetimeoffset1, bytearray1 from TableOne");
            var l = cnEfCore.ExecuteList<QuickDirtyBenchmark.Models.TableOne>(cmd).Last();
        }
    }
    Watch.Stop();
    Console.WriteLine($"\rRoberts all records elapsed {Watch.Elapsed}");
    Results.Add(new RunResult { Iteration = Iteration, Engine = "Roberts", Testname = "All records", Elapsed = Watch.Elapsed });




    Console.Write("\nDapper 4 random records running...");
    Watch.Restart();
    {
        var rnd = new Random(1808);

        var cnDapper = new SqlConnection(ConnectionString);

        for (var i = 0; i < 100000; i++)
        {
            var p0 = rnd.Next(1, 25);
            var p1 = rnd.Next(1, 25);
            var p2 = rnd.Next(1, 25);
            var p3 = rnd.Next(1, 25);
            var cmd = new CommandDefinition("select OneId, byte1, sbyte1, short1, ushort1, int1, uint1, long1, ulong1, float1, double1, decimal1, bool1, string1, char1, guid1, datetime1, datetimeoffset1, bytearray1 from TableOne where OneId = @p0 or OneId = @p1 or OneId = @p2 or OneId = @p3", new { p0, p1, p2, p3 });
            var l = cnDapper.Query<QuickDirtyBenchmark.Models.TableOne>(cmd).Last();
        }
    }
    Watch.Stop();
    Console.WriteLine($"\rDapper 4 random records elapsed {Watch.Elapsed}");
    Results.Add(new RunResult { Iteration = Iteration, Engine = "Dapper", Testname = "4 random records", Elapsed = Watch.Elapsed });


    Console.Write("Dapper 1 random record running...");
    Watch.Restart();
    {
        var rnd = new Random(1808);

        var cnDapper = new SqlConnection(ConnectionString);

        for (var i = 0; i < 100000; i++)
        {
            var p0 = rnd.Next(1, 25);
            var cmd = new CommandDefinition("select OneId, byte1, sbyte1, short1, ushort1, int1, uint1, long1, ulong1, float1, double1, decimal1, bool1, string1, char1, guid1, datetime1, datetimeoffset1, bytearray1 from TableOne where OneId = @p0", new { p0 });
            var l = cnDapper.QuerySingle<QuickDirtyBenchmark.Models.TableOne>(cmd);
        }
    }
    Watch.Stop();
    Console.WriteLine($"\rDapper 1 random record elapsed {Watch.Elapsed}");
    Results.Add(new RunResult { Iteration = Iteration, Engine = "Dapper", Testname = "1 random record", Elapsed = Watch.Elapsed });


    Console.Write("Dapper all records running...");
    Watch.Restart();
    {
        var rnd = new Random(1808);

        var cnDapper = new SqlConnection(ConnectionString);

        for (var i = 0; i < 100000; i++)
        {
            var cmd = new CommandDefinition("select OneId, byte1, sbyte1, short1, ushort1, int1, uint1, long1, ulong1, float1, double1, decimal1, bool1, string1, char1, guid1, datetime1, datetimeoffset1, bytearray1 from TableOne");
            var l = cnDapper.Query<QuickDirtyBenchmark.Models.TableOne>(cmd).Last();
        }
    }
    Watch.Stop();
    Console.WriteLine($"\rDapper all records elapsed {Watch.Elapsed}");
    Results.Add(new RunResult { Iteration = Iteration, Engine = "Dapper", Testname = "All records", Elapsed = Watch.Elapsed });

    Console.WriteLine($"\nCompleted iteration {Iteration}");
}

Console.WriteLine("\n\nBenchmark finished.");


var x =
    from Run in Results
    group Run by new { Run.Engine, Run.Testname } into RunGroup
    orderby RunGroup.Key.Engine, RunGroup.Key.Testname
    select new
    {
        RunGroup.Key.Engine,
        RunGroup.Key.Testname,
        AvgElapsed = RunGroup.Average(r => r.Elapsed.TotalSeconds)
    };

foreach (var y in x)
{
    Console.WriteLine($"{y.Engine} {y.Testname} average {y.AvgElapsed}");
}


class RunResult
{
    public int Iteration { get; set; }
    public string Engine { get; set; }
    public string Testname { get; set; }
    public TimeSpan Elapsed { get; set; }
}