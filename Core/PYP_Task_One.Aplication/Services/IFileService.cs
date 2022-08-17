using Microsoft.AspNetCore.Http;


namespace PYP_Task_One.Aplication.Services;

public interface IFileService
{
    Task<bool> UploadAsyc(IFormFile file);
    bool ExcelSpreadsheetTemplateValidate(IFormFile file);
    
}
