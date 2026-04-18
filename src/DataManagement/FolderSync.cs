using sync.Commands;

namespace sync.DataManagement;

public class FolderSync(CommandsHandler commands, Config config, CancellationTokenSource cts)
{
    public Thread Read()
    {
        string sourceFolder = config.SourceFolder;
        string targetFolder = config.TargetFolder;
        Thread thread = new(() =>
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
                Thread.Sleep(config.TimeIntervalInSeconds); // 10 seconds delay
            }
        });

        thread.Start();

        return thread;
    }
}