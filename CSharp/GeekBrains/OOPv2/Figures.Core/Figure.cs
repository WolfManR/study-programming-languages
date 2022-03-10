namespace Figures.Core;

internal abstract class Figure
{
    public Color Color { get; set; } = new Color();
    public bool IsVisible { get; set; } = true;

    public abstract void MoveHorizontal(int offset);
    public abstract void MoveVertical(int offset);

    public abstract void ChangeColor(Color color);

    public abstract void Draw();
}