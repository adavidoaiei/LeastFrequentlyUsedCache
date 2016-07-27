using BenchmarkDotNet.Running;

namespace LfuCache.PerformanceTest
{
    /// <summary>
    /// To run benchmarks properly, run Main() in Release mode without the debugger attached (Debug -> Start Without Debugging).
    /// </summary>
    internal class Benchmarks
    {
        private static void Main()
        {
            BenchmarkRunner.Run<LfuCacheBenchmarks>();
            BenchmarkRunner.Run<MemoryCacheBenchmarks>();
        }
    }
}
