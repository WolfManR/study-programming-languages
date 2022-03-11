namespace StoreCheckTemplatePrinter.DataModels;

record Order
{
    public DateTime BuyTime { get; init; }
    public string SellerName { get; init; }
    public short CheckNumber { get; init; }
    public short Shift { get; init; }
    public Dictionary<Product, int> Products { get; init; }
}