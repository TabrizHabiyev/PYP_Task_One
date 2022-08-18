using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PYP_Task_One.Aplication.Features.Commands;
using PYP_Task_One.Aplication.Services;
using System.Net;

namespace PYP_Task_One.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TestController(IMediator mediator)
        {
            _mediator = mediator;
        }


        // POST api/<TestController>
        [HttpPost]
        public async Task<IActionResult> Post(IFormFile fromFile)
        {
            ExcelDataToDbCommandRequest excelDataToDbCommandRequest = new();
            excelDataToDbCommandRequest.formFile = fromFile;
            ExcelDataToDbCommandResponse response = await _mediator.Send(excelDataToDbCommandRequest);

          return StatusCode((int)HttpStatusCode.OK, response);
        }
    }
}
