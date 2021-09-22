using Microsoft.AspNetCore.Mvc;

using CopeID.API.Services.Filters;
using CopeID.Models.Filters;
using CopeID.QueryModels.Filters;

namespace CopeID.API.Controllers.Filters
{
    [ApiController]
    [Route("[controller]")]
    public class FilterSectionController : BaseEntityQueryableController<FilterSection, FilterSectionQueryModel, IFilterSectionService>
    {
        public FilterSectionController(IFilterSectionService filterSectionService) : base(filterSectionService)
        { }
    }
}
