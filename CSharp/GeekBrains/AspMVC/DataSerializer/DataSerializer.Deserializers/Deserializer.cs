using DataSerializer.Data;
using DataSerializer.Deserializers.Strategies;

namespace DataSerializer.Deserializers;

public class Deserializer
{
    public IEnumerable<OutputData> Deserialize(string data, DeserializeStrategy parseStrategy)
    {
        return parseStrategy.Deserialize(data);
    }
}