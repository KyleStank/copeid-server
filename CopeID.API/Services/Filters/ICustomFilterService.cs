using System.Threading.Tasks;

namespace CopeID.API.Services.Filters
{
    public interface ICustomFilterService
    {
        Task<object> FilterForObject(object obj);
    }
}
