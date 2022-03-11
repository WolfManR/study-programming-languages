using System.Globalization;

using static System.Console;

CalculateAverageDayTemperatureAndPrintIt();
PrintMonthNameByItNumber();
InputNumberEvenOrOdd();

static void CalculateAverageDayTemperatureAndPrintIt()
{
    const string inputMessage = "Please input {0} Temperature of the day";
    const string notCorrectMessage = "{0} temperature not correct";

    WriteLine(inputMessage, "minimum");
    var minimalTemperature = ReadLine().AsSpan();
    if (!float.TryParse(minimalTemperature, out var min))
    {
        WriteLine(notCorrectMessage, "Minimum");
        return;
    }

    WriteLine(inputMessage, "maximum");
    var maximumTemperature = ReadLine().AsSpan();
    if (!float.TryParse(maximumTemperature, out var max))
    {
        WriteLine(notCorrectMessage, "Maximum");
        return;
    }

    var averageTemperature = (min + max) / 2;
    WriteLine($"The average daily temperature is {averageTemperature}");
}

static void PrintMonthNameByItNumber()
{
    const string incorrectMonthMessage = "Not correct month number";

    WriteLine("Please input number of the current month");
    var monthNumber = ReadLine().AsSpan();

    if (!int.TryParse(monthNumber, out var number))
    {
        WriteLine(incorrectMonthMessage);
        return;
    }

    if (number is <= 0 or > 12)
    {
        WriteLine(incorrectMonthMessage);
        return;
    }

    var date = new DateTime(2021, number, 1);

    WriteLine($"Current month name is {date.ToString("MMMM", CultureInfo.CurrentCulture)}");
}

static void InputNumberEvenOrOdd()
{
    WriteLine("Please input number");
    var userNumber = ReadLine().AsSpan();

    if (!int.TryParse(userNumber, out var number))
    {
        WriteLine("Not Correct input");
        return;
    }

    WriteLine("Your number is {0}", number % 2 == 0 ? "even" : "odd");
}