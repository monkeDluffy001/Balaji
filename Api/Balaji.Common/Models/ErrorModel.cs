namespace Balaji.Common.Models
{
    public class ErrorModel
    {
        public string? Message { get; set; }
        public string? StackTrace { get; set; }

        public ErrorModel()
        {
            Message = string.Empty;
            StackTrace = string.Empty;
        }

        public ErrorModel(string? _message, string _stackTrace)
        {
            Message = _message;
            StackTrace = _stackTrace;
        }

        public ErrorModel(Exception ex)
        {
            Message = ex.Message;
            StackTrace = ex.StackTrace;
        }
    }
}
