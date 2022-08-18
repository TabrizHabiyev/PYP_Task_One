using MediatR;
using PYP_Task_One.Aplication.DTOs;
using PYP_Task_One.Aplication.Services;

namespace PYP_Task_One.Aplication.Features.Commands;
public class ExcelDataToDbCommandHandlerI : IRequestHandler<ExcelDataToDbCommandRequest, ExcelDataToDbCommandResponse>
{
    private readonly IFileService _fileService;

    public ExcelDataToDbCommandHandlerI(IFileService fileService)
    {
        _fileService = fileService;
    }

    public async Task<ExcelDataToDbCommandResponse> Handle(ExcelDataToDbCommandRequest request, CancellationToken cancellationToken)
    {
        (bool IsXlsxOrXls, bool TemplateValidate, bool UploadSuccest ,List<SpreadsheetDto> datas ) = await _fileService.UploadAsyc(request.formFile);

        return new()
        {
            Success = IsXlsxOrXls || TemplateValidate || UploadSuccest == true ? true : false,
            Message = IsXlsxOrXls != true ? "Corupted file type" :
            TemplateValidate != true ? "File template is not suitable" :
            UploadSuccest != true ? "An error occurred while reading the file" :
            "File information successfully saved"
        };

    }
}
