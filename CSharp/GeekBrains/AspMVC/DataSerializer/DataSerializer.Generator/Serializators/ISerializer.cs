namespace DataSerializer.Generator.Serializators;

public interface ISerializer
{
    string Serialize<T>(List<T> data);
}