using MongoDB.Driver;

namespace TemplatesReporter.Database;

public class DatabaseConnection
{
    private readonly IMongoDatabase _database;

    public DatabaseConnection(string connectionString, string database)
    {
        MongoClient client = new(connectionString);
        _database = client.GetDatabase(database);
    }

    public IMongoCollection<TModel> Set<TModel>(string collectionName)
    {
        return _database.GetCollection<TModel>(collectionName);
    }
}