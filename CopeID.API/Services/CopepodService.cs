using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using CopeID.API.Models;

namespace CopeID.API.Services
{
    public class CopepodService
    {
        private readonly CopeIdDbContext _context;

        public CopepodService(CopeIdDbContext context)
        {
            _context = context;
        }
    }
}
