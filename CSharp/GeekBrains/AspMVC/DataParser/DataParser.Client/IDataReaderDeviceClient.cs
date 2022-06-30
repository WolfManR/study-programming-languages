using DataParser.Device;

namespace DataParser.Client;

public interface IDataReaderDeviceClient
{
    IDataSaveStrategy DataSaveStrategy { get; set; }

    void ConnectDevice(IDataReaderDevice scanSpamDevice);
    void DisconnectDevice(IDataReaderDevice scanSpamDevice);
    void StartReadFile(IDataReaderDevice scanSpamDevice, string filePath);
}