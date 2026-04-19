using Spectre.Console;

namespace sync.Options;

public class LoadConfigOption(Config conf, IAnsiConsole console) : OptionBase(console)
{
    public override void Execute()
    {
        ConsoleInstance.MarkupLine("[grey]--- Current Configuration ---[/]");
        ConsoleInstance.MarkupLine($"Source: {Markup.Escape(conf.SourceFolder)}");
        ConsoleInstance.MarkupLine($"Target: {Markup.Escape(conf.TargetFolder)}");
        ConsoleInstance.MarkupLine($"Interval: {conf.TimeIntervalInSeconds}s");
        ConsoleInstance.MarkupLine($"Log Path: {Markup.Escape(conf.LogFilePath)}");
    }
}