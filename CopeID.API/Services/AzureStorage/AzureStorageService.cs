using System;

using Azure.Storage.Blobs;
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
    }
}
