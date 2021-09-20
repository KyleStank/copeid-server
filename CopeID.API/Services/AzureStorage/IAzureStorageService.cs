using System.Threading.Tasks;

namespace CopeID.API.Services.AzureStorage
{
    public interface IAzureStorageService
    {
        void Initialize(string connectionString);

        Task UploadBlobAsync(string path, byte[] data);

        Task<bool> DeleteBlobAsync(string path);
    }
}
