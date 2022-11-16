namespace MySchoolCalcServer.Models;

public class CalcResponse
{
    public string body { get; set; }
    public CalcResponse(string body)
    {
        this.body = body;
    }
}
