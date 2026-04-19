namespace sync.DataManagement;

public class LogsManagement(Config config)
{
	public void ReadLogs()
	{
		var logFilePath = config.LogFilePath;

		if (!File.Exists(logFilePath))
		{
			Console.WriteLine($"No log file found at: {logFilePath}");
			return;
		}

		var content = File.ReadAllText(logFilePath);
		if (string.IsNullOrWhiteSpace(content))
		{
			Console.WriteLine("Log file is empty.");
			return;
		}

		Console.WriteLine(content);
	}
}