namespace StoreCheckTemplatePrinter.CheckPrinter;

public class LineBlock : ICheckBlock
{
    private readonly string _line;

    public LineBlock(string line) => _line = line;
    
    public override string ToString() => _line;
}