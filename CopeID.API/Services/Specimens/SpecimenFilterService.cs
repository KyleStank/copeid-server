using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using CopeID.API.FilterModels;
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
            return await FilterForEntity(obj as SpecimenFilterModel);
        }

        public async Task<Specimen> FilterForEntity(SpecimenFilterModel model)
        {
            IQueryable<Specimen> query = _set
                .AsNoTracking()
                .Where(s =>
                    (model != default)

                    // Basic Information
                    && (model.Id == default || s.Id == model.Id)
                    && (model.GenusId == default || s.GenusId == model.GenusId)
                    && (model.PhotographId == default || s.PhotographId == model.PhotographId)
                    && (model.Gender == default || s.Gender == model.Gender)
                    && (model.Length == default || s.Length == model.Length)
                    && (model.SpecialCharacteristics == default || s.SpecialCharacteristics == model.SpecialCharacteristics)

                    // Antenule
                    && (model.AntenuleDescription == default || s.AntenuleDescription == model.AntenuleDescription)
                    && (model.Antenule == default || s.Antenule == model.Antenule)

                    // Rostrum
                    && (model.RostrumDescription == default || s.RostrumDescription == model.RostrumDescription)
                    && (model.Rostrum == default || s.Rostrum == model.Rostrum)

                    // BodyShape
                    && (model.BodyShapeDescription == default || s.BodyShapeDescription == model.BodyShapeDescription)
                    && (model.BodyShape == default || s.BodyShape == model.BodyShape)

                    // Eyes
                    && (model.EyesDescription == default || s.EyesDescription == model.EyesDescription)
                    && (model.Eyes == default || s.Eyes == model.Eyes)

                    // Cephalosome
                    && (model.CephalosomeDescription == default || s.CephalosomeDescription == model.CephalosomeDescription)
                    && (model.Cephalosome == default || s.Cephalosome == model.Cephalosome)

                    // Thorax
                    && (model.ThoraxDescription == default || s.ThoraxDescription == model.ThoraxDescription)
                    && (model.ThoraxSegments == default || s.ThoraxSegments == model.ThoraxSegments)
                    && (model.ThoraxShape == default || s.ThoraxShape == model.ThoraxShape)

                    // Urosome
                    && (model.UrosomeDescription == default || s.UrosomeDescription == model.UrosomeDescription)
                    && (model.Urosome == default || s.Urosome == model.Urosome)

                    // Furca
                    && (model.FurcaDescription == default || s.FurcaDescription == model.FurcaDescription)
                    && (model.Furca == default || s.Furca == model.Furca)

                    // Setea
                    && (model.SeteaDescription == default || s.SeteaDescription == model.SeteaDescription)
                    && (model.Setea == default || s.Setea == model.Setea)
                )
                .Include(s => s.Genus)
                .Include(s => s.Photograph)
                .AsSplitQuery();

            return await query.FirstOrDefaultAsync();
        }
    }
}
