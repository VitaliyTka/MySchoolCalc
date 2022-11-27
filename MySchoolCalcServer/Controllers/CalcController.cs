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

        [HttpGet("sin/{request}")]
        public CalcResponse GetSin(string request)
        {
            try
            {
                int degree = Int32.Parse(request);
                if (degree < 0 || degree > 360)
                    throw new Exception();

                if (degree == 0 || degree == 180 || degree == 360)
                    return new CalcResponse("0.0000");
                if (degree == 90 || degree == 270)
                    return new CalcResponse("1.0000");

                double radian = CalcRadian(degree);
                string response = Math.Sin(radian).ToString("0.0000");

                if (degree == 30 || degree == 150)
                    return new CalcResponse("0.5000");
                if (degree == 45 || degree == 135)
                    return new CalcResponse($"√2/2 = {response}");
                if (degree == 60 || degree == 120)
                    return new CalcResponse($"√3/2 = {response}");

                if (degree == 210 || degree == 330)
                    return new CalcResponse("-0.5000");
                if (degree == 225 || degree == 315)
                    return new CalcResponse($"-√2/2 = {response}");
                if (degree == 240 || degree == 300)
                    return new CalcResponse($"-√3/2 = {response}");


                return new CalcResponse(response);
            }
            catch (Exception ex)
            {
                return new CalcResponse(":(");
            }
        }

        [HttpGet("cos/{request}")]
        public CalcResponse GetCos(string request)
        {
            try
            {
                int degree = Int32.Parse(request);
                if (degree < 0 || degree > 360)
                    throw new Exception();

                if (degree == 0 || degree == 360)
                    return new CalcResponse("1.0000");
                if (degree == 90 || degree == 270)
                    return new CalcResponse("0.0000");
                if (degree == 180)
                    return new CalcResponse("-1.0000");

                double radian = CalcRadian(degree);
                string response = Math.Cos(radian).ToString("0.0000");

                if (degree == 60 || degree == 300)
                    return new CalcResponse("0.5000");
                if (degree == 45 || degree == 315)
                    return new CalcResponse($"√2/2 = {response}");
                if (degree == 30 || degree == 330)
                    return new CalcResponse($"√3/2 = {response}");

                if (degree == 120 || degree == 240)
                    return new CalcResponse("-0.5000");
                if (degree == 135 || degree == 225)
                    return new CalcResponse($"-√2/2 = {response}");
                if (degree == 150 || degree == 210)
                    return new CalcResponse($"-√3/2 = {response}");

                return new CalcResponse(response);
            }
            catch (Exception ex)
            {
                return new CalcResponse(":(");
            }
        }

        [HttpGet("tan/{request}")]
        public CalcResponse GetTan(string request)
        {
            try
            {
                int degree = Int32.Parse(request);
                if (degree < 0 || degree > 360 || degree == 90 || degree == 270)
                    throw new Exception();

                if (degree == 90 || degree == 270)
                    return new CalcResponse("∞");

                if (degree == 45 || degree == 225)
                    return new CalcResponse("1.0000");
                if (degree == 0 || degree == 180 || degree == 360)
                    return new CalcResponse("0.0000");
                if (degree == 135 || degree == 315)
                    return new CalcResponse("-1.0000");

                double radian = CalcRadian(degree);
                string response = Math.Tan(radian).ToString("0.0000");

                if (degree == 60)
                    return new CalcResponse($"√3 = {response}");
                if (degree == 30)
                    return new CalcResponse($"√3/2 = {response}");
                if (degree == 210)
                    return new CalcResponse($"√3/3 = {response}");

                if (degree == 120 || degree == 240 || degree == 300)
                    return new CalcResponse($"-√3 = {response}");
                if (degree == 150 || degree == 330)
                    return new CalcResponse($"-√3/3 = {response}");

                return new CalcResponse(response);
            }
            catch (Exception ex)
            {
                return new CalcResponse(":(");
            }
        }

        [HttpGet("cot/{request}")]
        public CalcResponse GetCot(string request)
        {
            try
            {
                int degree = Int32.Parse(request);
                if (degree < 0 || degree > 360)
                    throw new Exception();

                if (degree == 0 || degree == 180 || degree == 360)
                    return new CalcResponse("∞");

                if (degree == 45 || degree == 225)
                    return new CalcResponse("1.0000");
                if (degree == 90 || degree == 270)
                    return new CalcResponse("0.0000");
                if (degree == 135 || degree == 315)
                    return new CalcResponse("-1.0000");

                double radian = CalcRadian(degree);
                string response = (1 / Math.Tan(radian)).ToString("0.0000");

                if (degree == 30 || degree == 210)
                    return new CalcResponse($"√3 = {response}");
                if (degree == 60)
                    return new CalcResponse($"√3/2 = {response}");
                if (degree == 240)
                    return new CalcResponse($"√3/3 = {response}");

                if (degree == 150 || degree == 330)
                    return new CalcResponse($"-√3 = {response}");
                if (degree == 120)
                    return new CalcResponse($"-√3/2 = {response}");
                if (degree == 300)
                    return new CalcResponse($"-√3/3 = {response}");

                return new CalcResponse(response);
            }
            catch (Exception ex)
            {
                return new CalcResponse(":(");
            }
        }

        private double CalcRadian(int degree)
        {
            return degree * Math.PI / 180;
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
