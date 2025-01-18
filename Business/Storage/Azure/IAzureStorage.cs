using Microsoft.AspNetCore.Http;

namespace Core.Storage.Azure
{
    public interface IAzureStorage
    {
        Task<string> AddProjectImageAsync(string containerName, string projectName, IFormFile file);
        Task<bool> DeleteFileAsync(string containerName, string fileName);
    }
}
