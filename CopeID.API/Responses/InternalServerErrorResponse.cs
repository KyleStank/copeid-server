using System.Net;

namespace CopeID.API.Responses
{
    public class InternalServerErrorResponse : ErrorResponse
    {
        public InternalServerErrorResponse() : base(HttpStatusCode.InternalServerError)
        { }

        public InternalServerErrorResponse(string message) : base(HttpStatusCode.InternalServerError, message)
        { }
    }
}
