using Spectre.Console;

namespace sync.Options;

public class SetLogPathOption(Config config, IAnsiConsole console) : OptionBase
{
    public override void Execute()
    {
        var logFileName = console.Ask<string>("Set the [green]Log[/] file name (without extension).");
        config.LogFilePath = logFileName;
    }
}
