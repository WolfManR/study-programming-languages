using SearchAlgorithms.BackTrackingAlgorithms;

Console.WriteLine("Search ways in matrix");
MatrixSearchAlgorithmTest();

Console.WriteLine("Back track search");
BackTrackSearch.PlaceQueens();

void MatrixSearchAlgorithmTest()
{
    var arr = new int[8, 8];
    arr
        .PrintArray()
        .WaysCount((7, 7), out var matrix1);
    matrix1.PrintArray();


    var blocks = new (int y, int x)[] { (0, 4), (3, 0), (3, 2), (5, 0), (4, 4), (3, 2), (6, 7) };

    var mapWithBlocks = new int[8, 8];
    for (var i = 0; i < blocks.Length; i++)
    {
        var (x, y) = blocks[i];
        mapWithBlocks[y, x] = 1;
    }
    mapWithBlocks.PrintArray();

    arr
        .WaysCount((7, 7), out var matrix2, blocks);
    matrix2.PrintArray();
}