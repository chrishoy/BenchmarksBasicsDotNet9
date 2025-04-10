# Simple .Net 9 Benchmark Comparisons

I was asked recently how to convert an integer representing a month to the quarter the month is in.
Turns out the question was about performance, and my simple answer, use a switch expression or simple `month / 4 + 1`, which I thought would use integer division and therefore be very fast anyway, was not quite what they were looking for.

The answer is obvious, use an static array and do a simple lookup, but I wanted to benchmark the options to see how they compared anyway. Always good to prove simple things like this for yourself.

## How to Use
- Clone the repository
- Open the solution in `VS Code`
- `launch.json` and `tasks.json` are pre-configured to run the benchmarks
- Run and see the results in the Terminal window
