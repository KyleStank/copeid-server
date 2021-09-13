using Microsoft.AspNetCore.Mvc;

using CopeID.API.Services.Filters;
using CopeID.Models.Filters;
using CopeID.QueryModels.Filters;

namespace CopeID.API.Controllers.Filters
{
    [ApiController]
    [Route("[controller]")]
    public class FilterSectionPartController : BaseEntityQueryableController<FilterSectionPart, FilterSectionPartQueryModel, IFilterSectionPartService>
    {
        public FilterSectionPartController(IFilterSectionPartService filterSectionPartService) : base(filterSectionPartService)
        { }
    }
}
