using AutoMapper;
using MediatR;
using PYP_Task_One.Aplication.DTOs;
using PYP_Task_One.Aplication.Repositories.File;
using PYP_Task_One.Aplication.Services;
using PYP_Task_One.Domain.Entites;

namespace PYP_Task_One.Aplication.Features.Commands.ExcelData;
public class ExcelDataToDbCommandHandlerI : IRequestHandler<ExcelDataToDbCommandRequest, ExcelDataToDbCommandResponse>
{
    private readonly IFileService _fileService;
    private readonly IExcelDataWriteRepository _excelDataWriteRepository;
    private readonly IMapper _mapper;
    public ExcelDataToDbCommandHandlerI(IFileService fileService, IExcelDataWriteRepository excelDataWriteRepository, IMapper mapper)
    {
        _fileService = fileService;
        _excelDataWriteRepository = excelDataWriteRepository;
        _mapper = mapper;
    }

    public async Task<ExcelDataToDbCommandResponse> Handle(ExcelDataToDbCommandRequest request, CancellationToken cancellationToken)
    {
        (bool IsXlsxOrXls, bool TemplateValidate, bool UploadSuccest, List<SpreadsheetDto> datas) = await _fileService.UploadAsyc(request.formFile);

        if (datas != null)
        {
            List<Spreadsheet> spreadData = _mapper.Map<List<Spreadsheet>>(datas);
            await _excelDataWriteRepository.AddRangeAsync(spreadData);
            await _excelDataWriteRepository.SaveAsync();
        }
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
