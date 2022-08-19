using MediatR;
using Microsoft.EntityFrameworkCore;
using PYP_Task_One.Aplication.DTOs;
using PYP_Task_One.Aplication.Extensions;
using PYP_Task_One.Aplication.Repositories.File;

namespace PYP_Task_One.Aplication.Features.Queries.ExcelData;

public class SendReportQueryHandler : IRequestHandler<SendReportQueryRequest, SendReportQueryResponse>
{
    private readonly IExcelDataReadRepository _excelDataReadRepository;

    public SendReportQueryHandler(IExcelDataReadRepository excelDataReadRepository)
    {
        _excelDataReadRepository = excelDataReadRepository;
    }

    public async Task<SendReportQueryResponse> Handle(SendReportQueryRequest request, CancellationToken cancellationToken)
    {

        List<ReportDto> ReportDto = await _excelDataReadRepository.Table
             .GetReportByTypeFromDb(request.ReportType, request.StartDate, request.EndDate)
             .ToListAsync();

        return new() { };
    }
}
