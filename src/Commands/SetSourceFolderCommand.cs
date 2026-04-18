
using Spectre.Console;

namespace sync.src.Commands;

public class SetSourceFolderCommand(Config config) : CommandBase
{
    public override void Execute()
    {
        var name = AnsiConsole.Ask<string>("Set the [green]Source[/] folder.");
        config.SourceFolder = name;
    }
}