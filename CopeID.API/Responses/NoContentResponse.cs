using System.Net;

namespace CopeID.API.Responses
{
    public class NoContentResponse : ErrorResponse
    {
        public NoContentResponse() : base(HttpStatusCode.NoContent)
        { }

        public NoContentResponse(string message) : base(HttpStatusCode.NoContent, message)
        { }
    }
}
