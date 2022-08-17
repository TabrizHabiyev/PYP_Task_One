using Microsoft.AspNetCore.Http;


namespace PYP_Task_One.Aplication.Services;

public interface IFileService
{
    Task<(bool IsXlsxOrXls, bool TemplateValidate, bool UploadSuccest)> UploadAsyc(IFormFile file);
    bool ExcelSpreadsheetTemplateValidate(IFormFile file);
    Task<bool> IsXlsxOrXlsFileAsync(IFormFile file);


}
