using CopeID.Models.Documents;
using CopeID.QueryModels.Documents;

namespace CopeID.API.Services.Documents
{
    public interface IDocumentService : IBaseQueryableEntityService<Document, DocumentQueryModel>
    { }
}
