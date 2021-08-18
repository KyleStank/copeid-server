using System.Net;

using Microsoft.AspNetCore.Mvc;

using CopeID.API.Responses;

namespace CopeID.API.Controllers
{
    public abstract class BaseApiController : ControllerBase
    {
        [NonAction]
        public ObjectResult CreateErrorRequest(ErrorResponse response)
        {
            if (response == null)
            {
                return CreateErrorRequest(new ErrorResponse(HttpStatusCode.InternalServerError, "An error occurred while processing your request"));
            }

            return StatusCode(response.Code, response);
        }

        [NonAction]
        public ObjectResult CreateBadRequest()
        {
            return CreateBadRequest(null);
        }

        [NonAction]
        public ObjectResult CreateBadRequest(string message)
        {
            return CreateErrorRequest(new BadRequestResponse(message));
        }

        [NonAction]
        public ObjectResult CreateForbiddenRequest()
        {
            return CreateForbiddenRequest(null);
        }

        [NonAction]
        public ObjectResult CreateForbiddenRequest(string message)
        {
            return CreateErrorRequest(new ForbiddenResponse(message));
        }

        [NonAction]
        public ObjectResult CreateInternalServerErrorRequest()
        {
            return CreateInternalServerErrorRequest(null);
        }

        [NonAction]
        public ObjectResult CreateInternalServerErrorRequest(string message)
        {
            return CreateErrorRequest(new InternalServerErrorResponse(message));
        }

        [NonAction]
        public ObjectResult CreateNotFoundRequest()
        {
            return CreateNotFoundRequest(null);
        }

        [NonAction]
        public ObjectResult CreateNotFoundRequest(string message)
        {
            return CreateErrorRequest(new NotFoundResponse(message));
        }

        [NonAction]
        public ObjectResult CreateUnauthorizedRequest()
        {
            return CreateUnauthorizedRequest(null);
        }

        [NonAction]
        public ObjectResult CreateUnauthorizedRequest(string message)
        {
            return CreateErrorRequest(new UnauthorizedResponse(message));
        }
    }
}
