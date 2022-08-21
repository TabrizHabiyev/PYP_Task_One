using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PYP_Task_One.Aplication;
using PYP_Task_One.Aplication.Enums;
using PYP_Task_One.Aplication.Services;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace PYP_Task_One.Infrastructure.Services;

public class EmailSenderService : IEmailSenderService
{
    private readonly ILogger<EmailSenderService> _log;

    public EmailSenderService(ILogger<EmailSenderService> log)
    {
        _log = log;
    }

    public async Task<bool> SendEmailForReport(string[] emailAddresses, string attachmentPath, ReportType type)
    {
        var client = new SendGridClient(Configuration.EmailConfiguration["ApiKey"]);
        var from = new EmailAddress(Configuration.EmailConfiguration["From"], "Tabriz Habiyev");
        var subject = "Report Statistics";
        var to = new List<EmailAddress>();
        emailAddresses.ToList().ForEach(x => to.Add(new EmailAddress(x)));
        var msg = MailHelper.CreateSingleEmailToMultipleRecipients(from, to, subject, "Report Statistics", null);
        using var fileStream = File.OpenRead(attachmentPath);
        await msg.AddAttachmentAsync(attachmentPath.Substring(attachmentPath.LastIndexOf("/") + 1), fileStream);
        try
        {
            var response = await client.SendEmailAsync(null);
            if (response.IsSuccessStatusCode != true)
            {
                _log.LogInformation("Send Raport: {Email}:{RapartType}:{SendRaportDate}", emailAddresses, type.ToString(), DateTime.Now);
                return true;
            }
            else return false;
        }
        catch (Exception ex)
        {
            _log.LogError("Error in email services", ex);
            return false;
        }
    }
}
