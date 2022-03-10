using Figures.Core;

List<Figure> figures = new()
{
    new Circle()
    {
        X = 4,
        Y = 2,
        Radius = 2,
        IsVisible = true,
        Symbol = '$',
        Thickness = 2,
        Color = new Color() { Blue = 20, Green = 20, Red = 20 }
    },
    new Rectangle()
    {
        X = 8,
        Y = 10,
        Width = 14,
        Height = 6,
        IsVisible = true,
        Symbol = '#',
        Color = new Color() { Blue = 200, Green = 200, Red = 200 }
    },
    new Circle()
    {
        X = 10,
        Y = 2,
        Radius = 2,
        IsVisible = true,
        Symbol = '$',
        Thickness = 2,
        Color = new Color() { Blue = 40, Green = 40, Red = 40 }
    },
    new Circle()
    {
        X = 6,
        Y = 7,
        Radius = 4,
        IsVisible = true,
        Symbol = '^',
        Thickness = 1,
        Color = new Color() { Blue = 80, Green = 80, Red = 80 }
    },
    new Rectangle()
    {
        X = 2,
        Y = 2,
        Width = 14,
        Height = 10,
        IsVisible = true,
        Symbol = '*',
        Color = new Color() { Blue = 240, Green = 240, Red = 240 }
    },
};

figures
    .PrintFigures()
    .MoveFigures(6, 0)
    .PrintFigures();

Console.SetCursorPosition(0,30);

static class Extensions
{
    public static IEnumerable<Figure> PrintFigures(this IEnumerable<Figure> figures)
    {
        foreach (var figure in figures)
        {
            figure.Draw();
        }

        return figures;
    }

    public static IEnumerable<Figure> MoveFigures(this IEnumerable<Figure> figures, int horizontalOffset, int verticalOffset)
    {
        foreach (var figure in figures)
        {
            figure.MoveHorizontal(horizontalOffset);
            figure.MoveVertical(verticalOffset);
        }

        return figures;
    }
}