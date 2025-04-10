# Simple .Net 9 Benchmark Comparisons

I was asked recently how to convert an integer representing a month to the quarter the month is in.
Turns out the question was about performance, and my simple answer, use a simple `(month - 1) / 4 + 1`,
which uses integer division and therefore should be very fast anyway, was not quite what was being looked for.

When pressed further I mentioned you could use a switch expression, but what they were looking for was
to use a static array and do a simple lookup.

So on my way back home I thought about this, and decided to do a benchmark comparison.
Always good to prove simple things like this for yourself :wink:

## How to Use
- Clone the repository
- Open the solution in `VS Code`
- `launch.json` and `tasks.json` are pre-configured to run the benchmarks
- Run and see the results in the Terminal window

## Results
And here's the proof!

| Method                              | Mean      | Error     | StdDev    | Median    | Allocated |
|------------------------------------ |----------:|----------:|----------:|----------:|----------:|
| MonthToQuarterUsingArray            |  8.562 ns | 0.2031 ns | 0.5278 ns |  8.456 ns |         - |
| MonthToQuarterUsingIntegerDivision  | 13.048 ns | 0.2925 ns | 0.3251 ns | 12.963 ns |         - |
| MonthToQuarterUsingSwitchExpression | 32.312 ns | 0.7340 ns | 2.0940 ns | 31.955 ns |         - |
| MonthToQuarterUsingSwitchStatement  | 28.136 ns | 0.9185 ns | 2.6646 ns | 27.422 ns |         - |
