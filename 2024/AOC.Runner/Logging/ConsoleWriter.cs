using System.IO;
using Xunit.Abstractions;

namespace AOC.Runner.Logging;

public class ConsoleWriter(ITestOutputHelper output) : StringWriter
{
    public override void WriteLine(string message)
    {
        output.WriteLine(message);
    }
}
