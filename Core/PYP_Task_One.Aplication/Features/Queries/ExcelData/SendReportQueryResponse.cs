using PYP_Task_One.Aplication.DTOs;
using System.Text.Json.Serialization;

namespace PYP_Task_One.Aplication.Features.Queries.ExcelData;

public class SendReportQueryResponse
{
    public int StatusCode { get; internal set; }
    public bool IsSucccessful { get; internal set; }
    public string? Message { get; internal set; }
}
