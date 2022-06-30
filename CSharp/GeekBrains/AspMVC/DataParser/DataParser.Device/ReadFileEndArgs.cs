namespace DataParser.Device;

public class ReadFileEndArgs : EventArgs
{
    public ReadFileEndArgs(string filePath)
    {
        FilePath = filePath;
    }

    public string FilePath { get; }
}