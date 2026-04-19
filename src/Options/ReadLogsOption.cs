using sync.DataManagement;

namespace sync.Options;

public class ReadLogsOption(LogsManagement logsManagement) : OptionBase
{
    public override void Execute()
    {
        logsManagement.ReadLogs();
    }
}