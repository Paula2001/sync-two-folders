using sync.Enums;
using Spectre.Console;
using System.Text.Json;

namespace sync.Options;
public class OptionsHandler(
    SetSourceFolderOption setSourceFolderOption,
    SetTargetFolderOption setTargetFolderOption,
    SetIntervalOption setIntervalOption,
    SetLogPathOption setLogPathOption,
    LoadConfigOption loadConfigOption,
    ReadLogsOption readLogsOption,
    CancellationTokenSource cts,
    IAnsiConsole console
) {
    public bool Stop {get; set;} = false;

   private readonly Dictionary<OptionsEnum, OptionBase> _options = new Dictionary<OptionsEnum, OptionBase>
    {
        { OptionsEnum.SOURCE, setSourceFolderOption },
        { OptionsEnum.TARGET, setTargetFolderOption },
        { OptionsEnum.INTERVAL, setIntervalOption },
        { OptionsEnum.LOG, setLogPathOption },
        { OptionsEnum.CONFIG, loadConfigOption },
        { OptionsEnum.READ_LOGS, readLogsOption }
    };

    public void ReceiveOption()
    {
        while (true)
            {
                cts.Token.ThrowIfCancellationRequested();
                var features = console.Prompt(new SelectionPrompt<string>()
                    .Title("Select [green]Option[/] :")
                    .AddChoices(
                        "Source", 
                        "Target", 
                        "Interval", 
                        "Log",
                        "Config",
                        "Read Logs",
                        "Exit"
                    ));
        
                if (features != null)
                {
                    features = JsonNamingPolicy.SnakeCaseLower.ConvertName(features);
                    if(Enum.TryParse(features, ignoreCase: true, out OptionsEnum option))
                    {
                        if (option == OptionsEnum.EXIT)
                        {
                            cts.Cancel();
                            Console.WriteLine("Exiting application... bye bye!");
                            break;
                        }               
                        
                        if(_options.TryGetValue(option, out var selectedOption))
                        {
                            selectedOption.RunOption();
                        }  
                    }
                }
                
            }
    }
}