﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using CopeID.API.Services.Genuses;
using CopeID.Models.Genuses;
using CopeID.QueryModels.Genuses;

namespace CopeID.API.Controllers.Genuses
{
    [ApiController]
    [Route("[controller]")]
    public class GenusController : BaseEntityController<Genus, GenusQueryModel, GenusController, IGenusService>
    {
        public GenusController(ILogger<GenusController> logger, IGenusService genusService) : base(logger, genusService) { }
    }
}
