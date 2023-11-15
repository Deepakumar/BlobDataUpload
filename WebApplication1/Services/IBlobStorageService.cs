namespace UploadUI.Services
{
    public interface IBlobStorageService
    {
        public Task UploadFileToBlobAsync(string blobName, byte[] fileBytes);
    }
}
