using CopeID.Models.Files;
using CopeID.QueryModels.Files;

namespace CopeID.API.Services.Files
{
    public interface IFileService : IBaseQueryableEntityService<File, FileQueryModel>
    { }
}
