using System.Text;

internal sealed class BCoder : ICoder
{
    private static readonly int[] LowerCaseRange = { 'a', 'z' };
    private static readonly int[] UpperCaseRange = { 'A', 'Z' };

    public string Encode(string toEncode)
    {
        var span = toEncode.AsSpan();
        var sb = new StringBuilder(toEncode.Length);

        foreach (var character in span)
        {
            if (IsLowerCase(character))
            {
                var rangeFromStart = character - LowerCaseRange[0];
                if (rangeFromStart == 0)
                {
                    sb.Append((char)LowerCaseRange[1]);
                    continue;
                }
                sb.Append((char)(LowerCaseRange[1] - rangeFromStart));
                continue;
            }

            if (IsUpperCase(character))
            {
                var rangeFromStart = character - UpperCaseRange[0];
                if (rangeFromStart == 0)
                {
                    sb.Append((char)UpperCaseRange[1]);
                    continue;
                }
                sb.Append((char)(UpperCaseRange[1] - rangeFromStart));
            }
        }

        return sb.ToString();
    }

    public string Decode(string toDecode)
    {
        var span = toDecode.AsSpan();
        var sb = new StringBuilder(toDecode.Length);

        foreach (var character in span)
        {
            if (IsLowerCase(character))
            {
                var rangeFromEnd = LowerCaseRange[1] - character;
                if (rangeFromEnd == 0)
                {
                    sb.Append((char)LowerCaseRange[0]);
                    continue;
                }
                sb.Append((char)(LowerCaseRange[0] + rangeFromEnd));
                continue;
            }

            if (IsUpperCase(character))
            {
                var rangeFromEnd = UpperCaseRange[1] - character;
                if (rangeFromEnd == 0)
                {
                    sb.Append((char)UpperCaseRange[0]);
                    continue;
                }
                sb.Append((char)(UpperCaseRange[0] + rangeFromEnd));
            }
        }

        return sb.ToString();
    }

    private static bool IsLowerCase(char character) => character >= LowerCaseRange[0] && character <= LowerCaseRange[1];
    private static bool IsUpperCase(char character) => character >= UpperCaseRange[0] && character <= UpperCaseRange[1];
}