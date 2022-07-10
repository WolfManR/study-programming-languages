namespace DataParser.Client;

public interface IDataSaveStrategy
{
    DataSaveResult SaveData(object data);
}