using DataSerializer.Data;

namespace DataSerializer.Deserializers.Strategies;

public abstract class DeserializeStrategy
{
    public abstract IEnumerable<OutputData> Deserialize(string data);
}