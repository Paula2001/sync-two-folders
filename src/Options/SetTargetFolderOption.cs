using Spectre.Console;

namespace sync.Options;

public class SetTargetFolderOption(Config config, IAnsiConsole console) : OptionBase(console)
{
    public override void Execute()
    {
        var name = ConsoleInstance.Ask<string>("Set the [green]Target[/] folder.");
        config.TargetFolder = name;
    }
}
