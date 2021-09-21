using System;
using System.Linq;
using System.Threading.Tasks;

using CopeID.API.Services.AzureStorage;
using CopeID.Context;
using CopeID.Core.Exceptions;
using CopeID.Models.Documents;
using CopeID.QueryModels.Documents;

namespace CopeID.API.Services.Documents
{
    public class DocumentService : BaseQueryableEntityService<Document, DocumentQueryModel>, IDocumentService
    {
        private readonly IAzureStorageService _azureStorageService;
        private readonly string[] _validMimeTypes = new string[]
        {
            "image/gif",
            "image/jpeg",
            "image/png"
        };

        public DocumentService(CopeIdDbContext context, IAzureStorageService azureStorageService) : base(context)
        {
            _azureStorageService = azureStorageService;
        }

        public override async Task<Document> Create(Document model)
        {
            model.Path = Guid.NewGuid().ToString();
            await _azureStorageService.UploadBlobAsync(model.Path, Convert.FromBase64String(model.Data));

            Document result = (await _context.AddAsync(model))?.Entity ?? null;
            if (result != null) await _context.SaveChangesAsync();
            else throw new EntityNotCreatedException<Document>();

            return result;
        }

        public override async Task<Document> Update(Document model)
        {
            if (model == null || !_set.Any(x => x.Id == model.Id)) throw new EntityNotFoundException<Document>();

            await _azureStorageService.DeleteBlobAsync(model.Path);
            await _azureStorageService.UploadBlobAsync(model.Path, Convert.FromBase64String(model.Data));

            Document result = _set.Update(model)?.Entity ?? null;
            if (result != null) await _context.SaveChangesAsync();
            else throw new EntityNotUpdatedException<Document>();

            return result;
        }

        public override async Task Delete(Guid id)
        {
            Document model = await GetUntrackedAsync(id);
            if (model == null) throw new EntityNotFoundException<Document>();

            await _azureStorageService.DeleteBlobAsync(model.Path);

            Document result = _context.Remove(model)?.Entity ?? null;
            if (result != null) await _context.SaveChangesAsync();
            else throw new EntityNotDeletedException<Document>();
        }

        public virtual bool IsValidMimeType(string mimeType)
        {
            return _validMimeTypes.Contains(mimeType);
        }
    }
}
