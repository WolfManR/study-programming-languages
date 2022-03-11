using static System.Console;

PrintDiagonalArray();
PrintPhoneBook();
ReverseStringAsCharArray();

static void PrintDiagonalArray()
{
    const byte size = 5;
    var array = new int[size, size];

    // Fill array
    for (var i = 0; i < size; i++)
        for (var j = 0; j < size; j++)
            array[i, j] = i + j;

    // Print array
    for (var i = 0; i < size; i++)
    {
        for (var j = 0; j < size; j++)
            Write(array[i, j] + " ");
        WriteLine();
    }

    WriteLine($"Input Pad from central diagonal, from [-{size - 1}..0..{size - 1}]");
    var input = ReadLine().AsSpan();

    if (!int.TryParse(input, out var number))
    {
        WriteLine("incorrect input");
        return;
    }

    if (number is <= -size or >= size)
    {
        WriteLine("Incorrect number");
        return;
    }

    int normalizedNumber = number < 0 ? Math.Abs(number) : number;
    var times = size - Math.Abs(number);
    //diagonal
    for (int i = 0, j = 0; i < times; i++, j++)
    {
        var output = number switch
        {
            0 => array[i, j],
            < 0 => array[i, j + normalizedNumber],
            _ => array[i + normalizedNumber, j]
        };
        Write(output + " ");
    }
}

static void PrintPhoneBook()
{
    var contacts = new string[5, 2]
    {
        {"Fedor", "+7 934 123 12 34"},
        {"Stepan", "stepan123@gmail.com"},
        {"Ulia", "+5 324 112 33 54"},
        {"Marina", "marina27@mail.bk"},
        {"Alex", "+1 234 456 76 23"},
    };

    for (var i = 0; i < contacts.GetLength(0); i++)
    {
        for (var j = 0; j < contacts.GetLength(1); j++)
            Write(contacts[i, j] + " ");
        WriteLine();
    }
}

static void ReverseStringAsCharArray()
{
    WriteLine("Input something and i reverse it:");
    var input = ReadLine().AsSpan();
    Write("Reversed:\n");
    for (var i = input.Length - 1; i >= 0; i--)
        Write(input[i]);
}