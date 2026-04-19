using Spectre.Console.Testing;
namespace sync.Helpers.Integration;

class InputHelpers
{
    public static void SelectConfig(TestConsole console)
    {
        console.Input.PushKey(ConsoleKey.DownArrow);
        console.Input.PushKey(ConsoleKey.DownArrow);
        console.Input.PushKey(ConsoleKey.DownArrow);
        console.Input.PushKey(ConsoleKey.DownArrow);
        console.Input.PushKey(ConsoleKey.Enter);
    }

    public static void QuitResult(TestConsole console)
    {
        console.Input.PushKey(ConsoleKey.Q);
    }

    public static void QuitApp(TestConsole console)
    {
        console.Input.PushKey(ConsoleKey.DownArrow);
        console.Input.PushKey(ConsoleKey.DownArrow);
        console.Input.PushKey(ConsoleKey.DownArrow);
        console.Input.PushKey(ConsoleKey.DownArrow);
        console.Input.PushKey(ConsoleKey.DownArrow);
        console.Input.PushKey(ConsoleKey.DownArrow);
        console.Input.PushKey(ConsoleKey.Enter);
    }
}