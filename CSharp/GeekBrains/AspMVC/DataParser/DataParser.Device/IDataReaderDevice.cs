namespace DataParser.Device;

public interface IDataReaderDevice : IDisposable
{
    event Action<IDataReaderDevice, ReadChunkArgs> OnDataReady;
    event Action<IDataReaderDevice, ReadFileEndArgs> OnFileReadEnd;

    public double ProcessorLoad { get; }
    public double MemoryLoad { get; }
    int BufferSize { get; set; }
    bool IsReadFile { get; }
    Guid Id { get; }

    void ReadFile(string filePath);
}