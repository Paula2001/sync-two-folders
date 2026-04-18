namespace sync.DataManagement;

public class FolderSync(Config config, CancellationTokenSource cts)
{
    public Task Read()
    {
        string sourceFolder = config.SourceFolder;
        string targetFolder = config.TargetFolder;
        string logsFile = config.LogFilePath;
        return Task.Run(async () =>
        {
            while (true)
            {
                cts.Token.ThrowIfCancellationRequested();
                try
                {
                    var files = Directory.GetFiles(sourceFolder);

                    // Console.WriteLine($"[{DateTime.Now}] Files:");
                    foreach (var file in files)
                    {
                        // Console.WriteLine(file);
                        // TODO: if the file name doesn't exist then move
                        // TODO: if the file name exists check with the md5 content if not equal then replace
                        // TODO: in both cases log it
                        // Console.WriteLine(Path.GetFileName(file));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    cts.Cancel();
                }
                await Task.Delay(config.TimeIntervalInSeconds, cts.Token);
            }
        });
    }
}