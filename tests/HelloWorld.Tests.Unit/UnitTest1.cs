using System.Text;

namespace HelloWorld.Tests.Unit;

public class HelloWorldPrintTests
{
    [Fact]
    public void Print_ThrowsArgumentNullException_WhenTextWriterIsNull()
    {
        Assert.Throws<ArgumentNullException>(() => new HelloWorld().Print(null!));
    }



    [Fact]
    public void Print_WritesHelloWorld_ToTextWriter()
    {
        var sb = new StringBuilder();
        var tw = new StringWriter(sb);
        new HelloWorld().Print(tw);
        Assert.Equal("Hello World", sb.ToString().Trim());
    }
}

