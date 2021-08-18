using System.Net;

namespace CopeID.API.Responses
{
    public class BadRequestResponse : ErrorResponse
    {
        public BadRequestResponse() : base(HttpStatusCode.BadRequest)
        { }

        public BadRequestResponse(string message) : base(HttpStatusCode.BadRequest, message)
        { }
    }
}
