namespace sync.Logger;

public class LogFile : Dictionary<string, Timestamp>
{
}

public class Timestamp
{
    public string FileName { get; set; } = String.Empty;
    public string Operation { get; set; }  = String.Empty;
}