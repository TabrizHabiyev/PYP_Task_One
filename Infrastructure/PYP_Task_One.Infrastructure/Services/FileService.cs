using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using PYP_Task_One.Aplication.Services;
using PYP_Task_One.Domain.Entites;

namespace PYP_Task_One.Infrastructure.Services;

public class FileService : IFileService
{
    public async Task<bool> UploadAsyc(IFormFile file)
    {
        var a = ExcelSpreadsheetTemplateValidate(file);
        if (!ExcelSpreadsheetTemplateValidate(file)) return false;

        var stream = file.OpenReadStream();

        using var package = new ExcelPackage(stream);
            
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelWorksheet worksheet = package.Workbook.Worksheets.First();
            int rowCount = worksheet.Dimension.Rows;

                   List<Spreadsheet> datas = new List<Spreadsheet>();

        for (var row = 2; row <= rowCount; row++)
                {
                    try
                    {
                Spreadsheet data = new Spreadsheet();
                double defaultValue = 0;
                DateTime defaultDate = DateTime.MinValue;
                data.Segment = worksheet.Cells[row, 1]?.Value?.ToString()?.Trim() ?? "None";
                data.Country = worksheet.Cells[row, 2]?.Value?.ToString()?.Trim() ?? "None";
                data.Product = worksheet.Cells[row, 3]?.Value?.ToString()?.Trim() ?? "None";
                data.DiscountBand = worksheet.Cells[row, 4]?.Value?.ToString()?.Trim() ?? "None";


                data.UnitsSold = double.TryParse(worksheet.Cells[row, 5]?.Value?.ToString()?.Trim(), out defaultValue) == true ? defaultValue : 0;
                data.ManufacturingPrice = double.TryParse(worksheet.Cells[row, 6]?.Value?.ToString()?.Trim(), out defaultValue) == true ? defaultValue : 0;
                data.SellPrice = double.TryParse(worksheet.Cells[row, 7]?.Value?.ToString()?.Trim(), out defaultValue) == true ? defaultValue : 0;
                data.GrossSales = double.TryParse(worksheet.Cells[row, 8]?.Value?.ToString()?.Trim(), out defaultValue) == true ? defaultValue : 0;
                data.Discount = double.TryParse(worksheet.Cells[row, 9]?.Value?.ToString()?.Trim(), out defaultValue) == true ? defaultValue : 0;
                data.Sale = double.TryParse(worksheet.Cells[row, 10]?.Value?.ToString()?.Trim(), out defaultValue) == true ? defaultValue : 0;
                data.COGS = double.TryParse(worksheet.Cells[row, 11].Value?.ToString()?.Trim(), out defaultValue) == true ? defaultValue : 0;
                data.Profit = double.TryParse(worksheet.Cells[row, 12]?.Value?.ToString()?.Trim(), out defaultValue) == true ? defaultValue : 0;

                data.Date = DateTime.TryParse(worksheet.Cells[row, 13]?.Value?.ToString()?.Trim(), out defaultDate) == true ? defaultDate : DateTime.MinValue;

                if (data.Segment == "None" || data.Country == "None" || data.Product == "None" || data.UnitsSold == 0 || data.Date == DateTime.MinValue) continue;

                datas.Add(data);

                 }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            
        return true;
    }

    public  bool ExcelSpreadsheetTemplateValidate(IFormFile file)
    {
            Stream stream = file.OpenReadStream();

            using ExcelPackage package = new(stream);
        
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelWorksheet worksheet = package.Workbook.Worksheets.First();
            int rowCount = worksheet.Dimension.Rows;
            int colums = worksheet.Dimension.Columns;

            if (rowCount > 1 && colums == 13) return true;
         
        return false;
    }
}
