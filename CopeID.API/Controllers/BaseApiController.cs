using System.Net;

using Microsoft.AspNetCore.Mvc;

using CopeID.API.Responses;

namespace CopeID.API.Controllers
{
    public abstract class BaseApiController : ControllerBase
    {
        protected ObjectResult CreateErrorResponse(ErrorResponse response)
        {
            if (response == null)
            {
                return CreateErrorResponse(new ErrorResponse(HttpStatusCode.InternalServerError, "An error occurred while processing your request"));
            }

            return StatusCode(response.Code, response);
        }

        protected ObjectResult CreateBadRequestResponse()
        {
            return CreateBadRequestResponse(null);
        }

        protected ObjectResult CreateBadRequestResponse(string message)
        {
            return CreateErrorResponse(new BadRequestResponse(message));
        }

        protected ObjectResult CreateForbiddenResponse()
        {
            return CreateForbiddenResponse(null);
        }

        protected ObjectResult CreateForbiddenResponse(string message)
        {
            return CreateErrorResponse(new ForbiddenResponse(message));
        }

        protected ObjectResult CreateInternalServerErrorResponse()
        {
            return CreateInternalServerErrorResponse(null);
        }

        protected ObjectResult CreateInternalServerErrorResponse(string message)
        {
            return CreateErrorResponse(new InternalServerErrorResponse(message));
        }

        protected ObjectResult CreateNoContentResponse()
        {
            return CreateNoContentResponse(null);
        }

        protected ObjectResult CreateNoContentResponse(string message)
        {
            return CreateErrorResponse(new NoContentResponse(message));
        }

        protected ObjectResult CreateNotFoundResponse()
        {
            return CreateNotFoundResponse(null);
        }

        protected ObjectResult CreateNotFoundResponse(string message)
        {
            return CreateErrorResponse(new NotFoundResponse(message));
        }

        protected ObjectResult CreateUnauthorizedResponse()
        {
            return CreateUnauthorizedResponse(null);
        }

        protected ObjectResult CreateUnauthorizedResponse(string message)
        {
            return CreateErrorResponse(new UnauthorizedResponse(message));
        }
    }
}
