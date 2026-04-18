using Spectre.Console;

namespace sync.src.Commands;

public abstract class CommandBase
{
    public abstract void Execute();
    public void RunCommand()
    {
        Execute();

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
    }
}