using Spectre.Console;
using sync.Logger;

namespace sync.Options;

public class ReadLogsOption(FileLogger fileLogger, IAnsiConsole console) : OptionBase(console)
{
    public override async void Execute()
    {
        var data = await fileLogger.ReadLogsAsync();
        ConsoleInstance.MarkupLine(data);
    }
}