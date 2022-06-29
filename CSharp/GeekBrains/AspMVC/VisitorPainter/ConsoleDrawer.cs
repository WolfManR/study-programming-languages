using VisitorPainter.Shapes;

namespace VisitorPainter;

internal class ConsoleDrawer : Drawer
{
    private readonly char _symbol;

    public ConsoleDrawer(char symbol)
    {
        _symbol = symbol;
    }

    public override void DrawRectangle(Rectangle rectangle)
    {
        string s = _symbol.ToString();
        string space = "";
        string temp = "";
        for (int i = 0; i < rectangle.Width; i++)
        {
            space += " ";
            s += _symbol;
        }

        for (int j = 0; j < rectangle.X; j++)
            temp += " ";

        s += _symbol + "\n";

        for (int i = 0; i < rectangle.Height; i++)
            s += temp + _symbol + space + _symbol + "\n";

        s += temp + _symbol;
        for (int i = 0; i < rectangle.Width; i++)
            s += "═";

        s += _symbol + "\n";

        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.CursorLeft = rectangle.X;
        Console.Write(s);
        Console.ResetColor();
    }

    public override void DrawCircle(Circle circle)
    {
        var radius = circle.Radius;
        var thickness = circle.Thickness;
        double rIn = radius - thickness, rOut = radius + thickness;

        for (double y = radius; y >= -radius; --y)
        {
            for (double x = -radius; x < rOut; x += 0.5)
            {
                double value = x * x + y * y;
                if (value >= rIn * rIn && value <= rOut * rOut)
                {
                    Console.Write(_symbol);
                }
                else
                {
                    Console.Write(" ");
                }
            }
            Console.WriteLine();
        }
    }
}