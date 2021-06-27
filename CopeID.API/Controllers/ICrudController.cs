using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

namespace CopeID.API.Controllers
{
    public interface ICrudController<TEntity>
    {
        //IActionResult GetAllEntities();
        Task<IActionResult> GetEntity(Guid id);

        //Task<IActionResult> CreateEntity(TEntity model);

        //Task<IActionResult> UpdateEntity(TEntity model);

        //Task<IActionResult> DeleteEntity(Guid id);
    }
}
