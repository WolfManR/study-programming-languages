ICoder aCoder = new ACoder();
ICoder bCoder = new BCoder();

const string toEncode = "aBcdEf";

var encodedWithACoder = aCoder.Encode(toEncode);
var decodedWithACoder = aCoder.Decode(encodedWithACoder);

Console.WriteLine("Original: " + toEncode);

Console.WriteLine();

Console.WriteLine("A Coder");
Console.WriteLine("Encoded: " + encodedWithACoder);
Console.WriteLine("Decoded: " + decodedWithACoder);

var encodedWithBCoder = bCoder.Encode(toEncode);
var decodedWithBCoder = bCoder.Decode(encodedWithBCoder);

Console.WriteLine();

Console.WriteLine("B Coder");
Console.WriteLine("Encoded: " + encodedWithBCoder);
Console.WriteLine("Decoded: " + decodedWithBCoder);