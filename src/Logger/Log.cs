using sync.FolderManagement;

namespace sync.Logger;
public record Log
{
    public readonly DateTime TimeStamp = DateTime.UtcNow;
    public string FileName {get; set;} = String.Empty;
    public string FileOperation
    {
        get => field.ToString();
        set
        {
            if (Enum.TryParse<FileOperation>(value, out var result))
                field = result.ToString();
        }
    } = String.Empty;
}