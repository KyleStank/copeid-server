using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using CopeID.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CopeID.API.Services
{
    public interface IPhotographService : IBaseCRUDService<Photograph> { }

    public class PhotographService : BaseCRUDService<Photograph>, IPhotographService
    {
        public PhotographService(CopeIdDbContext context) : base(context) { }
    }
}
