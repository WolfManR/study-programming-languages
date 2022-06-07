namespace SimpleAlgorithms;

public class PrimeNumberTest
{
    private static bool IsPrimeNumber(int n)
    {
        var d = 0;
        var i = 2;

        while (i < n)
        {
            if (n % i == 0)
                d++;
            i++;
        }

        return d == 0;
    }

    [Theory]
    [InlineData(2, true)]
    [InlineData(12, false)]
    [InlineData(-2, true)]
    [InlineData(30, false)]
    public void IsNumberPrimary(int number, bool expected)
    {
        var result = IsPrimeNumber(number);

        Assert.Equal(result, expected);
    }
}