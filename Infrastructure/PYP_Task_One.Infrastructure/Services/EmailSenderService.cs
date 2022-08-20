using Microsoft.Extensions.Configuration;
using PYP_Task_One.Aplication;
using PYP_Task_One.Aplication.Services;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace PYP_Task_One.Infrastructure.Services;

public class EmailSenderService : IEmailSenderService
{
    public async Task<bool> SendEmailForReport(string[] emailAddresses, string attachmentPath)
    {
        var client = new SendGridClient(Configuration.EmailConfiguration["ApiKey"]);
        var from = new EmailAddress(Configuration.EmailConfiguration["From"], "Tabriz Habiyev");
        var subject = "Report Statistics";
        var to = new List<EmailAddress>();
        emailAddresses.ToList().ForEach(x => to.Add(new EmailAddress(x)));
        var msg = MailHelper.CreateSingleEmailToMultipleRecipients(from, to, subject, "Report Statistics", null);
        using var fileStream = File.OpenRead(attachmentPath);
        await msg.AddAttachmentAsync(attachmentPath.Substring(attachmentPath.LastIndexOf("/") + 1), fileStream);
        var response = await client.SendEmailAsync(msg);
        return response.IsSuccessStatusCode == true ? true : false;
    }
}
