using CopeID.Context;

namespace CopeID.API.Services
{
    public interface IBaseApiService
    {
        CopeIdDbContext Context { get; }
    }
}
