using FluentValidation;
using PYP_Task_One.Aplication.Features.Queries.ExcelData;

namespace PYP_Task_One.Aplication.Validators;

public class SendReportValidator:AbstractValidator<SendReportQueryRequest>
{
    public SendReportValidator()
    {
        RuleForEach(e => e.EmailAddresses)
              .NotEmpty()
              .WithMessage("Email is required.")
              .EmailAddress()
              .WithMessage("Invalid email format.")
              .Matches("^[a-z0-9]+(?!.*(?:\\+{2,}|\\-{2,}|\\.{2,}))(?:[\\.+\\-]{0,1}[a-z0-9])*@code.edu\\.az$")
              .WithMessage("Only emails linked to the code.edu.az domain are accepted.");

        RuleFor(t => t.ReportType).IsInEnum();

        RuleFor(d => d.StartDate)
            .NotEmpty()
            .WithMessage("Start Date cannot be empty");
        RuleFor(d => d.EndDate)
           .NotEmpty()
           .WithMessage("End Date cannot be empty");

        RuleFor(d => d.EndDate).NotEmpty()
            .GreaterThan(r => r.StartDate)
            .WithMessage("Start Date is not greater than End Date");
    }
}
