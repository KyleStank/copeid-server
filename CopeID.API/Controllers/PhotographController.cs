using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using CopeID.API.Models;
using CopeID.API.Services;
using Microsoft.AspNetCore.Http;

namespace CopeID.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PhotographController : BaseCRUDController<Photograph, PhotographController, IPhotographService>
    {
        public PhotographController(ILogger<PhotographController> logger, IPhotographService photographService) : base(logger, photographService) { }
    }
}
