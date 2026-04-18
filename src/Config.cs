namespace sync;

public class Config
{
    public const string DataFolder = "./Data/";
    public string SourceFolder {
        get => Path.Combine(Config.DataFolder, field); 
        set;
    } = "source";
    public string TargetFolder {
        get => Path.Combine(Config.DataFolder, field); 
        set;
    } = "target";
    public string LogFilePath {
        get => Path.Combine(Config.DataFolder, field); 
        set;
    }  = "./logs";
    public int TimeIntervalInSeconds {get; set;} = 1;
}