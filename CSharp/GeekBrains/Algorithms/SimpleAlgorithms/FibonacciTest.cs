namespace SimpleAlgorithms;

public class FibonacciTests
{
    private static int RecursiveFibonacci(int number) =>
        number switch
        {
            0 => 0,
            1 => 1,
            _ => RecursiveFibonacci(number - 2) + RecursiveFibonacci(number - 1)
        };

    private static int LoopFibonacci(int number)
    {
        if (number == 0) return 0;
        if (number == 1) return 1;

        var prev = 0;
        var cur = 1;

        for (var i = 2; i <= number; i++)
        {
            var temp = prev + cur;
            prev = cur;
            cur = temp;
        }

        return cur;
    }

    public static IEnumerable<object[]> TestData()
    {
        yield return new object[] { 0, 0 };
        yield return new object[] { 1, 1 };
        yield return new object[] { 2, 1 };
        yield return new object[] { 3, 2 };
        yield return new object[] { 4, 3 };
        yield return new object[] { 5, 5 };
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void RecursiveFibonacciTest(int number, int expected)
    {
        var result = RecursiveFibonacci(number);

        Assert.Equal(result, expected);
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void LoopFibonacciTest(int number, int expected)
    {
        var result = LoopFibonacci(number);

        Assert.Equal(result, expected);
    }
}