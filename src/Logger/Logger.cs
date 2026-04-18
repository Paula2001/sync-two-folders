using System.Diagnostics;

namespace sync.src.Logger;

public class Logger(Config config)
{
    private bool IsLogFileAvailable()
    {
        return File.Exists(config.LogFilePath);
    }

    public void Log()
    {
        
    }

}