using Spectre.Console;

namespace sync.Options;

public class SetLogPathOption(Config config, IAnsiConsole console) : OptionBase(console)
{
    public override void Execute()
    {
        var logFileName = ConsoleInstance.Ask<string>("Set the [green]Log[/] file name (without extension).");
        config.LogFilePath = logFileName;
    }
}
