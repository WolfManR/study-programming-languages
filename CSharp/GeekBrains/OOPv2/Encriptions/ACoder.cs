using System.Text;

internal sealed class ACoder : ICoder
{
    public string Encode(string toEncode)
    {
        var span = toEncode.AsSpan();
        var sb = new StringBuilder(toEncode.Length);
        foreach (var character in span)
        {
            sb.Append((char)(character + 1));
        }

        return sb.ToString();
    }

    public string Decode(string toDecode)
    {
        var span = toDecode.AsSpan();
        var sb = new StringBuilder(toDecode.Length);
        foreach (var character in span)
        {
            sb.Append((char)(character - 1));
        }

        return sb.ToString();
    }
}