namespace MySchoolCalcClient.Data;

public class GeometricFormulasParameters
{
    public string Path { get; set; }
    public string Text { get; set; }

    public GeometricFormulasParameters(string path, string text)
    {
        Path = path;
        Text = text;
    }
}
