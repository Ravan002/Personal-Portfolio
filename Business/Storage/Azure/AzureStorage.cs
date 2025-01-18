using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Core.Constants;
using Core.Helpers.FileConverter;
using Microsoft.AspNetCore.Http;

namespace Core.Storage.Azure
{
    public class AzureStorage : IAzureStorage
    {
        private readonly BlobServiceClient _client;
        public AzureStorage()
        {
            _client = new BlobServiceClient(AppConstants.AzureConnectionString);
        }

        public async Task<string> AddProjectImageAsync(string containerName, string projectName, IFormFile file)
        {
            var container = _client.GetBlobContainerClient(containerName);
            var blobUploadOptions = new BlobUploadOptions
            {
                HttpHeaders = new BlobHttpHeaders
                {
                    ContentType = "image/webp"
                },
                Conditions = new BlobRequestConditions
                {
                    IfNoneMatch = ETag.All
                }
            };
            var (FileName, FileContent) = await ChangeImageFormat.ChangeFormatToWebp(file);
            var fileWithProject = $"{projectName}/{FileName}";
            var blobClient = container.GetBlobClient(fileWithProject);
            Response<BlobContentInfo> response = await blobClient.UploadAsync(FileContent, blobUploadOptions);
            FileContent.Dispose();
            return !response.GetRawResponse().IsError ? fileWithProject : AppConstants.ErrorResult;
        }

        public async Task<bool> DeleteFileAsync(string containerName, string fileName)
        {
            var container = _client.GetBlobContainerClient(containerName);
            var blob = container.GetBlobClient(fileName);
            var response = await blob.DeleteIfExistsAsync();
            return response.Value;
        }
    }
}
