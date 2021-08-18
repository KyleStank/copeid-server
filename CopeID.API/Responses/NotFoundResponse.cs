using System.Net;

namespace CopeID.API.Responses
{
    public class NotFoundResponse : ErrorResponse
    {
        public NotFoundResponse() : base(HttpStatusCode.NotFound)
        { }

        public NotFoundResponse(string message) : base(HttpStatusCode.NotFound, message)
        { }
    }
}
