using System.Text;

namespace HelloWorld.Tests.Unit;

public class HelloWorldPrintTests
{
    [Fact]
    public void Test1()
    {
        Assert.Throws<ArgumentNullException>(() => new HelloWorld().Print(null!));
    }



    [Fact]
    public void Test2()
    {
        var sb = new StringBuilder();
        using var tw = new StringWriter(sb);
        new HelloWorld().Print(tw);
        Assert.Equal("Hello World", sb.ToString().Trim());
    }
}

