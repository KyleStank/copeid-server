using System.Threading.Tasks;

using CopeID.API.ViewModels.Filters;
using CopeID.Models.Filters;
using CopeID.QueryModels.Filters;

namespace CopeID.API.Services.Filters
{
    public interface IFilterService : IBaseQueryableEntityService<Filter, FilterQueryModel>
    {
        Task<Filter> GetSpecimenFilter();

        Task<FinalFilterResult> FilterResults(FilterResultRequestViewModel resultRequest);
    }
}
