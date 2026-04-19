using sync.DataManagement;

namespace sync.Logger;
public record Log
{
    public readonly DateTime TimeStamp = DateTime.UtcNow;
    public string FileName {get; set;}

    public string FileOperation
    {
        get => field.ToString();
        set
        {
            if (Enum.TryParse<FileOperation>(value, out var result))
                field = result.ToString();
        }
    }
}