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

    public static int MonthToQuarterUsingIntegerDivision(int month)
    {
        if (month < 1 || month > 12)
        {
            throw new ArgumentOutOfRangeException(nameof(month), "Month must be between 1 and 12.");
        }

        return month / 4 + 1;
    }

    public static int MonthToQuarterUsingSwitchExpression(int month) => month switch
    {
        1 or 2 or 3 => 1,
        4 or 5 or 6 => 2,
        7 or 8 or 9 => 3,
        10 or 11 or 12 => 4,
        _ => throw new ArgumentOutOfRangeException(nameof(month), "Month must be between 1 and 12.")
    };

    public static int MonthToQuarterUsingSwitchStatement(int month)
    {
        switch (month)
        {
            case 1:
            case 2:
            case 3:
                return 1;
            case 4:
            case 5:
            case 6:
                return 2;
            case 7:
            case 8:
            case 9:
                return 3;
            case 10:
            case 11:
            case 12:
                return 4;
            default:
                throw new ArgumentOutOfRangeException(nameof(month), "Month must be between 1 and 12.");
        }
    } 
}

[MemoryDiagnoser]
public class BenchmarkMonthToQuarter
{
    // Use Consumer to prevent optimisation of code (utility function has no side effects)
    private readonly Consumer _consumer = new();

    [Benchmark]
    public void MonthToQuarterUsingIntegerDivision()
    {
        for (int i = 1; i <= 12; i++)
        {
            _consumer.Consume(Utilities.MonthToQuarterUsingIntegerDivision(i));
        }
    }

    [Benchmark]
    public void MonthToQuarterUsingArray()
    {
        for (int i = 1; i <= 12; i++)
        {
            _consumer.Consume(Utilities.MonthToQuarterUsingArray(i));
        }
    }

    [Benchmark]
    public void MonthToQuarterUsingSwitchExpression()
    {
        for (int i = 1; i <= 12; i++)
        {
            _consumer.Consume(Utilities.MonthToQuarterUsingSwitchExpression(i));
        }
    }

    [Benchmark]
    public void MonthToQuarterUsingSwitchStatement()
    {
        for (int i = 1; i <= 12; i++)
        {
            _consumer.Consume(Utilities.MonthToQuarterUsingSwitchStatement(i));
        }
    }              
}
