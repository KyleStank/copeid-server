using System;
using System.Linq;
using System.Threading.Tasks;

using CopeID.API.Services.AzureStorage;
using CopeID.Context;
using CopeID.Core.Exceptions;
using CopeID.Models.Files;
using CopeID.QueryModels.Files;

namespace CopeID.API.Services.Files
{
    public class FileService : BaseQueryableEntityService<File, FileQueryModel>, IFileService
    {
        private readonly IAzureStorageService _azureStorageService;

        public FileService(CopeIdDbContext context, IAzureStorageService azureStorageService) : base(context)
        {
            _azureStorageService = azureStorageService;
        }

        public override async Task<File> Create(File model)
        {
            model.Path = Guid.NewGuid().ToString();
            await _azureStorageService.UploadBlobAsync(model.Path, Convert.FromBase64String(model.Data));

            File result = (await _context.AddAsync(model))?.Entity ?? null;
            if (result != null) await _context.SaveChangesAsync();
            else throw new EntityNotCreatedException<File>();

            return result;
        }

        public override async Task<File> Update(File model)
        {
            if (model == null || !_set.Any(x => x.Id == model.Id)) throw new EntityNotFoundException<File>();

            await _azureStorageService.DeleteBlobAsync(model.Path);
            await _azureStorageService.UploadBlobAsync(model.Path, Convert.FromBase64String(model.Data));

            File result = _set.Update(model)?.Entity ?? null;
            if (result != null) await _context.SaveChangesAsync();
            else throw new EntityNotUpdatedException<File>();

            return result;
        }

        public override async Task Delete(Guid id)
        {
            File model = await GetUntrackedAsync(id);
            if (model == null) throw new EntityNotFoundException<File>();

            await _azureStorageService.DeleteBlobAsync(model.Path);

            File result = _context.Remove(model)?.Entity ?? null;
            if (result != null) await _context.SaveChangesAsync();
            else throw new EntityNotDeletedException<File>();
        }
    }
}
