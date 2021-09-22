using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    public class FilterModelController : BaseEntityQueryableController<FilterModel, FilterModelQueryModel, IFilterModelService>
    {
        public FilterModelController(IFilterModelService filterModelService) : base(filterModelService)
        { }

        [HttpGet("Types")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public virtual IActionResult GetTypes()
        {
            return Ok(_entityService.GetEntityTypes().Select(t => t.FullName));
        }

        [HttpGet("{id}/Properties")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<IActionResult> GetProperties(Guid id)
        {
            try
            {
                IEnumerable<FilterModelProperty> properties = await _entityService.GetProperties(id);
                return Ok(properties);
            }
            catch (EntityNotFoundException<FilterModelProperty> notFoundException)
            {
                return CreateNotFoundResponse(notFoundException.Message);
            }
        }

        [HttpGet("{id}/PropertyTypes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<IActionResult> GetPropertyTypes(Guid id)
        {
            try
            {
                IEnumerable<PropertyInfo> propertyTypes = await _entityService.GetTypePropertyInfos(id);
                return Ok(propertyTypes.Select(p => p.Name));
            }
            catch (EntityNotFoundException<FilterModel> notFoundException)
            {
                return CreateNotFoundResponse(notFoundException.Message);
            }
            catch (EntityException<FilterModel> exception)
            {
                return CreateBadRequestResponse(exception.Message);
            }
        }
    }
}
