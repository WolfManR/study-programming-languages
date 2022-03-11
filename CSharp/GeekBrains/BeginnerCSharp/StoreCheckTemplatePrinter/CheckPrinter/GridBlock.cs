using System.Text;

namespace StoreCheckTemplatePrinter.CheckPrinter;

public class GridBlock : ICheckBlock
{
    private int columns;
    private int maxWidth;

    private List<string[]> gridRows;

    public GridBlock(int columns, int maxWidth)
    {
        this.columns = columns;
        this.maxWidth = maxWidth;
    }

    public GridBlock AppendRow(string[] row)
    {
        if (row.Length != columns) throw new ArgumentException("Must be declared all columns");
        gridRows.Add(row);

        return this;
    }

    private int DetectMaxColumnWidth(string[] column)
    {

        return 0;
    }

    public override string ToString()
    {
        StringBuilder sb = new();
        foreach (var row in gridRows)
        {

        }

        return "";
    }
}