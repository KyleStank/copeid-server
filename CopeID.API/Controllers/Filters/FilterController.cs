﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

using CopeID.API.Services.Filters;
using CopeID.Core.Exceptions;
using CopeID.Models.Filters;
using CopeID.QueryModels.Filters;

namespace CopeID.API.Controllers.Filters
{
    [ApiController]
    [Route("[controller]")]
    public class FilterController : BaseEntityQueryableController<Filter, FilterQueryModel, IFilterService>
    {
        public FilterController(IFilterService filterService) : base(filterService)
        { }

        [HttpGet("{id}/Sections")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<IActionResult> GetSections(Guid id)
        {
            try
            {
                IEnumerable<FilterSection> sections = await _entityService.GetSections(id);
                return Ok(sections);
            }
            catch (EntityNotFoundException<FilterSection> notFoundException)
            {
                return CreateNotFoundResponse(notFoundException.Message);
            }
        }
    }
}
