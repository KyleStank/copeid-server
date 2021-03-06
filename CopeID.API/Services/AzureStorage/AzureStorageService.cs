using System;
using System.IO;
using System.Threading.Tasks;

using Azure.Storage.Blobs;
using Azure.Storage.Sas;
using Microsoft.Extensions.Options;

using CopeID.API.Configurations;

namespace CopeID.API.Services.AzureStorage
{
    public class AzureStorageService : IAzureStorageService
    {
        private readonly DocumentStorageConfig _documentStorageConfig;

        private BlobServiceClient _blobServiceClient;
        private BlobContainerClient _blobContainerClient;

        public AzureStorageService(IOptions<DocumentStorageConfig> documentStorageConfig)
        {
            _documentStorageConfig = documentStorageConfig?.Value;
        }

        public void Initialize(string connectionString)
        {
            if (connectionString == null) throw new ApplicationException("Null Azure Storage connection string");
            if (_documentStorageConfig == null) throw new ApplicationException("No Document Storage configuration has been supplied");
            if (_documentStorageConfig.ContainerName == null) throw new ApplicationException("Null Azure Storage container name");

            _blobServiceClient = new BlobServiceClient(connectionString);
            _blobContainerClient = _blobServiceClient.GetBlobContainerClient(_documentStorageConfig.ContainerName);
            _blobContainerClient.CreateIfNotExists();
        }

        public string GetBlobUri(string path, string contentType = null)
        {
            BlobClient blobClient = _blobContainerClient.GetBlobClient(path);
            BlobSasBuilder sasBuilder = new BlobSasBuilder(BlobSasPermissions.Read, DateTimeOffset.Now.AddDays(1));
            if (contentType != null) sasBuilder.ContentType = contentType;

            return blobClient.GenerateSasUri(sasBuilder).AbsoluteUri;
        }

        public async Task UploadBlobAsync(string path, byte[] data)
        {
            using (MemoryStream ms = new MemoryStream(data))
            {
                await _blobContainerClient.UploadBlobAsync(path, ms);
            }
        }

        public async Task<bool> DeleteBlobAsync(string path)
        {
            BlobClient blobClient = _blobContainerClient.GetBlobClient(path);
            return await blobClient.DeleteIfExistsAsync();
        }
    }
}
