using System.Text;
using System.Xml.Serialization;

namespace DataSerializer.Generator.Serializators;

public class XMLSerializator : ISerializer
{
    public string Serialize<T>(List<T> data)
    {
        StringBuilder sb = new();
        TextWriter writer = new StringWriter(sb);
        XmlSerializer ser = new(data.GetType());
        ser.Serialize(writer, data);

        return sb.ToString();
    }
}