namespace VisitorPainter.Shapes;

internal class Circle : Shape
{
    public double Radius { get; set; }
    public double Thickness { get; set; }

    public Circle()
    {
        Radius = 4;
        Thickness = 1;
    }

    public override void Apply(Drawer drawer)
    {
        drawer.DrawCircle(this);
    }
}