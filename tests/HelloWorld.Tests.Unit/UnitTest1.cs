using System.Text;

namespace HelloWorld.Tests.Unit;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var sb = new StringBuilder();
        var tw = new StringWriter(sb);
        Assert.Throws<ArgumentNullException>(() => new HelloWorld().Print(null!));
    }



    [Fact]
    public void Test2()
    {
        var sb = new StringBuilder();
        var tw = new StringWriter(sb);
        new HelloWorld().Print(tw);
        Assert.Equal("Hello World", sb.ToString().Trim());
    }
}

