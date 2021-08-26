﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using CopeID.API.Services.Photographs;
using CopeID.API.QueryModels.Photographs;
using CopeID.Models.Photographs;

namespace CopeID.API.Controllers.Photographs
{
    [ApiController]
    [Route("[controller]")]
    public class PhotographController : BaseEntityController<Photograph, PhotographQueryModel, PhotographController, IPhotographService>
    {
        public PhotographController(ILogger<PhotographController> logger, IPhotographService photographService) : base(logger, photographService) { }
    }
}