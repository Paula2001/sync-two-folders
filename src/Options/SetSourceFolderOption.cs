
using Spectre.Console;

namespace sync.Options;

public class SetSourceFolderOption(Config config, IAnsiConsole console) : OptionBase
{
    public override void Execute()
    {
        var name = console.Ask<string>("Set the [green]Source[/] folder.");
        config.SourceFolder = name;
    }
}