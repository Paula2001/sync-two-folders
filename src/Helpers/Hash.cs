using System.Security.Cryptography;

namespace sync.Helpers;

public class Hash
{
    private static string GetHash(string filePath)
    {
        using var md5 = MD5.Create();
        using var stream = File.OpenRead(filePath);

        byte[] hash = md5.ComputeHash(stream);
        return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
    }
    
    public static bool CompareHash(string file1, string file2)
    {
        string hash1 = GetHash(file1);
        string hash2 = GetHash(file2);

        return hash1.Equals(hash2);
    }
}