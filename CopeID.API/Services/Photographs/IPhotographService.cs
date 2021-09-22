using CopeID.Models.Photographs;
using CopeID.QueryModels.Photographs;

namespace CopeID.API.Services.Photographs
{
    public interface IPhotographService : IBaseQueryableEntityService<Photograph, PhotographQueryModel> { }
}
