using Microsoft.AspNetCore.Mvc;

using CopeID.API.Services.Photographs;
using CopeID.Models.Photographs;
using CopeID.QueryModels.Photographs;

namespace CopeID.API.Controllers.Photographs
{
    [ApiController]
    [Route("[controller]")]
    public class PhotographController : BaseEntityController<Photograph, PhotographQueryModel, IPhotographService>
    {
        public PhotographController(IPhotographService photographService) : base(photographService)
        { }
    }
}
