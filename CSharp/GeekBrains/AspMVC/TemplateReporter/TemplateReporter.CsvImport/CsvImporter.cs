using CsvHelper;
using CsvHelper.Configuration;

using System.Globalization;

namespace TemplateReporter.CsvImport;

public class CsvImporter : IDisposable
{
    private readonly CsvConfiguration _csvConfiguration;
    private TextReader textReaderStream;
    private CsvReader csvReader;


    public CsvImporter()
    {
        _csvConfiguration = new(CultureInfo.InvariantCulture)
        {
            DetectDelimiter = true,
        };
    }

    public IAsyncEnumerable<TImportModel> ReadImportData<TImportModel, TImportModelMap>(string filePath)
        where TImportModelMap : ClassMap
        where TImportModel : new()
    {
        textReaderStream = File.OpenText(filePath);
        csvReader = new(textReaderStream, _csvConfiguration);

        csvReader.Context.RegisterClassMap<TImportModelMap>();

        return csvReader.EnumerateRecordsAsync(new TImportModel());
    }

    public void Dispose()
    {
        textReaderStream.Dispose();
        csvReader.Dispose();
    }
}