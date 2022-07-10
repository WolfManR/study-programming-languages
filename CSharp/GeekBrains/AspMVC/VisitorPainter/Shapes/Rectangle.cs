namespace VisitorPainter.Shapes;

internal class Rectangle : Shape
{
    public int Width { get; set; }
    public int Height { get; set; }
    public int X { get; set; }

    public Rectangle()
    {
        Width = 20;
        Height = 4;
        X = 8;
    }

    public override void Apply(Drawer drawer)
    {
        drawer.DrawRectangle(this);
    }
}