using DataSerializer.Deserializers.Strategies;

namespace DataSerializer.Deserializers;

public class DeserializeStrategySelector
{
    private readonly List<(Predicate<string> CanHandle, DeserializeStrategy Deserializer)> _parsers;

    public DeserializeStrategySelector(List<(Predicate<string> CanHandle, DeserializeStrategy Deserializer)> parsers)
    {
        _parsers = parsers;
    }

    public DeserializeStrategy SelectDeserializeStrategy(string data)
    {
        if (string.IsNullOrEmpty(data)) return null;

        var dataToParse = data.Trim();

        foreach (var (canHandle, parser) in _parsers)
        {
            if (canHandle(dataToParse)) return parser;
        }

        throw new NotSupportedException("Can't figure out what type of data");
    }
}