namespace TemplatesReporter;

internal static class AppConfiguration
{
    public const string MongoDbConnectionString = "mongodb://root:pass12345@localhost:27017";
    public const string MongoDbDataBase = "SampleReports";
    public const string ProductsCollectionName = "RawData";

    const string Directory = @"Temp";
    public static readonly string CsvFile = Directory.MergePath("sample-csv-file-for-testing.csv");
    public static readonly string OutputReport = Directory.MergePath("Simple List.pdf");
    public static readonly string ReportFormFile = Directory.MergePath("ProductsList.frx");

    public static string MergePath(this string self, string endPath) => Path.Combine(self, endPath);
}