using Microsoft.AspNetCore.Mvc;

using CopeID.API.Services.Filters;
using CopeID.Models.Filters;

namespace CopeID.API.Controllers.Filters
{
    [ApiController]
    [Route("[controller]")]
    public class FilterSectionController : BaseEntityController<FilterSection, IFilterSectionService>
    {
        public FilterSectionController(IFilterSectionService filterSectionService) : base(filterSectionService)
        { }
    }
}
