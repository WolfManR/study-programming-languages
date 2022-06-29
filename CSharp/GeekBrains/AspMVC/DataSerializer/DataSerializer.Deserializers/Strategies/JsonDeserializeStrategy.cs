using System.Text.Json;
using DataSerializer.Data;

namespace DataSerializer.Deserializers.Strategies;

public class JsonDeserializeStrategy : DeserializeStrategy
{
    public override IEnumerable<OutputData> Deserialize(string data)
    {
        var result = JsonSerializer.Deserialize<IEnumerable<OutputData>>(data);
        return result;
    }
}