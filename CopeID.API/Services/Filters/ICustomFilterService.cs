using System.Threading.Tasks;

using CopeID.API.FilterModels;

namespace CopeID.API.Services.Filters
{
    public interface ICustomFilterService
    {
        Task<object[]> FilterForResults(IFilterModel filterModel);
    }
}
