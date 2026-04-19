using Spectre.Console;

namespace sync.Options;

public abstract class OptionBase
{
    public abstract void Execute();
    public void RunOption()
    {
        Execute();

        AnsiConsole.MarkupLine("Press [green]Q[/] to return to options");
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