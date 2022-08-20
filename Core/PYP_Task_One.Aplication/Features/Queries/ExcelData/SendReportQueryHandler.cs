using MediatR;
using Microsoft.EntityFrameworkCore;
using PYP_Task_One.Aplication.DTOs;
using PYP_Task_One.Aplication.Extensions;
using PYP_Task_One.Aplication.Repositories.File;
using PYP_Task_One.Aplication.Services;
using System.Collections.Generic;

namespace PYP_Task_One.Aplication.Features.Queries.ExcelData;

public class SendReportQueryHandler : IRequestHandler<SendReportQueryRequest, SendReportQueryResponse>
{
    private readonly IExcelDataReadRepository _excelDataReadRepository;
    private readonly IFileService _fileService;
    private readonly IEmailSenderService _emailSenderService;
    public SendReportQueryHandler(IExcelDataReadRepository excelDataReadRepository, IFileService fileService, IEmailSenderService emailSenderService)
    {
        _excelDataReadRepository = excelDataReadRepository;
        _fileService = fileService;
        _emailSenderService = emailSenderService;
    }

    public async Task<SendReportQueryResponse> Handle(SendReportQueryRequest request, CancellationToken cancellationToken)
    {

        List<ReportDto> reportDtos = await _excelDataReadRepository.Table
             .GetReportByTypeFromDb(request.ReportType, request.StartDate, request.EndDate)
             .ToListAsync();

        (string? filePath, string? fileDirectory) = await _fileService.GenerateExcelFileAsync(request.ReportType, reportDtos);

        if (fileDirectory == null) return new() { };
        bool result = await _emailSenderService.SendEmailForReport(request.EmailAddresses, filePath);
        _fileService.DeleteDirectory(fileDirectory);
        return new() { };
    }
}
