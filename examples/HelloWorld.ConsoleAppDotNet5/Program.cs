using System;

namespace HelloWorld.ConsoleApp.DotNet5
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var helloWorld = new HelloWorld();
            helloWorld.Print(Console.Out);
        }
    }
}
