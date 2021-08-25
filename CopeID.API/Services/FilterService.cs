using System.Threading.Tasks;

using CopeID.API.BodyData;
using CopeID.Context;
using CopeID.Models;

namespace CopeID.API.Services
{
    public interface IFilterService
    {
        Task<Specimen> Filter(FilterData filterData);
    }

    public class FilterService : IFilterService
    {
        public FilterService(CopeIdDbContext context)
        { }

        public async Task<Specimen> Filter(FilterData filterData)
        {
            return null;
        }
    }
}
