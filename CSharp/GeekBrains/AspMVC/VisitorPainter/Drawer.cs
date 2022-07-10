using VisitorPainter.Shapes;

namespace VisitorPainter;

internal abstract class Drawer
{
    public abstract void DrawRectangle(Rectangle rectangle);
    public abstract void DrawCircle(Circle circle);
}