﻿using Microsoft.AspNetCore.Mvc;

using CopeID.API.Services.Filters;
using CopeID.Models.Filters;

namespace CopeID.API.Controllers.Filters
{
    [ApiController]
    [Route("[controller]")]
    public class FilterModelController : BaseEntityController<FilterModel, IFilterModelService>
    {
        public FilterModelController(IFilterModelService filterModelService) : base(filterModelService)
        { }
    }
}
