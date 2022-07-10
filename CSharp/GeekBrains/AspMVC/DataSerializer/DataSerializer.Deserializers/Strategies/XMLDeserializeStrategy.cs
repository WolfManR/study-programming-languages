
using System.Xml;
using System.Xml.Linq;
using DataSerializer.Data;

namespace DataSerializer.Deserializers.Strategies;

public class XMLDeserializeStrategy : DeserializeStrategy
{
    public XMLDeserializeStrategy(List<SearchDataHelper> searchDataHelpers, Dictionary<Type, Func<string, object>> converters)
    {
        SearchDataHelpers = searchDataHelpers;
        Converters = converters;
    }
    private List<SearchDataHelper> SearchDataHelpers { get; }
    private Dictionary<Type, Func<string, object>> Converters { get; }

    public override IEnumerable<OutputData> Deserialize(string data)
    {
        using var reader = new StringReader(data);

        using var xmlReader = XmlReader.Create(reader);

        var helper = FindHelper(xmlReader);
        if (helper is null) yield break;

        do
        {
            XElement xElement = (XElement)XNode.ReadFrom(xmlReader);
            Dictionary<string, object> propertiesValues = new Dictionary<string, object>();
            foreach (var property in helper.Properties)
            {
                var (success, value) = FindValue(xElement, property.PathParts);
                if (!success) continue;
                if (!Converters.TryGetValue(property.ValueType, out var converter)) continue;
                propertiesValues.Add(property.AssignPropertyName, converter.Invoke(value));
            }

            OutputData temp = new OutputData()
            {
                Name = propertiesValues[nameof(OutputData.Name)] as string,
                Width = propertiesValues[nameof(OutputData.Width)] is double width ? width : default,
                Height = propertiesValues[nameof(OutputData.Height)] is double height ? height : default,
                Price = propertiesValues[nameof(OutputData.Price)] is decimal price ? price : default
            };

            yield return temp;
        } while (xmlReader.ReadToNextSibling(helper.DataName));

        xmlReader.ReadEndElement();
    }

    private static (bool, string) FindValue(XElement searchElement, string[] pathParts)
    {
        foreach (var path in pathParts)
        {
            if (searchElement.Element(path) is not { } element) return (false, null);
            searchElement = element;
        }
        return (true, searchElement.Value);
    }

    private SearchDataHelper FindHelper(XmlReader reader)
    {
        foreach (var helper in SearchDataHelpers)
        {
            if (reader.ReadToFollowing(helper.DataName))
            {
                return helper;
            }
        }
        return null;
    }
}