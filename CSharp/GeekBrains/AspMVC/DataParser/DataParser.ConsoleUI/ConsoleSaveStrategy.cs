using DataParser.Client;

public class ConsoleSaveStrategy : IDataSaveStrategy
{
    public DataSaveResult SaveData(object data)
    {
        // switch data types and ways to save its
        Console.WriteLine(data.ToString());
        return new DataSaveResult();
    }
}