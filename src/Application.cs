using sync.src.Commands;
using sync.DataManagement;
using Spectre.Console;
namespace sync;

public sealed class Application(CommandsHandler commandsHandler, FolderSync folderSync)
{
    public void Run()
    {
        var t = new Thread(new ThreadStart(() => commandsHandler.RecieveCommand()));
        t.Start();
        
        var t2 = folderSync.Read();
        t.Join();
        t2.Join();
    }
}