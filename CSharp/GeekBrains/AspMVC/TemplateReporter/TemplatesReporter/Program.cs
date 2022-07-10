using TemplateReporter.CsvImport;
using TemplateReporter.Data;

using TemplatesReporter;
using TemplatesReporter.Database;
using TemplatesReporter.FastReport;
using TemplatesReporter.Import;

DatabaseConnection dbConnection = new DatabaseConnection(AppConfiguration.MongoDbConnectionString, AppConfiguration.MongoDbDataBase);
Repository repository = new Repository(dbConnection);

//=======Import and parse raw data to database==============

await ImportAndParseDataToDatabase(repository);

//=======Import data to report template=====================

await BuildReport(repository);

//==End Work=======================

#if Release
    Console.WriteLine("Work done");
    _ = Console.ReadKey();
#endif

static async Task ImportAndParseDataToDatabase(Repository repository)
{
    using CsvImporter importer = new CsvImporter();
    var readCsv = importer.ReadImportData<RawProductInfo, RawProductInfoMap>(AppConfiguration.CsvFile);
    var result = await repository.SaveImportDataToTempStorage<RawProductInfo, ProductInfo>(readCsv, AppConfiguration.ProductsCollectionName, new ProductInfoRewriter());
    if (!result)
    {
        Console.WriteLine("Fail to import raw data");
        Environment.Exit(-1);
    }
}

static async Task BuildReport(Repository repository)
{
    var data = await repository.TakeDataForReport<ProductInfo>(0, 20, AppConfiguration.ProductsCollectionName);

    var report = ReportBuilder.Start()
        .UseForm(AppConfiguration.ReportFormFile)
        .WithData(new ReportBuilder.ReportDataBind("Products", "Data1", data))
        .Build();

    // export report

    report.ExportToPdf(AppConfiguration.OutputReport);
}