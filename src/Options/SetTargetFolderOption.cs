using Spectre.Console;

namespace sync.Options;

public class SetTargetFolderOption(Config config, IAnsiConsole console) : OptionBase
{
    public override void Execute()
    {
        var name = console.Ask<string>("Set the [green]Target[/] folder.");
        config.TargetFolder = name;
    }
}
