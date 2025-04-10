namespace BenchmarksBasicsUtils;

public static class Utilities
{
    private static int[] MonthToQuarter = [0, 1, 1, 1, 2, 2, 2, 3, 3, 3, 4, 4, 4];

    public static int MonthToQuarterUsingStaticArray(int month)
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

        return (month - 1) / 3 + 1;
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
