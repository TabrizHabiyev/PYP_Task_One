using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PYP_Task_One.Aplication.Services;


namespace PYP_Task_One.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IFileService _fileService;

        public TestController(IFileService fileService)
        {
            _fileService = fileService;
        }

        // GET: api/<TestController>

        // POST api/<TestController>
        [HttpPost]
        public async Task<bool> Post(IFormFile file)
        {
         var a = await _fileService.UploadAsyc(file);
            return a;
        }
    }
}
