public class LogFile : Dictionary<string, Timestamp>
{
}

public class Timestamp
{
    public string FileName { get; set; }
    public string Operation { get; set; }
}