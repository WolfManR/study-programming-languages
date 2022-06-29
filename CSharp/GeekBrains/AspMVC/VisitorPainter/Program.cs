using VisitorPainter;
using VisitorPainter.Shapes;

Console.WriteLine("Chose a shape");
var shapes = new (string name, Func<Shape> ctor)[]
{
    ("Rectangle", () => new Rectangle()),
    ("Circle", () => new Circle())
};

for (var i = 0; i < shapes.Length; i++)
{
    Console.WriteLine($"{i + 1}. {shapes[i].name}");
}

var shapeNumber = GetInteger(1, shapes.Length, "Choose number of shape");

var shape = shapes[shapeNumber - 1].ctor();

var drawer = new ConsoleDrawer('*');

shape.Apply(drawer);

Console.ReadLine();


int GetInteger(int min, int max, string repeatMessage)
{
    while (true)
    {
        var input = Console.ReadLine();
        if (int.TryParse(input, out var number) && number >= min && number <= max)
        {
            return number;
        }

        Console.WriteLine(repeatMessage);
    }
}