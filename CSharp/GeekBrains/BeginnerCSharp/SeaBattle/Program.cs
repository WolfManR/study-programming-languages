using static System.Console;

ClearBoard();

var isAllShipsPlaced = false;
bool isFailure = false;

do
{
    var shipSize = 4;
    var shipCount = 1;
    for (var i = 0; i < 4; i++)
    {
        for (var j = 0; j < shipCount; j++)
        {
            var direction = Direction.Left;
            // Direction.Up,
            // Direction.Right,
            // Direction.Down


            var horizontal = direction switch
                             {
                                 Direction.Left  => BoardState.random.Next(shipSize - 1, 9),
                                 Direction.Right => BoardState.random.Next(9 - shipSize + 1),
                                 _               => BoardState.random.Next(9)
                             };

            var vertical = direction switch
                           {
                               Direction.Up   => BoardState.random.Next(shipSize - 1, 9),
                               Direction.Down => BoardState.random.Next(9 - shipSize + 1),
                               _              => BoardState.random.Next(9)
                           };

            if (!CheckShipPlace(direction, vertical, horizontal, shipSize))
            {
                isFailure = true;
                break;
            }


            if (!PlaceShip(direction, vertical, horizontal, shipSize))
            {
                isFailure = true;
                break;
            }

            WriteLine($"ship size {shipSize}\n");
        }

        if (isFailure) break;
        shipCount++;
        shipSize--;
    }

    if (isFailure)
    {
        WriteLine($"ship size {shipSize}\n");
        isFailure = false;
        ClearBoard();
    }
    else
    {
        isAllShipsPlaced = true;
    }
} while (!isAllShipsPlaced);

PrintBoard();

//==============================================================================================================

static void ClearBoard()
{
    for (var i = 0; i < BoardState.size; i++)
        for (var j = 0; j < BoardState.size; j++)
            BoardState.result[i, j] = BoardState.empty;
}

static void PrintBoard()
{
    Clear();
    for (var i = 0; i < BoardState.size; i++)
    {
        for (var j = 0; j < BoardState.size; j++)
        {
            Write(BoardState.result[i, j] + " ");
        }

        WriteLine();
    }

    Thread.Sleep(100);
}

static bool PlaceShip(Direction direction, int vertical, int horizontal, int shipSize)
{
    do
    {
        BoardState.result[vertical, horizontal] = BoardState.block;
        switch (direction)
        {
            case Direction.Up:
                if (horizontal - 1 < 0) return false;
                horizontal--;
                break;
            case Direction.Down:
                if (horizontal + 1 >= 9) return false;
                horizontal++;
                break;
            case Direction.Left:
                if (vertical - 1 < 0) return false;
                vertical--;
                break;
            case Direction.Right:
                if (vertical + 1 >= 9) return false;
                vertical++;
                break;
        }
    } while (--shipSize > 0);

    return true;
}

static bool CheckPoint(int vertical, int horizontal)
{
    List<byte> checkArray = new List<byte>();
    var downVert = vertical - 1;
    var upVert = vertical + 1;
    var downHor = horizontal - 1;
    var upHor = horizontal + 1;

    try
    {
        if (downVert >= 0 && downHor >= 0) checkArray.Add(BoardState.result[downVert, downHor]);
        if (downHor >= 0) checkArray.Add(BoardState.result[vertical, downHor]);
        if (upVert <= BoardState.fieldActualSize && downHor >= 0) checkArray.Add(BoardState.result[upVert, downHor]);
        if (upVert <= BoardState.fieldActualSize) checkArray.Add(BoardState.result[upVert, horizontal]);
        if (upVert <= BoardState.fieldActualSize && upHor <= BoardState.fieldActualSize) checkArray.Add(BoardState.result[upVert, upHor]);
        if (upHor <= BoardState.fieldActualSize) checkArray.Add(BoardState.result[vertical, upHor]);
        if (downVert >= 0 && upHor <= BoardState.fieldActualSize) checkArray.Add(BoardState.result[downVert, upHor]);
        if (downVert >= 0) checkArray.Add(BoardState.result[downVert, horizontal]);
    }
    catch (Exception)
    {
        WriteLine($"vertical {vertical}, horizontal {horizontal}");
        throw;
    }


    for (var i = 0; i < checkArray.Count; i++)
    {
        if (checkArray[i] == BoardState.block)
            return false;
    }

    return true;
}

static bool CheckShipPlace(Direction direction, int x, int y, int shipSize)
{
    if (BoardState.result[x, y] == BoardState.block) return false;
    switch (direction)
    {
        case Direction.Up:
            for (var i = 0; i < shipSize; i++)
            {
                if (y + i > BoardState.fieldActualSize) return false;
                if (!CheckPoint(x, y += i)) return false;
            }

            return true;
        case Direction.Down:
            for (var i = 0; i < shipSize; i++)
            {
                if (y - i < 0) return false;
                if (!CheckPoint(x, y -= i)) return false;
            }

            return true;
        case Direction.Left:
            for (var i = 0; i < shipSize; i++)
            {
                if (x - i < 0) return false;
                if (!CheckPoint(x -= i, y)) return false;
            }

            return true;
        case Direction.Right:
            for (var i = 0; i < shipSize; i++)
            {
                if (x + i < BoardState.fieldActualSize) return false;
                if (!CheckPoint(x += i, y)) return false;
            }

            return true;
        default:
            return false;
    }
}