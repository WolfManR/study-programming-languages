﻿using System.Collections;
using FastReport;
using FastReport.Export.PdfSimple;

namespace TemplatesReporter.FastReport;

public static class ReportExtensions
{
    public static Report SetDataToReportDataBind(
        this Report report,
        IEnumerable data,
        string reportDataSourceName,
        string reportDataBindName)
    {
        report.Dictionary.Clear();
        report.RegisterData(data, reportDataSourceName);

        var reportDataSource = report.GetDataSource(reportDataSourceName);
        reportDataSource.Enabled = true;

        DataBand dataBand = (DataBand)report.FindObject(reportDataBindName);
        dataBand.DataSource = reportDataSource;

        return report;
    }

    public static Report ExportToPdf(this Report report, string outputPath)
    {
        PDFSimpleExport pdfExport = new();

        pdfExport.Export(report, outputPath);

        return report;
    }
}