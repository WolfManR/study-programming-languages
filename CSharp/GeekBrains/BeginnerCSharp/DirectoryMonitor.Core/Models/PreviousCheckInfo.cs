namespace DirectoryMonitor.Core.Models;

/// <summary>
/// Information about previous check
/// </summary>
public record PreviousCheckInfo(string CheckPath, DateTime LastCheck);