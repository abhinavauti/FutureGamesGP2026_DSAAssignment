using System;
using System.Diagnostics;

namespace Utilities
{
    public static class Benchmark
    {
        public static double Measure(Action action, int runs)
        {
            action();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for(int i = 0; i < runs; i++)
            {
                action();
            }

            stopwatch.Stop();

            double totalMilliseconds = stopwatch.Elapsed.TotalMilliseconds;

            return totalMilliseconds / runs;
        }
    }
}
