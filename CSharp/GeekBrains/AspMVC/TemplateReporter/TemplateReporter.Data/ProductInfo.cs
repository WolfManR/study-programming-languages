namespace TemplateReporter.Data;

public record ProductInfo
{
    public string Segment { get; set; }
    public string Country { get; set; }
    public string Product { get; set; }
    public double UnitsSold { get; set; }
    public decimal ManufacturingPrice { get; set; }
    public decimal SalePrice { get; set; }
    public DateTime Date { get; set; }
}