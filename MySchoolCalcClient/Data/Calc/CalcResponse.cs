namespace MySchoolCalcClient.Data.Calc;

public class CalcResponse
{
    public string body { get; set; }
    public CalcResponse(string body)
    {
        this.body = body;
    }
}
