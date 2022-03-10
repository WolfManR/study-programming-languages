namespace Figures.Core;

internal class Point : Figure
{
    public char Symbol { get; set; }
    public int X { get; set; }
    public int Y { get; set; }

    public override void MoveHorizontal(int offset)
    {
        X += offset;
    }

    public override void MoveVertical(int offset)
    {
        Y += offset;
    }

    public override void ChangeColor(Color color)
    {
        Color = color;
    }

    public override void Draw()
    {
        PrintAndReset(() =>
        {
            Console.SetCursorPosition(X, Y);
            Console.ForegroundColor = Color.ToConsoleColor();
            Console.Write(Symbol);
        });
    }

    protected virtual void PrintAndReset(Action draw)
    {
        var defaultColor = Console.ForegroundColor;
        var (left, top) = Console.GetCursorPosition();
        draw.Invoke();
        Console.ForegroundColor = defaultColor;
        Console.SetCursorPosition(left, top);
    }
}