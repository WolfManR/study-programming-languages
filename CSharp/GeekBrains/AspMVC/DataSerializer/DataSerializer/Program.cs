using DataSerializer.Deserializers;
using DataSerializer.Deserializers.Strategies;
using DataSerializer.Generator;
using DataSerializer.Generator.Serializators;

using System.Globalization;
using DataSerializer.Data;

List<SearchDataHelper> SearchDataHelpers = new()
{
    new()
    {
        DataName = "Sofa",
        Properties = new List<XmlProperty>()
        {
            new(nameof(OutputData.Name), "Name", typeof(string)),
            new(nameof(OutputData.Width), "Size.Width", typeof(double)),
            new(nameof(OutputData.Height), "Size.Height", typeof(double)),
            new(nameof(OutputData.Price), "Price", typeof(decimal))
        }
    }
};

Dictionary<Type, Func<string, object>> Converters = new()
{
    [typeof(string)] = s => s,
    [typeof(double)] = s => double.TryParse(s, NumberStyles.AllowDecimalPoint, new NumberFormatInfo(), out var result) ? result : default(object),
    [typeof(decimal)] = s => decimal.TryParse(s, NumberStyles.AllowDecimalPoint, new NumberFormatInfo(), out var result) ? result : default(object),
};

List<(Predicate<string>, DeserializeStrategy)> Deserializers = new()
{
    (s => (s.StartsWith('[') && s.EndsWith(']')) || (s.StartsWith('{') && s.EndsWith('}')), new JsonDeserializeStrategy()),
    (s => s.StartsWith("<?xml") && s.EndsWith(">"), new XMLDeserializeStrategy(SearchDataHelpers, Converters)),
};

DataGenerator generator = new();
Deserializer parser = new Deserializer();
DeserializeStrategySelector strategySelector = new DeserializeStrategySelector(Deserializers);
DataStorage storage = new DataStorage();

ISerializer serializer = new JsonSerializator();

var chairs = generator.GetChairs(serializer, 2);
var parsedData = parser.Deserialize(chairs, strategySelector.SelectDeserializeStrategy(chairs));
storage.AddRange(parsedData);

serializer = new XMLSerializator();

var sofas = generator.GetSofas(serializer, 5);
parsedData = parser.Deserialize(sofas, strategySelector.SelectDeserializeStrategy(sofas));
storage.AddRange(parsedData);

foreach (var data in storage.GetData())
    Console.WriteLine(data);