using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestAspnetCore.Services.DTO;
using TestAspnetCore.Services.Interfaces;
using System.Threading.Tasks;

namespace TestAspnetCore.Web.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TestController : ControllerBase
    {
        
        private readonly ILogger<TestController> logger;
        private ITestServices services;

        public TestController(ILogger<TestController> log, ITestServices services)
        {
            this.logger = log;
            this.services = services;
        }

        [HttpGet("echoping")] //GET api/v1/test/echoping
        public IActionResult Echoping() => Ok();
        
        [HttpGet("gettest")] //GET api/v1/test/echoping
        public async Task<IActionResult> GetTest(TwoParametersRequestDTO request)
        {
            return Ok(await this.services.GetResultsFromRequestAsync(request));
        }

    }
}