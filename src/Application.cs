using sync.Commands;
using sync.DataManagement;
using Spectre.Console;
namespace sync;

public sealed class Application(CommandsHandler commandsHandler, FolderSync folderSync)
{
    public void Run()
    {
        var table = new Table();
  
        table.AddColumn("Name");
        table.AddColumn("Department");
        table.AddColumn("Sales");
        
        table.AddRow("Alice", "North", "$12,400");
        table.AddRow("Bob", "South", "$8,750");
        table.AddRow("Carol", "West", "$15,200");
        
        AnsiConsole.Write(table);

        // AnsiConsole.Status()
        //     .Start("Processing...", ctx =>
        //     {
        //         Thread.Sleep(2500);
        //     });
       AnsiConsole.MarkupLine("Press [green]Q[/] to return to menu");
        while (true)
        {
            var key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.Q)
            {
                AnsiConsole.Clear();
                break;
            }
        }
       AnsiConsole.Clear();


        var features = AnsiConsole.Prompt(
    new SelectionPrompt<string>()
        .Title("Select [green]features[/] to enable:")
        .AddChoices("Logging", "Caching", "Authentication", "Analytics"));
  
AnsiConsole.MarkupLine($"Enabled: [blue]{string.Join(", ", features)}[/]");
        AnsiConsole.MarkupLine("[bold blue]Welcome[/] to [green]Spectre.Console[/]!");
        
        var t = new Thread(new ThreadStart(() => commandsHandler.RecieveCommand()));
        t.Start();
        
        var t2 = folderSync.Read();
        t.Join();
        t2.Join();
    }
}