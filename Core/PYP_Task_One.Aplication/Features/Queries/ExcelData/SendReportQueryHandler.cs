using MediatR;
using Microsoft.EntityFrameworkCore;
using PYP_Task_One.Aplication.DTOs;
using PYP_Task_One.Aplication.Extensions;
using PYP_Task_One.Aplication.Repositories.File;
using PYP_Task_One.Aplication.Services;

namespace PYP_Task_One.Aplication.Features.Queries.ExcelData;

public class SendReportQueryHandler : IRequestHandler<SendReportQueryRequest, SendReportQueryResponse>
{
    private readonly IExcelDataReadRepository _excelDataReadRepository;
    private readonly IFileService _fileService;
    public SendReportQueryHandler(IExcelDataReadRepository excelDataReadRepository, IFileService fileService)
    {
        _excelDataReadRepository = excelDataReadRepository;
        _fileService = fileService;
    }

    public async Task<SendReportQueryResponse> Handle(SendReportQueryRequest request, CancellationToken cancellationToken)
    {

        List<ReportDto> ReportDto = await _excelDataReadRepository.Table
             .GetReportByTypeFromDb(request.ReportType, request.StartDate, request.EndDate)
             .ToListAsync();
        string result =await _fileService.GenerateExcelFileAsync(request.ReportType, ReportDto);
        return new() { };
    }
}
