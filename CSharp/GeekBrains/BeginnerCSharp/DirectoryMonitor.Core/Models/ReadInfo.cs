namespace DirectoryMonitor.Core.Models;

/// <summary>
/// Info about file
/// </summary>
public record ReadInfo
{
    public string FileName { get; init; }
    public DateTime LastAccessTime { get; set; }
    public DateTime LastWriteTime { get; set; }
    public long Length { get; init; }
    public string Path { get; init; }
};