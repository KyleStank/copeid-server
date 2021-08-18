using System.Net;

namespace CopeID.API.Responses
{
    public class ErrorResponse
    {
        public int Code { get; set; }
        public string Description { get; set; }

        public string Message { get; set; }

        public ErrorResponse(HttpStatusCode statusCode)
        {
            Code = (int)statusCode;
            Description = statusCode.ToString();
        }

        public ErrorResponse(HttpStatusCode statusCode, string message) : this(statusCode)
        {
            Message = message;
        }
    }
}
