namespace MySchoolCalcClient.Data.Calc;

public interface ICalcService
{
    Task<CalcResponse> GetMathCalc(CalcRequest request);
    Task<CalcResponse> GetSinCalc(CalcRequest request);
    Task<CalcResponse> GetCosCalc(CalcRequest request);
    Task<CalcResponse> GetTanCalc(CalcRequest request);
    Task<CalcResponse> GetCotCalc(CalcRequest request);
}
