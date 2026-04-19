namespace sync;

public class Config
{
    private const string DataFolder = "./data";
    private const string LogFolder = "./logs";
    public string SourceFolder {
        get => Path.Combine(Config.DataFolder, field); 
        set;
    } = "source";
    public string TargetFolder {
        get => Path.Combine(Config.DataFolder, field); 
        set;
    } = "replica";
    public string LogFilePath {
        get => Path.Combine(Config.LogFolder, string.Concat(field, ".json")); 
        set;
    }  = "logs";
    public int TimeIntervalInSeconds {get; set;} = 1;
}