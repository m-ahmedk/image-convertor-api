using ImageConvertorAPI.Models.Enums;
using SixLabors.ImageSharp;

namespace ImageConvertorAPI.Services
{
    public class ImageConvertor : IImageConverter
    {
        public async Task<string> ConvertImageAsync(IFormFile file, ImageFormat fromFormat, ImageFormat toFormat)
        {
            var toFormatString = toFormat.ToString().ToLower();

            if (!ImageFormats.Formats.ContainsKey(toFormatString))
                throw new ArgumentException("Invalid format specified.");

            using var stream = file.OpenReadStream();

            using var image = await Image.LoadAsync(stream);

            var outputFilePath = Path.Combine(Path.GetTempPath(), $"converted_{Guid.NewGuid()}.{toFormatString}");

            await image.SaveAsync(outputFilePath, ImageFormats.GetEncoder(toFormatString));

            return outputFilePath;
        }
    }
}
