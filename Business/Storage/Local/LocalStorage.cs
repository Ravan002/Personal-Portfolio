using Core.Helpers.FileConverter;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Business.Storage.Local
{
    public class LocalStorage(IWebHostEnvironment webHostEnvironment) : ILocalStorage
    {
        private readonly IWebHostEnvironment _webHostEnvironment = webHostEnvironment;
        public async Task<string> AddImage(IFormFile file, string projectName, string folderName)
        {
            var (FileName, FileContent) = await ChangeImageFormat.ChangeFormatToWebp(file);

            // Construct the directory and file paths
            var wwwFolderPath = Path.Combine(_webHostEnvironment.WebRootPath, folderName);
            var projectFolderPath = Path.Combine(wwwFolderPath, projectName);
            var imagePath = Path.Combine(projectFolderPath, FileName);

            try
            {
                // Ensure the directory exists
                Directory.CreateDirectory(projectFolderPath);

                // Save the file
                using var fileStream = new FileStream(imagePath, FileMode.CreateNew);
                await FileContent.CopyToAsync(fileStream);

                // Return relative path
                return $"{projectName}/{FileName}";
            }
            catch (Exception ex)
            {
                // Log and rethrow for other exceptions
                throw new InvalidOperationException("An error occurred while saving the image.", ex);
            }
        }
        public bool DeleteImage(string folderName, string imageWithProjectName)
        {
            var wwwFolderPath = Path.Combine(_webHostEnvironment.WebRootPath, folderName);
            var imagePath= Path.Combine(wwwFolderPath,imageWithProjectName);

            try
            {
                if (!File.Exists(imagePath))
                {
                    throw new FileNotFoundException("File not found", imagePath);
                }
                File.Delete(imagePath);
                return true;
            }
            catch(Exception ex)
            {
                throw new InvalidOperationException("error accured", ex);
            }
        }
    }
}
