using System.Net;

namespace CopeID.API.Responses
{
    public class UnauthorizedResponse : ErrorResponse
    {
        public UnauthorizedResponse() : base(HttpStatusCode.Unauthorized)
        { }

        public UnauthorizedResponse(string message) : base(HttpStatusCode.Unauthorized, message)
        { }
    }
}
