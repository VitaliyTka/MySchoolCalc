namespace MySchoolCalcServer
{
    public class Response
    {
        public string Result { get; set; }
        public Response(string result)
        {
            this.Result = result;
        }
    }
}
