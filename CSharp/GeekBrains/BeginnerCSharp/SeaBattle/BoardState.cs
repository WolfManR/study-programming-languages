static class BoardState
{
    public static Random random = new Random();
    public static byte block = 1;
    public static byte empty = 0;
    public static int size = 10;
    public static int fieldActualSize = size - 1;
    public static byte[,] result = new byte[size, size];
}