using DataParser.Device;

namespace DataParser.Client;

public class DataReaderDeviceClient : IDataReaderDeviceClient
{
    private readonly ILogger _logger;
    private readonly IEnumerable<ParseHandler> _parseHandlers;

    private static Dictionary<Guid, ReadingState> ReadingStates { get; set; }
    public IDataSaveStrategy DataSaveStrategy { get; set; }

    public DataReaderDeviceClient(ILogger logger, IEnumerable<ParseHandler> parseHandlers)
    {
        _logger = logger;
        _parseHandlers = parseHandlers;
        ReadingStates ??= new Dictionary<Guid, ReadingState>();
    }

    public void ConnectDevice(IDataReaderDevice scanSpamDevice)
    {
        if (!ReadingStates.ContainsKey(scanSpamDevice.Id))
        {
            ReadingStates.TryAdd(scanSpamDevice.Id, new ReadingState());
        }

        scanSpamDevice.OnFileReadEnd += DataReaderDeviceOnOnFileReadEnd;
        scanSpamDevice.OnDataReady += DataReaderDeviceOnOnDataReady;
    }

    public void DisconnectDevice(IDataReaderDevice scanSpamDevice)
    {
        scanSpamDevice.OnFileReadEnd -= DataReaderDeviceOnOnFileReadEnd;
        scanSpamDevice.OnDataReady -= DataReaderDeviceOnOnDataReady;
    }

    public void StartReadFile(IDataReaderDevice scanSpamDevice, string filePath)
    {
        scanSpamDevice.ReadFile(filePath);
    }

    private void DataReaderDeviceOnOnFileReadEnd(IDataReaderDevice sender, ReadFileEndArgs e)
    {
        _logger?.Log($"File read end on path {e.FilePath}");
        if (ReadingStates.TryGetValue(sender.Id, out var state))
        {
            state.Reset();
        }
    }

    private void DataReaderDeviceOnOnDataReady(IDataReaderDevice sender, ReadChunkArgs e)
    {
        _logger?.Log($"Device process load: {sender.ProcessorLoad}, memory load: {sender.MemoryLoad}");

        if (DataSaveStrategy is null)
        {
            DisconnectDevice(sender);
            throw new InvalidOperationException("First set data save strategy");
        }

        object parsedData = null;

        ReadingState state = ReadingStates[sender.Id];
        state.AppendData(e.Chunk);
        var dataToParse = state.PeekData();

        if (state.AwaitingDataParseHandler is { } parseHandler)
        {
            var (canParse, enoughDataToParse) = parseHandler.CanParse(dataToParse);
            if (canParse && enoughDataToParse)
            {
                parsedData = parseHandler.Parse(dataToParse, out var parsedDataSize);
                state.RemoveParsedData(parsedDataSize);
            }
        }
        else
        {
            foreach (var handler in _parseHandlers)
            {
                var (canParse, enoughDataToParse) = handler.CanParse(dataToParse);
                if (!canParse) continue;
                if (enoughDataToParse)
                {
                    parsedData = handler.Parse(dataToParse, out var parsedDataSize);
                    state.RemoveParsedData(parsedDataSize);
                    break;
                }

                state.AwaitingDataParseHandler = handler;
                break;
            }

        }

        if (parsedData is not null)
        {
            state.AwaitingDataParseHandler = null;
            DataSaveStrategy.SaveData(parsedData);
        }
    }

    private class ReadingState
    {
        private List<byte> ReadDataCache { get; } = new();
        public ParseHandler AwaitingDataParseHandler { get; set; }

        public void AppendData(byte[] data)
        {
            ReadDataCache.AddRange(data);
        }

        public void RemoveParsedData(int length)
        {
            ReadDataCache.RemoveRange(0, length);
        }

        public byte[] PeekData()
        {
            return ReadDataCache.ToArray();
        }

        public void Reset()
        {
            ReadDataCache.Clear();
        }
    }
}