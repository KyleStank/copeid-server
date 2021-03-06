using System.Threading.Tasks;

namespace CopeID.API.Services.AzureStorage
{
    public interface IAzureStorageService
    {
        void Initialize(string connectionString);

        string GetBlobUri(string path, string contentType = null);

        Task UploadBlobAsync(string path, byte[] data);

        Task<bool> DeleteBlobAsync(string path);
    }
}
