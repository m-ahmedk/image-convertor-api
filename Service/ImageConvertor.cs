using SixLabors.ImageSharp;

namespace ImageConvertorAPI.Service
{
    public class ImageConvertor : IImageConverter
    {
        public async Task<string> ConvertImageAsync(IFormFile file, string fromFormat, string toFormat)
        {
            if (!ImageFormats.Formats.ContainsKey(toFormat.ToLower()))
                throw new ArgumentException("Invalid format specified.");

            using var stream = file.OpenReadStream();
            using var image = await Image.LoadAsync(stream);

            var outputFilePath = Path.Combine(Path.GetTempPath(), $"converted_{Guid.NewGuid()}.{toFormat.ToLower()}");

            var encoder = ImageFormats.GetEncoder(toFormat.ToLower());
            await image.SaveAsync(outputFilePath, encoder);

            return outputFilePath;
        }
    }
}
