namespace PYP_Task_One.Aplication.Features.Commands.ExcelData;

public class ExcelDataToDbCommandResponse
{
    public bool Success { get; set; }
    public string? Message { get; set; }
    public int StatusCode { get; internal set; }
}
