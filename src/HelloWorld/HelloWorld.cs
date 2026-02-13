using System;
using System.IO;

namespace HelloWorld;

/// <summary>
/// This class represents a simple Hello World program.
/// </summary>
public class HelloWorld
{
    /// <summary>
    /// Prints "Hello World" to the console.
    /// </summary>
    /// <param name="tw">The text writer to write the output to.</param>
    /// <exception cref="ArgumentNullException"></exception>
    public void Print(TextWriter tw)
    {
        if (tw == null)
        {
            throw new ArgumentNullException(nameof(tw));
        }

        tw.WriteLine("Hello World");
    }
}
