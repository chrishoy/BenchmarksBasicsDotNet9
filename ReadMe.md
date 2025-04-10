# Simple .Net 9 Benchmark Comparisons

I was asked recently how to convert an integer representing a month to the quarter the month is in.
Turns out the question was about performance, and my simple answer, use a simple `month / 4 + 1`, which uses integer division and therefore should be very fast anyway, was not quite what they were looking for.

When pressed further I mentioned you could use a switch expression, but what they were looking for was to use an static array and do a simple lookup.

So on my way back home I thought about this, and decided to do a benchmark comparison. Always good to prove simple things like this for yourself.. We were both right and wrong, but proves a point that it's always good to benchmark :wink:

## How to Use
- Clone the repository
- Open the solution in `VS Code`
- `launch.json` and `tasks.json` are pre-configured to run the benchmarks
- Run and see the results in the Terminal window

## Results
And the winner is... Whoops! Seems Integer Division is the winner.. but only just!

| Method                              | Mean      | Error     | StdDev    | Median    | Allocated |
|------------------------------------ |----------:|----------:|----------:|----------:|----------:|
| MonthToQuarterUsingIntegerDivision  |  7.497 ns | 0.1760 ns | 0.1957 ns |  7.463 ns |         - |
| MonthToQuarterUsingArray            |  8.140 ns | 0.2046 ns | 0.4619 ns |  8.022 ns |         - |
| MonthToQuarterUsingSwitchExpression | 32.011 ns | 0.9082 ns | 2.6493 ns | 31.359 ns |         - |
| MonthToQuarterUsingSwitchStatement  | 28.386 ns | 0.9464 ns | 2.7756 ns | 27.636 ns |         - |