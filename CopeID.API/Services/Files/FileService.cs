using CopeID.Context;
using CopeID.Models.Files;
using CopeID.QueryModels.Files;

namespace CopeID.API.Services.Files
{
    public class FileService : BaseQueryableEntityService<File, FileQueryModel>, IFileService
    {
        public FileService(CopeIdDbContext context) : base(context)
        { }
    }
}
