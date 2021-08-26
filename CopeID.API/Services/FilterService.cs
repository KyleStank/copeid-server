using CopeID.API.QueryModels;
using CopeID.Context;
using CopeID.Models;

namespace CopeID.API.Services
{
    public interface IFilterService : IBaseEntityService<Filter, FilterQueryModel> { }

    public class FilterService : BaseEntityService<Filter, FilterQueryModel>, IFilterService
    {
        public FilterService(CopeIdDbContext context) : base(context) { }
    }
}
