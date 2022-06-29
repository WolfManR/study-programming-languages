using System.Text.Json;

namespace DataSerializer.Generator.Serializators;

public class JsonSerializator : ISerializer
{
    public string Serialize<T>(List<T> data)
    {
        return JsonSerializer.Serialize(data);
    }
}