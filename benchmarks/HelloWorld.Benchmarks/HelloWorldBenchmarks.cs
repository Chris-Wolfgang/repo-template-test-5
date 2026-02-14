using BenchmarkDotNet.Attributes;
using System.IO;

namespace HelloWorld.Benchmarks;

/// <summary>
/// Benchmarks for the HelloWorld library.
/// </summary>
[MemoryDiagnoser]
public class HelloWorldBenchmarks
{
    private readonly HelloWorld _helloWorld = new();

    /// <summary>
    /// Benchmark for the Print method using StringWriter.
    /// </summary>
    [Benchmark]
    public void Print_StringWriter()
    {
        using var sw = new StringWriter();
        _helloWorld.Print(sw);
    }

    /// <summary>
    /// Benchmark for the Print method using StreamWriter with NullStream.
    /// </summary>
    [Benchmark]
    public void Print_StreamWriter()
    {
        var ms = Stream.Null;
        using var sw = new StreamWriter(ms);
        _helloWorld.Print(sw);
    }

    /// <summary>
    /// Benchmark for the Print method using Console.Out directly.
    /// </summary>
    [Benchmark]
    public void Print_ConsoleOut()
    {
        _helloWorld.Print(Console.Out);
    }
}
