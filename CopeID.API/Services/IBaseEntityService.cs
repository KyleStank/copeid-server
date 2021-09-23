using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using CopeID.API.ViewModels.Pagination;
using CopeID.Models;

namespace CopeID.API.Services
{
    public interface IBaseEntityService<TEntity> : IBaseApiService
        where TEntity : Entity
    {
        Task<List<TEntity>> GetAll();
        Task<PaginationResponse<TEntity>> GetPaged(PaginationRequest paginationRequest);
        Task<TEntity> GetTrackedAsync(Guid id);
        Task<TEntity> GetUntrackedAsync(Guid id);

        Task<TEntity> Create(TEntity model);

        Task<TEntity> Update(TEntity model);

        Task Delete(Guid id);
    }
}
