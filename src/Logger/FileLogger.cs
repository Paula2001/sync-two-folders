using System.Text.Json;

namespace sync.Logger;

public class FileLogger(Config config)
{
    private bool IsLogFileAvailable()
    {
        return File.Exists(config.LogFilePath);
    }

    private void CreateIfLogFileDoesntExist()
    {
        if (!IsLogFileAvailable())
        {
            using var file = File.Create(config.LogFilePath);
        }
    }

    private string FormatLog(Log log)
    {
        return $"{log.TimeStamp} {log.FileOperation} {log.FileName}";
    }

    public async void Log(Log log)
    {
        if (IsLogFileAvailable())
        {
            FormatLog(log);
            using var stream = File.OpenRead(config.LogFilePath);
            var data = await JsonSerializer.DeserializeAsync<LogFile>(stream);
            data[DateTime.Now.ToString()] = new Timestamp
            {
                FileName = log.FileName,
                Operation = log.FileOperation
            };
            var updatedJson = JsonSerializer.Serialize(data, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            await File.WriteAllTextAsync(config.LogFilePath, updatedJson);
        }
    }

    public async Task<string> ReadLogsAsync()
    {
        CreateIfLogFileDoesntExist();
        var fileData = await File.ReadAllTextAsync(config.LogFilePath) ;
        return fileData;
    }

}