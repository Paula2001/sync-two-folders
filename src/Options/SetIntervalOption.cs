using Spectre.Console;

namespace sync.Options;

public class SetIntervalOption(Config config, IAnsiConsole console) : OptionBase
{
    public override void Execute()
    {
        var interval = console.Ask<int>("Set the [green]Interval[/] in seconds.");
        if (interval <= 0)
        {
            console.MarkupLine("[red]Interval must be greater than 0.[/]");
            return;
        }

        config.TimeIntervalInSeconds = interval;
    }
}
