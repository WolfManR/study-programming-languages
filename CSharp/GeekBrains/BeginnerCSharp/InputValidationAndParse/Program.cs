using System.Globalization;

using static System.Console;

if (TryCalculateAverageDayTemperature(out var averageTemperature) && TryGetMonthNumber(out var monthNumber))
{
    if (monthNumber is 12 or <= 2 && averageTemperature > 0)
        WriteLine("It's rainy winter today");

    WriteLine($"The average daily temperature is {averageTemperature}");
    var date = new DateTime(2021, monthNumber, 1);
    WriteLine($"Current month name is {date.ToString("MMMM", CultureInfo.CurrentCulture)}");
}

InputNumberEvenOrOdd();

static bool TryCalculateAverageDayTemperature(out float averageTemperature)
{
    averageTemperature = default;
    const string inputMessage = "Please input {0} Temperature of the day";
    const string notCorrectMessage = "{0} temperature not correct";

    WriteLine(inputMessage, "minimum");
    var minimalTemperature = ReadLine().AsSpan();
    if (!float.TryParse(minimalTemperature, out var min))
    {
        WriteLine(notCorrectMessage, "Minimum");
        return false;
    }

    WriteLine(inputMessage, "maximum");
    var maximumTemperature = ReadLine().AsSpan();
    if (!float.TryParse(maximumTemperature, out var max))
    {
        WriteLine(notCorrectMessage, "Maximum");
        return false;
    }

    averageTemperature = (min + max) / 2;
    return true;
}

static bool TryGetMonthNumber(out int monthNumber)
{
    const string incorrectMonthMessage = "Not correct month number";

    WriteLine("Please input number of the current month");
    var monthNumberInput = ReadLine().AsSpan();

    if (!int.TryParse(monthNumberInput, out monthNumber))
    {
        WriteLine(incorrectMonthMessage);
        return false;
    }

    if (monthNumber is > 0 and <= 12) return true;

    WriteLine(incorrectMonthMessage);
    return false;

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