﻿using Microsoft.AspNetCore.Http;
using PYP_Task_One.Aplication.DTOs;

namespace PYP_Task_One.Aplication.Services;

public interface IFileService
{
    Task<(bool, bool, bool, List<SpreadsheetDto> spreadsheetDtos)> UploadAsyc(IFormFile file);
    bool ExcelSpreadsheetTemplateValidate(IFormFile file);
    Task<bool> IsXlsxOrXlsFileAsync(IFormFile file);
}
