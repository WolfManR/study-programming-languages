namespace Figures.Core;

internal sealed class Circle : Point
{
    private IEnumerable<Point> Paint { get; }

    public double Radius { get; set; }
    public double Thickness { get; set; }
    public double Square()
    {
        return Math.PI * Radius * 2;
    }

    public override void Draw()
    {
        PrintAndReset(() =>
        {
            var radius = Radius;
            var thickness = Thickness;
            double rIn = radius - thickness;
            double rOut = radius + thickness;
            double doubleRIn = rIn * rIn;
            double doubleROut = rOut * rOut;

            var posX = X;
            var posY = Y;
            Console.SetCursorPosition(posX, posY);
            Console.ForegroundColor = Color.ToConsoleColor();

            for (double y = radius; y >= -radius; --y)
            {
                for (double x = -radius; x < rOut; x += 0.5)
                {
                    double value = x * x + y * y;
                    if (value >= doubleRIn && value <= doubleROut)
                    {
                        Console.Write(Symbol);
                    }
                    else
                    {
                        Console.CursorLeft++;
                    }
                }
                Console.SetCursorPosition(posX, ++posY);
            }
        });
    }
}