using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Net.Http.Json;

namespace MySchoolCalcClient.Data.Calc;

public class CalcService : ICalcService
{
    private readonly HttpClient httpClient;

    public CalcService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<CalcResponse> GetMathCalc(CalcRequest request)
    {
        return await httpClient.GetFromJsonAsync<CalcResponse>($"math/{request.body}");
    }

    public async Task<CalcResponse> GetSinCalc(CalcRequest request)
    {
        return await httpClient.GetFromJsonAsync<CalcResponse>($"sin/{request.body}");
    }

    public async Task<CalcResponse> GetCosCalc(CalcRequest request)
    {
        return await httpClient.GetFromJsonAsync<CalcResponse>($"cos/{request.body}");
    }

    public async Task<CalcResponse> GetTanCalc(CalcRequest request)
    {
        return await httpClient.GetFromJsonAsync<CalcResponse>($"tan/{request.body}");
    }

    public async Task<CalcResponse> GetCotCalc(CalcRequest request)
    {
        return await httpClient.GetFromJsonAsync<CalcResponse>($"cot/{request.body}");
    }
}
