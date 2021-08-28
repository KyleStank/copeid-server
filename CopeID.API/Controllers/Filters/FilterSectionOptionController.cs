using Microsoft.AspNetCore.Mvc;

using CopeID.API.Services.Filters;
using CopeID.Models.Filters;

namespace CopeID.API.Controllers.Filters
{
    [ApiController]
    [Route("[controller]")]
    public class FilterSectionOptionController : BaseEntityController<FilterSectionOption, IFilterSectionOptionService>
    {
        public FilterSectionOptionController(IFilterSectionOptionService filterSectionOptionService) : base(filterSectionOptionService)
        { }
    }
}
