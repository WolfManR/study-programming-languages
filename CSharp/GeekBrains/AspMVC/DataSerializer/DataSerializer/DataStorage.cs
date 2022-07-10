using DataSerializer.Data;

internal class DataStorage
{
    private readonly List<OutputData> _storage = new();

    public void AddRange(IEnumerable<OutputData> data)
    {
        _storage.AddRange(data);
    }

    public IReadOnlyCollection<OutputData> GetData()
    {
        return _storage;
    }
}