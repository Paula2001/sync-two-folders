using sync.Options;
using sync.FolderManagement;

namespace sync;

public sealed class Application(OptionsHandler optionsHandler, FolderSync folderSync)
{
    public async Task Run()
    {
        await Task.WhenAll(
            Task.Run(() => optionsHandler.ReceiveOption()),
            Task.Run(() => folderSync.ReadAsync())
        );
    }
}