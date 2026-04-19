using sync.FolderManagement;
using sync.Logger;

namespace sync.Options;

public class ReadLogsOption(FileLogger fileLogger) : OptionBase
{
    public override async void Execute()
    {
        var data = await fileLogger.ReadLogsAsync();
        Console.WriteLine(data);
    }
}