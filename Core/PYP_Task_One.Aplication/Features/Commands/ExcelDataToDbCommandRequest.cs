using MediatR;
using Microsoft.AspNetCore.Http;

namespace PYP_Task_One.Aplication.Features.Commands;

public class ExcelDataToDbCommandRequest: IRequest<ExcelDataToDbCommandResponse>
{
   public IFormFile formFile { get; set; }

}
