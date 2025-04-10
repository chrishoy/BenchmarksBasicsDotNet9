using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Running;
using BenchmarksBasicsUtils;

Console.WriteLine("Benchmarking!");

var summary = BenchmarkRunner.Run<BenchmarkMonthToQuarter>();


[MemoryDiagnoser]
public class BenchmarkMonthToQuarter
{
    // Use Consumer to prevent optimisation of code (utility function has no side effects)
    private readonly Consumer _consumer = new();

    [Benchmark]
    public void MonthToQuarterUsingArray()
    {
        for (int i = 1; i <= 12; i++)
        {
            _consumer.Consume(Utilities.MonthToQuarterUsingStaticArray(i));
        }
    }

    [Benchmark]
    public void MonthToQuarterUsingIntegerDivision()
    {
        for (int i = 1; i <= 12; i++)
        {
            _consumer.Consume(Utilities.MonthToQuarterUsingIntegerDivision(i));
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
