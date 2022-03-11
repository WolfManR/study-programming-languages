using System.Text;

namespace StoreCheckTemplatePrinter.CheckPrinter;

public class CheckPrinter
{
    private const string checkHeader = "Кассовый чек";
    private const char hd = '-';
    private const string verticalIndent = "\n";

    private readonly int checkWidth = 70;

    private List<string> check = new()
    {
        checkHeader,
        verticalIndent
    };

    public CheckPrinter AppendLine(string line)
    {
        if (line.Length < checkWidth)
        {
            check.Add(line);
            return this;
        }

        StringBuilder sb = new();
        var startPosition = 0;
        var endPosition = checkWidth;
        var counts = line.Length / checkWidth;
        var times = line.Length % checkWidth > 0 ? ++counts : counts;
        for (var i = 0; i < times; i++)
        {
            var cut = line[startPosition..endPosition].Trim();
            if (i - 1 != times) sb.AppendLine(cut);
            else sb.Append(cut);
            startPosition = endPosition;
            endPosition = endPosition + checkWidth > line.Length ? line.Length : endPosition + checkWidth;
        }

        check.Add(sb.ToString());

        return this;
    }
    
    public override string ToString()
    {
        StringBuilder sb = new();
        check.ForEach(s => sb.AppendLine(s));

        return sb.ToString();
    }
}