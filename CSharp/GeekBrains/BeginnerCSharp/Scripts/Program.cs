using System.Globalization;

using static System.Console;

MergeFIOInToFullName();
ParseInputNumbers();
PrintCurrentYearSeasonByMonthNumber();
CalculateFibonacciNumber();


static void MergeFIOInToFullName()
{
    (string firstName, string lastName, string patronimic)[] array = {
        ("Elena","Sakurdina","Petrova"),
        ("Petr","Kadrovich","Alexandovich"),
        ("Vasiliy","Pupkin","Valilievich"),
        ("Alexandra","Cyrilenko","Sergeevna")
    };

    for (var i = 0; i < array.Length; i++)
        WriteLine(GetFullName(array[i].firstName, array[i].lastName, array[i].patronimic));
}

static string GetFullName(string firstName, string lastName, string patronymic) =>
    $"{firstName} {lastName} {patronymic}";


static void ParseInputNumbers()
{
    WriteLine(@"Input numbers in one line, separating with ',', 
if you input float number to separate float's number's from integer's use '.' instead of ','");
    var input = ReadLine();

    if (input is null)
    {
        WriteLine("Incorrect input");
        return;
    }

    if (!TryParseInputToDecimals(input, out var result, out var incorrectNumber))
    {
        WriteLine($"Incorrect input in number {incorrectNumber}");
        return;
    }

    decimal sum = 0;
    for (var i = 0; i < result.Length; i++)
        sum += result[i];

    WriteLine($"Sum of number's is  {sum:f4}");
}

static bool TryParseInputToDecimals(string input, out decimal[] result, out string incorrectNumber)
{
    const NumberStyles style = NumberStyles.AllowDecimalPoint;
    CultureInfo culture = CultureInfo.InvariantCulture;
    incorrectNumber = "";
    result = Array.Empty<decimal>();
    var temp = new List<decimal>();

    var numberStrings = input.Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
    for (var i = 0; i < numberStrings.Length; i++)
    {
        if (!decimal.TryParse(numberStrings[i], style, culture, out var number))
        {
            incorrectNumber = numberStrings[i];
            return false;
        }
        temp.Add(number);
    }

    result = temp.ToArray();
    return true;
}

static void PrintCurrentYearSeasonByMonthNumber()
{
    WriteLine("input your current month number");
    var input = ReadLine().AsSpan();

    if (!int.TryParse(input, out var monthNumber))
    {
        WriteLine("Incorrect input");
        return;
    }

    if (monthNumber is < 1 or > 12)
    {
        WriteLine("Incorrect input, needed number must be in [1..12]");
        return;
    }

    var season = monthNumber switch
                 {
                     12 or <= 2 => "Winter",
                     <= 5       => "Spring",
                     <= 7       => "Summer",
                     _          => "Autumn"
                 };
    WriteLine($"Current season is {season}");
}

static void CalculateFibonacciNumber()
{
    WriteLine("Input a number for calculating it's fibonacci");
    var input = ReadLine().AsSpan();

    if (!int.TryParse(input, out var n))
    {
        WriteLine("incorrect number");
        return;
    }

    WriteLine($"Fibonacci of {n} is {Fibonacci(n)}");
}

static int Fibonacci(int n) =>
    n switch
    {
        0 => 0,
        1 => 1,
        _ => Fibonacci(n - 1) + Fibonacci(n - 2)
    };