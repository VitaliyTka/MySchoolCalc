namespace MySchoolCalcClient.Data.Calc;

public class CalcRequest
{
    public string body { get; set; }
    public CalcRequest(string body)
    {
        this.body = body;
    }
}
