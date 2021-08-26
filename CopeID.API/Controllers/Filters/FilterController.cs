using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using CopeID.API.Services.Filters;
using CopeID.API.QueryModels.Filters;
using CopeID.Models.Filters;

namespace CopeID.API.Controllers.Filters
{
    [ApiController]
    [Route("[controller]")]
    public class FilterController : BaseEntityController<Filter, FilterQueryModel, FilterController, IFilterService>
    {
        public FilterController(ILogger<FilterController> logger, IFilterService filterService)
            : base(logger, filterService) { }

        [HttpGet("EntityTypes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public virtual IActionResult GetEntityTypes()
        {
            return Ok(FindAllEntityTypes().Select(x => x.FullName));
        }

        [HttpGet("EntityTypes/{entityTypeName}/Properties")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual IActionResult GetEntityTypeProperties(string entityTypeName)
        {
            Type entityType = FindAllEntityTypes().FirstOrDefault(t => entityTypeName == t.FullName);
            if (entityType == null)
            {
                return CreateNotFoundResponse($"Entity type `{entityTypeName}` not found");
            }

            IEnumerable<string> props = entityType.GetProperties().Select(x => x.Name);
            return Ok(props);
        }

        protected virtual IEnumerable<Type> FindAllEntityTypes()
        {
            return Assembly.GetAssembly(typeof(Models.Entity))
                .GetTypes()
                .Where(x => !x.IsAbstract && x.IsClass && !x.FullName.Contains("Filter"));
        }
    }
}
