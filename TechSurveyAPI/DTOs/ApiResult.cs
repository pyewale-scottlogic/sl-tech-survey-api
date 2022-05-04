namespace TechSurveyAPI.DTOs
{
    public class ApiResult
    {
        string _ErrorMessage = null;
        object _Data = null;

        public string ErrorMessage { get => _ErrorMessage; set => _ErrorMessage = value; }
        public object Data { get => _Data; set => _Data = value; }
    }
}
