using BenchmarksBasicsUtils;

namespace BenchmarksBasicsTests;

public class UtilitiesTests
{
    [Theory]
    [InlineData(1, 1)]
    [InlineData(2, 1)]
    [InlineData(3, 1)]
    [InlineData(4, 2)]
    [InlineData(5, 2)]
    [InlineData(6, 2)]
    [InlineData(7, 3)]
    [InlineData(8, 3)]
    [InlineData(9, 3)]
    [InlineData(10, 4)]
    [InlineData(11, 4)]
    [InlineData(12, 4)]
    public void TestConversionWorks(int month, int expectedQuarter)
    {
        AssertResults(month, expectedQuarter);
    }   

    private void AssertResults(int month, int expectedQuarter)
    {
        Assert.Equal(expectedQuarter, Utilities.MonthToQuarterUsingIntegerDivision(month));
        Assert.Equal(expectedQuarter, Utilities.MonthToQuarterUsingStaticArray(month));
        Assert.Equal(expectedQuarter, Utilities.MonthToQuarterUsingSwitchExpression(month));
        Assert.Equal(expectedQuarter, Utilities.MonthToQuarterUsingSwitchStatement(month));
    }
}
