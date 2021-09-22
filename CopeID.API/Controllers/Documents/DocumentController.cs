using System.Net;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using CopeID.API.Services.Documents;
using CopeID.Models.Documents;
using CopeID.QueryModels.Documents;

namespace CopeID.API.Controllers.Documents
{
    [ApiController]
    [Route("[controller]")]
    public class DocumentController : BaseEntityQueryableController<Document, DocumentQueryModel, IDocumentService>
    {
        public DocumentController(IDocumentService documentService) : base(documentService)
        { }

        [HttpGet("VerifyMime/{mimeType}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public virtual IActionResult VerifyType(string mimeType)
        {
            return Ok(_entityService.IsValidMimeType(WebUtility.UrlDecode(mimeType)));
        }
    }
}
