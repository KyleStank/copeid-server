using Microsoft.AspNetCore.Mvc;

using CopeID.API.Services.Files;
using CopeID.Models.Files;
using CopeID.QueryModels.Files;

namespace CopeID.API.Controllers.Documents
{
    [ApiController]
    [Route("[controller]")]
    public class FileController : BaseEntityQueryableController<File, FileQueryModel, IFileService>
    {
        public FileController(IFileService fileService) : base(fileService)
        { }
    }
}
