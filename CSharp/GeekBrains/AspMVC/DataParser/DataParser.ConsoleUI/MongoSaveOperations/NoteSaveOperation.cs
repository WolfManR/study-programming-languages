using DataParser.Data;
using DataParser.MongoDbStorage;

public sealed class NoteSaveOperation : SaveOperation
{
    private readonly MongoDbConnection _connection;

    public NoteSaveOperation(MongoDbConnection connection)
    {
        _connection = connection;
    }
    
    public override Type OperationType { get; } = typeof(Note);

    public override void Save(object entry)
    {
        if (entry is not Note entity) return;

        _connection.Notes().InsertOne(entity);
    }
}