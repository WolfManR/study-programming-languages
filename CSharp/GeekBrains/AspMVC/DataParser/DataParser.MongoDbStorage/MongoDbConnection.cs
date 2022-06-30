using MongoDB.Driver;

namespace DataParser.MongoDbStorage;

public sealed class MongoDbConnection
{
    private readonly IMongoDatabase _database;

    public MongoDbConnection(string connectionString, string database)
    {
        var mongoClient = new MongoClient(connectionString);
        _database = mongoClient.GetDatabase(database);
    }

    public IMongoCollection<T> GetCollection<T>(string name)
    {
        var collection = _database.GetCollection<T>(name.ToLowerInvariant(), new MongoCollectionSettings() { AssignIdOnInsert = true });
        return collection;
    }
}