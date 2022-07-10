using DataParser.Data;
using DataParser.MongoDbStorage;
using MongoDB.Driver;

public static class MongoDbExtensions
{
    public static IMongoCollection<Image> Images(this MongoDbConnection self) => self.GetCollection<Image>(nameof(Image));
    public static IMongoCollection<Note> Notes(this MongoDbConnection self) => self.GetCollection<Note>(nameof(Note));
}