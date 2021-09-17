using System.Threading.Tasks;

using CopeID.API.ViewModels;
using CopeID.Models.Filters;
using CopeID.QueryModels.Filters;

namespace CopeID.API.Services.Filters
{
    public interface IFilterService : IBaseQueryableEntityService<Filter, FilterQueryModel>
    {
        Task<Filter> GetSpecimenFilter();

        Task<object> FilterResults(FilterResultRequestViewModel resultRequest);
    }
}
