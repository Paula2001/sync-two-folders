using Spectre.Console;

namespace sync.Options;

public class LoadConfigOption(Config conf, IAnsiConsole console) : OptionBase
{
    public override void Execute()
    {
        console.MarkupLine("[grey]--- Current Configuration ---[/]");
        console.MarkupLine($"Source: {Markup.Escape(conf.SourceFolder)}");
        console.MarkupLine($"Target: {Markup.Escape(conf.TargetFolder)}");
        console.MarkupLine($"Interval: {conf.TimeIntervalInSeconds}s");
        console.MarkupLine($"Log Path: {Markup.Escape(conf.LogFilePath)}");
    }
}