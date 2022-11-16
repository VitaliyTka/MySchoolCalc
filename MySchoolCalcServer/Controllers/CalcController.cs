using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace MySchoolCalcServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalcController : ControllerBase
    {
        private readonly ILogger<CalcController> _logger;

        public CalcController(ILogger<CalcController> logger)
        {
            _logger = logger;
        }

        [HttpGet("math/{request}")]
        public Response Get(string request)
        {
            object response = new DataTable().Compute(request, null);
            if (response == null)
                return new Response(string.Empty);

            return new Response(response.ToString());
        }

    }
}
