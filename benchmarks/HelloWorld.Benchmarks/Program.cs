using BenchmarkDotNet.Running;

namespace HelloWorld.Benchmarks;

/// <summary>
/// Entry point for the benchmark application.
/// </summary>
public class Program
{
    public static void Main(string[] args)
    {
        BenchmarkRunner.Run<HelloWorldBenchmarks>(args: args);
    }
}

