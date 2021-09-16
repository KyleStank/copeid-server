using System.Threading.Tasks;

using CopeID.Models.Specimens;

namespace CopeID.API.Services.Specimens
{
    public class SpecimenFilterService : ISpecimenFilterService
    {
        public async Task<object> FilterForObject(object obj)
        {
            return await FilterForEntity(obj as Specimen);
        }

        public async Task<Specimen> FilterForEntity(Specimen model)
        {
            return null;
        }
    }
}
