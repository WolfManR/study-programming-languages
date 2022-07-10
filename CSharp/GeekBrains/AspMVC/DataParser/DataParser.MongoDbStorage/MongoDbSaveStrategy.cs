using DataParser.Client;

namespace DataParser.MongoDbStorage;

public class MongoDbSaveStrategy : IDataSaveStrategy
{
    private readonly Dictionary<Type, SaveOperation> _saveOperations;

    public MongoDbSaveStrategy(IEnumerable<SaveOperation> saveOperations)
    {
        _saveOperations = saveOperations.ToDictionary(o => o.OperationType);
    }

    public DataSaveResult SaveData(object data)
    {
        if (!_saveOperations.TryGetValue(data.GetType(), out var saveOperation)) return new DataSaveResult(false);
        saveOperation.Save(data);
        return new DataSaveResult();
    }
}