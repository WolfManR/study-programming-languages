namespace DataParser.MongoDbStorage;

public abstract class SaveOperation
{
    public abstract Type OperationType { get; }
    public abstract void Save(object entry);
}