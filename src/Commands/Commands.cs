using sync.Enums;
using Spectre.Console;

namespace sync.src.Commands;
public class CommandsHandler(
    SetSourceFolderCommand setSourceFolderCommand,
    LoadConfigCommand loadConfigCommand,
    CancellationTokenSource cts
) {
    public bool Stop {get; set;} = false;

   private Dictionary<CommandsEnum, CommandBase> _commands = new Dictionary<CommandsEnum, CommandBase>
    {
        { CommandsEnum.SOURCE, setSourceFolderCommand },
        { CommandsEnum.CONFIG, loadConfigCommand }
    };

    public void RecieveCommand()
    {
        while (true)
            {
                cts.Token.ThrowIfCancellationRequested();
                var features = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Select [green]features[/] to enable:")
                .AddChoices(
                    "Source", 
                    "Target", 
                    "Interval", 
                    "Log",
                    "Config",
                    "Exit"
                ));


                AnsiConsole.MarkupLine($"Enabled: [blue]{string.Join(", ", features)}[/]");
        
                if (features != null)
                {
                    if(Enum.TryParse(features, ignoreCase: true, out CommandsEnum cmd))
                    {
                        if (cmd == CommandsEnum.EXIT)
                        {
                            cts.Cancel();
                            Console.WriteLine("Exiting application... bye bye!");
                            break;
                        }               
                        
                        if(_commands.TryGetValue(cmd, out var command))
                        {
                            command.RunCommand();        
                        }  
                    }
                    
                    



                    // switch (cmd)
                    // {
                    //     case CommandsEnum.SOURCE:
                    //         conf.SourceFolder = Console.ReadLine() ?? conf.SourceFolder;
                    //         break;
                    //     case CommandsEnum.TARGET:
                    //         Console.Write("Enter target folder path: ");
                    //         conf.TargetFolder = Console.ReadLine() ?? conf.TargetFolder;
                    //         break;
                    //     case CommandsEnum.INTERVAL:
                    //         Console.Write("Enter interval (seconds): ");
                    //         if (int.TryParse(Console.ReadLine(), out int interval)) conf.TimeIntervalInSeconds = interval;
                    //         break;
                    //     case CommandsEnum.LOG:
                    //         Console.Write("Enter log file path: ");
                    //         conf.LogFilePath = Console.ReadLine() ?? "./logs";
                    //         break;
                    //     case CommandsEnum.CONFIG:
                    //         Console.WriteLine("\n--- Current Configuration ---");
                    //         Console.WriteLine($"Source: {conf.SourceFolder}");
                    //         Console.WriteLine($"Target: {conf.TargetFolder}");
                    //         Console.WriteLine($"Interval: {conf.TimeIntervalInSeconds}s");
                    //         Console.WriteLine($"Log Path: {conf.LogFilePath}\n");
                    //         break;
                    //     default:
                    //         Console.WriteLine("Command not recognized.");
                    //         break;
                    // }
                }
                
            }
    }
}