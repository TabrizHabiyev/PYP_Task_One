using PYP_Task_One.Aplication.Enums;


namespace PYP_Task_One.Aplication.Services;

public interface IEmailSenderService
{
    public Task<bool> SendEmailForReport(string[] emailAddresses, string attachmentPath,ReportType raportType);
}
