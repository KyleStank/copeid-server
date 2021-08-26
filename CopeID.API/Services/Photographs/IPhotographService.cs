using CopeID.Models.Photographs;
using CopeID.QueryModels.Photographs;

namespace CopeID.API.Services.Photographs
{
    public interface IPhotographService : IBaseEntityService<Photograph, PhotographQueryModel> { }
}
