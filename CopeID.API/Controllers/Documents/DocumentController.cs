using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using CopeID.API.Services.Documents;
using CopeID.API.ViewModels.Documents;
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

        [HttpGet("{id}/Uri")]
        public virtual async Task<IActionResult> GetDocumentUri(Guid id)
        {
            string uri = await _entityService.GetUri(id);
            return Ok(uri);
        }

        [HttpPost("VerifyMime")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public virtual IActionResult VerifyType([FromBody] DocumentMimeType model)
        {
            return Ok(_entityService.IsValidMimeType(model));
        }
    }
}
