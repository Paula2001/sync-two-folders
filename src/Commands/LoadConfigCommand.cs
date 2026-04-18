namespace sync.src.Commands;

public class LoadConfigCommand(Config conf) : CommandBase
{
    public override void Execute()
    {
        Console.WriteLine("\n--- Current Configuration ---");
        Console.WriteLine($"Source: {conf.SourceFolder}");
        Console.WriteLine($"Target: {conf.TargetFolder}");
        Console.WriteLine($"Interval: {conf.TimeIntervalInSeconds}s");
        Console.WriteLine($"Log Path: {conf.LogFilePath}\n");
    }
}