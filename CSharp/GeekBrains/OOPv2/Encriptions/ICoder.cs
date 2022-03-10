internal interface ICoder
{
    string Encode(string toEncode);
    string Decode(string toDecode);
}