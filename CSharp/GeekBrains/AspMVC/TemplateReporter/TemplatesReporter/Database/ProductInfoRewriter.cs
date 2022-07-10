using TemplateReporter.Data;

using TemplatesReporter.Import;

namespace TemplatesReporter.Database;

public class ProductInfoRewriter : IRewriter<RawProductInfo, ProductInfo>
{
    public void Rewrite(RawProductInfo data, ProductInfo rewritable)
    {
        rewritable.Segment = data.Segment;
        rewritable.Country = data.Country;
        rewritable.Product = data.Product;
        rewritable.UnitsSold = data.UnitsSold;
        rewritable.ManufacturingPrice = data.ManufacturingPrice;
        rewritable.SalePrice = data.SalePrice;
        rewritable.Date = data.Date;
    }
}