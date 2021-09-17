using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using CopeID.Context;
using CopeID.Models.Specimens;

namespace CopeID.API.Services.Specimens
{
    public class SpecimenFilterService : ISpecimenFilterService
    {
        private readonly CopeIdDbContext _context;
        private readonly DbSet<Specimen> _set;

        public SpecimenFilterService(CopeIdDbContext context)
        {
            _context = context;
            _set = _context.Set<Specimen>();
        }

        public async Task<object> FilterForObject(object obj)
        {
            return await FilterForEntity(obj as Specimen);
        }

        public async Task<Specimen> FilterForEntity(Specimen model)
        {
            IQueryable<Specimen> query = _set
                .AsNoTracking()
                .Where(s =>
                    (model != default && model != null)
                    && (model.Id == default || s.Id == model.Id)
                    && (model.GenusId == default || s.GenusId == model.GenusId)
                    && (model.PhotographId == default || s.PhotographId == model.PhotographId)
                    && (model.Gender == default || s.Gender == model.Gender)
                    && (model.Length == default || s.Length == model.Length)
                    && (model.SpecialCharacteristics == default || s.SpecialCharacteristics == model.SpecialCharacteristics)
                    && (model.Antenule == default || s.Antenule == model.Antenule)
                    && (model.Rostrum == default || s.Rostrum == model.Rostrum)
                    && (model.BodyShape == default || s.BodyShape == model.BodyShape)
                    && (model.Eyes == default || s.Eyes == model.Eyes)
                    && (model.Cephalosome == default || s.Cephalosome == model.Cephalosome)
                    //&& (model.Thorax == default || s.Thorax == model.Thorax)
                    && (model.Urosome == default || s.Urosome == model.Urosome)
                    && (model.Furca == default || s.Furca == model.Furca)
                    && (model.Setea == default || s.Setea == model.Setea)
                )
                .AsSplitQuery();

            return await query.FirstOrDefaultAsync();
        }
    }
}
