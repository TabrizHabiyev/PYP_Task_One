using MediatR;
using Microsoft.EntityFrameworkCore;
using PYP_Task_One.Aplication.DTOs;
using PYP_Task_One.Aplication.Extensions;
using PYP_Task_One.Aplication.Repositories.File;
using PYP_Task_One.Aplication.RequestMessage;
using PYP_Task_One.Aplication.Services;

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

        if (reportDtos == null) return new() { IsSucccessful = false, StatusCode = 404, Message = $"{Messages.SendRaportMessage["NoData"]}" };
        (string? filePath, string? fileDirectory) = await _fileService.GenerateExcelFileAsync(request.ReportType, reportDtos);

        if (fileDirectory == null) return new() {IsSucccessful = false,StatusCode = 400,Message = $"{Messages.SendRaportMessage["GenarateExcelError"]}" };
        bool result = await _emailSenderService.SendEmailForReport(request.EmailAddresses, filePath, request.ReportType);
        if (!result) return new() { IsSucccessful = false, StatusCode = 400, Message = $"{Messages.SendRaportMessage["EmailSendingError"]}" };
        _fileService.DeleteDirectory(fileDirectory);
        return new() { IsSucccessful = true, StatusCode = 200, Message = $"{Messages.SendRaportMessage["RaportSucceded"]}" };
    }
}
