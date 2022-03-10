namespace Figures.Core;

internal sealed class Color
{
    public byte Red { get; set; }
    public byte Green { get; set; }
    public byte Blue { get; set; }

    public ConsoleColor ToConsoleColor()
    {
        return (Red, Green, Blue) switch
               {
                   (0, 0, 0)              => ConsoleColor.Black,
                   (255, 255, 255)        => ConsoleColor.White,
                   ( < 20, < 20, < 20)    => ConsoleColor.DarkGreen,
                   ( < 70, < 70, < 70)    => ConsoleColor.Blue,
                   ( < 140, < 140, < 140) => ConsoleColor.DarkRed,
                   _                      => ConsoleColor.Magenta
               };
    }
}