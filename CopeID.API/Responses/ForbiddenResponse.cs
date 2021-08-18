using System.Net;

namespace CopeID.API.Responses
{
    public class ForbiddenResponse : ErrorResponse
    {
        public ForbiddenResponse() : base(HttpStatusCode.Forbidden)
        { }

        public ForbiddenResponse(string message) : base(HttpStatusCode.Forbidden, message)
        { }
    }
}
