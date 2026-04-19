namespace sync.DataManagement;

public class FolderSync(Config config, CancellationTokenSource cts)
{
    public async Task ReadAsync()
    {
        while (true)
        {
            cts.Token.ThrowIfCancellationRequested();

            try
            {
                var files = Directory.GetFiles(config.SourceFolder);

                foreach (var file in files)
                {
                    // TODO logic
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                cts.Cancel();
                break;
            }

            await Task.Delay(TimeSpan.FromSeconds(config.TimeIntervalInSeconds)); // add a cts.token
        }
    }
}