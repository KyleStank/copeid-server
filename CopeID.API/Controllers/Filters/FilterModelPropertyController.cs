using Microsoft.AspNetCore.Mvc;

using CopeID.API.Services.Filters;
using CopeID.Models.Filters;

namespace CopeID.API.Controllers.Filters
{
    [ApiController]
    [Route("[controller]")]
    public class FilterModelPropertyController : BaseEntityController<FilterModelProperty, IFilterModelPropertyService>
    {
        public FilterModelPropertyController(IFilterModelPropertyService filterModelPropertyService) : base (filterModelPropertyService)
        { }
    }
}
