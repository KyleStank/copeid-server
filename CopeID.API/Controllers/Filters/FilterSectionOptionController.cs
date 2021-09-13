using Microsoft.AspNetCore.Mvc;

using CopeID.API.Services.Filters;
using CopeID.Models.Filters;
using CopeID.QueryModels.Filters;

namespace CopeID.API.Controllers.Filters
{
    [ApiController]
    [Route("[controller]")]
    public class FilterSectionOptionController : BaseEntityQueryableController<FilterSectionOption, FilterSectionOptionQueryModel, IFilterSectionOptionService>
    {
        public FilterSectionOptionController(IFilterSectionOptionService filterSectionOptionService) : base(filterSectionOptionService)
        { }
    }
}
