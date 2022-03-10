namespace Figures.Core;

internal sealed class Rectangle : Point
{
    private IEnumerable<Point> Paint { get; }

    public int Width { get; set; }
    public int Height { get; set; }

    public double Square()
    {
        return Width * Height;
    }

    public override void Draw()
    {
        PrintAndReset(() =>
        {
            var posX = X;
            var posY = Y;
            var symbol = Symbol;

            var farBorderPosX = posX + Width;

            Console.SetCursorPosition(posX, posY);
            Console.ForegroundColor = Color.ToConsoleColor();

            for (int i = 0; i < Width; i++)
            {
                Console.Write(symbol);
            }

            for (var i = 0; i < Height - 2; i++)
            {
                Console.SetCursorPosition(posX, ++posY);
                Console.Write(symbol);
                Console.SetCursorPosition(farBorderPosX, posY);
                Console.Write(symbol);
            }

            Console.SetCursorPosition(posX, ++posY);

            for (int i = 0; i < Width; i++)
            {
                Console.Write(symbol);
            }
        });
    }
}