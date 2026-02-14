using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.IO;

namespace HelloWorld.Benchmarks;

/// <summary>
/// Benchmarks for the HelloWorld.Print method.
/// </summary>
[MemoryDiagnoser]
#pragma warning disable MA0048 // File name must match type name - benchmark class in Program.cs is acceptable
public sealed class HelloWorldBenchmarks : IDisposable
#pragma warning restore MA0048
{
    private HelloWorld _helloWorld = null!;
    private StringWriter _stringWriter = null!;
    private StreamWriter _nullStreamWriter = null!;

    [GlobalSetup]
    public void Setup()
    {
        _helloWorld = new HelloWorld();
        _stringWriter = new StringWriter();
        _nullStreamWriter = new StreamWriter(Stream.Null);
    }

    [GlobalCleanup]
    public void Cleanup()
    {
        Dispose();
    }

    public void Dispose()
    {
        _stringWriter?.Dispose();
        _nullStreamWriter?.Dispose();
    }

    [Benchmark]
    public void PrintToStringWriter()
    {
        _stringWriter.GetStringBuilder().Clear();
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
