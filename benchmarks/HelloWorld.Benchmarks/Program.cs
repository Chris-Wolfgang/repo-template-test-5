using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.IO;

namespace HelloWorld.Benchmarks;

/// <summary>
/// Benchmarks for the HelloWorld.Print method.
/// </summary>
[MemoryDiagnoser]
#pragma warning disable MA0048 // File name must match type name - benchmark class in Program.cs is acceptable
#pragma warning disable CA1001 // Types that own disposable fields should be disposable - BenchmarkDotNet uses GlobalCleanup
public sealed class HelloWorldBenchmarks
#pragma warning restore CA1001
#pragma warning restore MA0048
{
    private HelloWorld _helloWorld = null!;
    private StringWriter _stringWriter = null!;
    private StreamWriter _nullStreamWriter = null!;

    [GlobalSetup]
    public void GlobalSetup()
    {
        _helloWorld = new HelloWorld();
        _nullStreamWriter = new StreamWriter(Stream.Null);
    }

    [GlobalCleanup]
    public void GlobalCleanup()
    {
        _stringWriter?.Dispose();
        _nullStreamWriter?.Dispose();
    }

    [IterationSetup(Target = nameof(PrintToStringWriter))]
    public void SetupStringWriter()
    {
        _stringWriter = new StringWriter();
    }

    [IterationCleanup(Target = nameof(PrintToStringWriter))]
    public void CleanupStringWriter()
    {
        _stringWriter?.Dispose();
    }

    [Benchmark]
    public void PrintToStringWriter()
    {
        _helloWorld.Print(_stringWriter);
    }

    [Benchmark]
    public void PrintToNullStream()
    {
        _helloWorld.Print(_nullStreamWriter);
    }

    [Benchmark]
    public void PrintToConsoleOut()
    {
        _helloWorld.Print(Console.Out);
    }
}

class Program
{
    static void Main(string[] args)
    {
        BenchmarkRunner.Run<HelloWorldBenchmarks>();
    }
}
