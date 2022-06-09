using Xunit;

namespace SimpleAlgorithms;

public class LongestCommonSubsequenceLengthTests
{
    private static int LongestCommonSubsequenceLength(string a, string b)
    {
        if (a.Length == 0 || b.Length == 0)
            return 0;
        if (a[0] == b[0])
            return 1 + LongestCommonSubsequenceLength(a.Substring(1), b.Substring(1));
        return Math.Max(LongestCommonSubsequenceLength(a.Substring(1), b),
            LongestCommonSubsequenceLength(a, b.Substring(1)));
    }

    [Theory]
    [InlineData(7, "point to this", "pointless message")]
    public void CalculateLongestSubsequenceLengthAsExpected(int expected, params string[] strings)
    {
        Assert.Equal(expected, LongestCommonSubsequenceLength(strings[0], strings[1]));
    }
}