namespace SearchAlgorithms.BackTrackingAlgorithms;

public class BackTrackSearch
{
    const int N = 8;
    const int M = 8;
    static int[,] board = new int[N, M];

    public static void PlaceQueens()
    {
        Zero(N, M, board);
        SearchSolution(1);
        Console.WriteLine(" ");
        Print(N, M, board);
    }

    static bool SearchSolution(int n)
    {
        // Если проверка доски возвращает 0, то эта расстановка не подходит
        if (CheckBoard() == 0) return false;
        // 9 ферзя не ставим. Решение найдено
        if (n == 9) return true;
        int row;
        int col;
        for (row = 0; row < N; row++)
            for (col = 0; col < M; col++)
            {
                if (board[row, col] == 0)
                {
                    // Расширяем test_solution
                    board[row, col] = n;
                    // Рекурсивно проверяем, ведёт ли это к решению.
                    if (SearchSolution(n + 1)) return true;
                    // Если мы дошли до этой строки, данное частичное решение
                    // не приводит к полному
                    board[row, col] = 0;
                }
            }

        return false;
    }

    // Проверка всей доски
    static int CheckBoard()
    {
        int i, j;
        for (i = 0; i < N; i++)
            for (j = 0; j < M; j++)
                if (board[i, j] != 0)
                    if (CheckQueen(i, j) == 0)
                        return 0;
        return 1;
    }

    // Проверка определённого ферзя
    static int CheckQueen(int x, int y)
    {
        for (int i = 0; i < N; i++)
            for (int j = 0; j < M; j++)
                // Если нашли фигуру
                if (board[i, j] != 0)
                    if (!(i == x && j == y)) // Если это не наша фигура
                    {
                        // Лежат на одной вертикали или горизонтали
                        if ((i - x) == 0 || (j - y) == 0)
                            return 0;
                        // Лежат на одной диагонали
                        if (Math.Abs(i - x) == Math.Abs(j - y))
                            return 0;
                    }

        // Если мы дошли до этого места, то всё в порядке
        return 1;
    }

    // Выводим доску на экран
    static void Print(int n, int m, int[,] a)
    {
        int i, j;
        for (i = 0; i < n; i++)
        {
            for (j = 0; j < m; j++)
                Console.Write(a[i, j] + " ");
            Console.Write("\n");
        }
    }

    // Очищаем доску
    static void Zero(int n, int m, int[,] a)
    {
        int i, j;
        for (i = 0; i < n; i++)
            for (j = 0; j < m; j++)
                a[i, j] = 0;
    }
}