using System;
using System.Threading.Tasks;

using CopeID.API.ViewModels.Documents;
using CopeID.Models.Documents;
using CopeID.QueryModels.Documents;

namespace CopeID.API.Services.Documents
{
    public interface IDocumentService : IBaseQueryableEntityService<Document, DocumentQueryModel>
    {
        Task<string> GetUri(Guid id);

        bool IsValidMimeType(DocumentMimeType model);
    }
}
