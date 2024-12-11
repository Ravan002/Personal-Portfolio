using Microsoft.AspNetCore.Http;
using SixLabors.ImageSharp.Formats.Webp;

namespace Core.Helpers.FileConverter
{
    public static class ChangeImageFormat
    {
        public static async Task<(string FileName, Stream FileContent)> ChangeFormatToWebp(IFormFile file, bool IsLoseless = false, int quality = 75)
        {
            using var image = await Image.LoadAsync(file.OpenReadStream());

            // Çıkış için bir MemoryStream oluştur
            var outputStream = new MemoryStream();

            // WebP formatı için encoder ayarla
            var encoder = new WebpEncoder
            {
                //Loseless 90 ele 
                Quality = quality,
                FileFormat = IsLoseless ? WebpFileFormatType.Lossless : WebpFileFormatType.Lossy,
            };

            // Görüntüyü WebP formatında kaydet
            await image.SaveAsync(outputStream, encoder);

            // Bellekteki stream başa sarılır
            outputStream.Position = 0;

            // Yeni dosya ismi uzantı ile değiştirilir
            var newFileName = Path.ChangeExtension(file.FileName, ".webp");

            return (newFileName, outputStream);
        }
    }
}
