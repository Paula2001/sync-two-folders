using sync.Helpers;
using sync.Logger;

namespace sync.FolderManagement;

public class FolderSync(Config config, FileLogger log, CancellationTokenSource cts)
{
    public async Task ReadAsync()
    {
        try
        {
            while (!cts.Token.IsCancellationRequested)
            {
                SyncDeletedFiles();
                SyncSourceFiles();

                await Task.Delay(
                    TimeSpan.FromSeconds(config.TimeIntervalInSeconds),
                    cts.Token
                );
            }
        }
        catch (OperationCanceledException){}
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            cts.Cancel();
        }
    }

    private void SyncDeletedFiles()
    {
        var sourceFiles = Directory.GetFiles(config.SourceFolder);
        var targetFiles = Directory.GetFiles(config.TargetFolder);

        var sourceNames = sourceFiles
            .Select(Path.GetFileName)
            .ToHashSet();

        var missingFiles = targetFiles
            .Where(f => !sourceNames.Contains(Path.GetFileName(f)))
            .ToArray();

        foreach (var file in missingFiles)
        {
            DeleteFile(file);
        }
    }

    private void SyncSourceFiles()
    {
        var files = Directory.GetFiles(config.SourceFolder);

        foreach (var file in files)
        {
            cts.Token.ThrowIfCancellationRequested();

            var fileName = Path.GetFileName(file);
            var targetPath = Path.Combine(config.TargetFolder, fileName);

            if (File.Exists(targetPath))
            {
                UpdateIfChanged(file, targetPath, fileName);
                continue;
            }

            WriteFile(file, targetPath, fileName);
        }
    }

    private void DeleteFile(string file)
    {
        if (!File.Exists(file)) return;

        File.Delete(file);

        log.Log(new Log
        {
            FileName = Path.GetFileName(file),
            FileOperation = FileOperation.DELETE.ToString()
        });
    }

    private void UpdateIfChanged(string source, string target, string fileName)
    {
        if (!Hash.CompareHash(source, target))
        {
            File.Copy(source, target, overwrite: true);

            log.Log(new Log
            {
                FileName = fileName,
                FileOperation = FileOperation.UPDATE.ToString()
            });
        }
    }

    private void WriteFile(string source, string target, string fileName)
    {
        File.Copy(source, target, overwrite: false);

        log.Log(new Log
        {
            FileName = fileName,
            FileOperation = FileOperation.WRITE.ToString()
        });
    }
}