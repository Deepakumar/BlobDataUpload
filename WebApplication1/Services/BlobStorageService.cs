using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;

namespace UploadUI.Services
{
    public class BlobStorageService : IBlobStorageService
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;

        public BlobStorageService(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("AzureBlobStorageConnection");
        }

        public async Task UploadFileToBlobAsync(string blobName, byte[] fileBytes)
        {
            var blobServiceClient = new BlobServiceClient(_connectionString);

            var _containerName = _configuration.GetValue<string>("AzureBlobStorage:ContainerName");
            var blobContainerClient = blobServiceClient.GetBlobContainerClient(_containerName);
            var blobClient = blobContainerClient.GetBlobClient(blobName);

            using (MemoryStream memoryStream = new MemoryStream(fileBytes))
            {
                await blobClient.UploadAsync(memoryStream, true);
            }
        }

    }
}
