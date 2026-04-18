
using Spectre.Console;

namespace sync.src.Commands;

public class SetSourceFolderCommand : CommandBase
{
    public override void Execute()
    {
        var name = AnsiConsole.Ask<string>("Set the [green]Source[/] folder.");
        AnsiConsole.MarkupLine($"Your Source folder is [blue]{name}[/].");
    }
}