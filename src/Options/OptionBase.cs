using Spectre.Console;

namespace sync.Options;

public abstract class OptionBase
{
    protected IAnsiConsole ConsoleInstance { get; }

    protected OptionBase(IAnsiConsole console)
    {
        ConsoleInstance = console;
    }

    public abstract void Execute();

    public void RunOption()
    {
        Execute();

        ConsoleInstance.MarkupLine("Press [green]Q[/] to return to options");

        while (true)
        {
            var key = System.Console.ReadKey(true);

            if (key.Key == ConsoleKey.Q)
            {
                System.Console.Clear();
                break;
            }
        }

        System.Console.Clear();
    }
}