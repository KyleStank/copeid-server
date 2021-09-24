using System;
using System.Linq;
using System.Threading.Tasks;

using CopeID.API.Services.AzureStorage;
using CopeID.API.ViewModels.Documents;
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
            if (model == null) throw new EntityNotCreatedException<Document>();
            if (!IsValidMimeType(new DocumentMimeType(model.MimeType))) throw new EntityNotCreatedException<Document>("Unsupported MIME Type");

            model.Path = Guid.NewGuid().ToString();
            await _azureStorageService.UploadBlobAsync(model.Path, Convert.FromBase64String(model.Data));

            return await base.Create(model);
        }

        public override async Task<Document> Update(Document model)
        {
            if (model == null || !_set.Any(x => x.Id == model.Id)) throw new EntityNotFoundException<Document>();
            if (!IsValidMimeType(new DocumentMimeType(model.MimeType))) throw new EntityNotUpdatedException<Document>("Unsupported MIME Type");

            await _azureStorageService.DeleteBlobAsync(model.Path);
            await _azureStorageService.UploadBlobAsync(model.Path, Convert.FromBase64String(model.Data));

            return await base.Update(model);
        }

        public override async Task Delete(Guid id)
        {
            Document model = await GetUntrackedAsync(id);
            if (model == null) throw new EntityNotFoundException<Document>();

            await _azureStorageService.DeleteBlobAsync(model.Path);

            await base.Delete(id);
        }

        public virtual async Task<string> GetUri(Guid id, string contentType = null)
        {
            Document document = await GetUntrackedAsync(id);
            return _azureStorageService.GetBlobUri(document.Path, document.MimeType);
        }

        public virtual bool IsValidMimeType(DocumentMimeType model)
        {
            return model != null && _validMimeTypes.Contains(model?.MimeType);
        }
    }
}
