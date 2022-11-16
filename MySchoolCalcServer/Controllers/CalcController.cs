using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using MySchoolCalcServer.Models;

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
        public CalcResponse Get(string request)
        {
            try
            {
                request = request.Replace("|", "/");
                object response = new DataTable().Compute(request, null);
                if (response == null)
                    return new CalcResponse(string.Empty);

                return new CalcResponse(response.ToString());
            }
            catch (Exception ex)
            {
                return new CalcResponse(":(");
            }
        }

    }
}
