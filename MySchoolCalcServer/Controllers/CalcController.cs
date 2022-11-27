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
                if (request.Contains('!'))
                {
                    request = CalcFactorial(request);
                }
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
        private string CalcFactorial(string request)
        {
            int countFactorial = request.ToCharArray().Count(c => c == '!');
            for (int i = 0; i < countFactorial; i++)
            {
                int factorialStartIndex = request.IndexOf('!');
                int factorialEndIndex = request.IndexOf('!');
                if (factorialEndIndex == 0)
                    throw new Exception("");

                bool isLastItem = false;
                while (!isLastItem)
                {
                    if (factorialStartIndex == 0)
                    {
                        isLastItem = true;
                    }
                    else
                    {
                        string preItem = request[factorialStartIndex - 1].ToString();
                        if (IsEndOfParam(preItem))
                        {
                            isLastItem = true;
                        }
                        else
                        {
                            factorialStartIndex--;
                        }
                    }
                }
                string factorial = request.Substring(factorialStartIndex, factorialEndIndex - factorialStartIndex);
                string rezFactorial = Factorial(Int32.Parse(factorial)).ToString();
                request = request.Remove(factorialStartIndex, factorialEndIndex - factorialStartIndex + 1);
                request = request.Insert(factorialStartIndex, rezFactorial);
            }
            return request;
        }
        private bool IsEndOfParam(string preItem)
        {
            if (preItem == "-" ||
                preItem == "+" ||
                preItem == "(" ||
                preItem == ")" ||
                preItem == "/" ||
                preItem == "*" ||
                preItem == "!")
            {
                return true;
            }
            return false;
        }
        private int Factorial(int n)
        {
            if (n == 1) return 1;

            return n * Factorial(n - 1);
        }

    }
}
