using MediatR;
using PYP_Task_One.Aplication.Enums;


namespace PYP_Task_One.Aplication.Features.Queries.ExcelData;

public class SendReportQueryRequest : IRequest<SendReportQueryResponse>
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string[] EmailAddresses { get; set; }
    public ReportType ReportType { get; set; }
}
