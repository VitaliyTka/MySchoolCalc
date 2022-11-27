namespace MySchoolCalcClient.Data.Calc;

public interface ICalcService
{
    Task<CalcResponse> GetMathCalc(CalcRequest request);
}
