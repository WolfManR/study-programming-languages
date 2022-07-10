namespace DataSerializer.Data;

public record OutputData
{
    public string Name { get; set; }
    public double Width { get; set; }
    public double Height { get; set; }
    public decimal Price { get; set; }
}