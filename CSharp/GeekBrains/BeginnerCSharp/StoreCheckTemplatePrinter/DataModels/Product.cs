namespace StoreCheckTemplatePrinter.DataModels;

record Product
{
    public string Name { get; init; }
    public decimal Price { get; init; }
    public decimal NDS { get; init; }
}