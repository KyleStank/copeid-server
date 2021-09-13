using Microsoft.AspNetCore.Mvc;

using CopeID.API.Services.Filters;
using CopeID.Models.Filters;
using CopeID.QueryModels.Filters;

namespace CopeID.API.Controllers.Filters
{
    [ApiController]
    [Route("[controller]")]
    public class FilterSectionPartOptionController : BaseEntityQueryableController<FilterSectionPartOption, FilterSectionPartOptionQueryModel, IFilterSectionPartOptionService>
    {
        public FilterSectionPartOptionController(IFilterSectionPartOptionService filterSectionOptionPartService) : base(filterSectionOptionPartService)
        { }
    }
}
