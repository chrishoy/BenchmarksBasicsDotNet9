using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Running;

Console.WriteLine("Benchmarking!");

var summary = BenchmarkRunner.Run<BenchmarkMonthToQuarter>();


internal static class Utilities
{
    private static int[] MonthToQuarter = [0, 1, 1, 1, 2, 2, 2, 3, 3, 3, 4, 4, 4];

    public static int MonthToQuarterUsingArray(int month)
    {
        if (month < 1 || month > 12)
        {
            throw new ArgumentOutOfRangeException(nameof(month), "Month must be between 1 and 12.");
        }

        return MonthToQuarter[month];
    }
}

[MemoryDiagnoser]
public class BenchmarkMonthToQuarter
{
    private readonly Consumer _consumer = new();

    [Benchmark]
    public void MonthToQuarterUsingArray()
    {
        for (int i = 1; i <= 12; i++)
        {
            // Use Consumer to prevent optimisation of code (no side effects)
            _consumer.Consume(Utilities.MonthToQuarterUsingArray(i));
        }
    }

}
