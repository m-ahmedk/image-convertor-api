using SixLabors.ImageSharp;

namespace ImageConvertorAPI.Services
{
    public class ImageConvertor : IImageConverter
    {
        private readonly IImageEncodingService _imageEncodingService;

        public ImageConvertor(IImageEncodingService imageEncodingService)
        {
            _imageEncodingService = imageEncodingService;
        }

        public async Task<string> ConvertImageAsync(IFormFile file, ImageFormat toFormat)
        {
            var toFormatString = toFormat.ToString().ToLower();

            using var stream = file.OpenReadStream();

            using var image = await Image.LoadAsync(stream);

            string fileExtension = Path.GetExtension(file.Name);

            string filename = Path.GetFileNameWithoutExtension(file.FileName);

            var outputFilePath = Path.Combine(Path.GetTempPath(), $"converted_{filename}.{toFormatString}");

            await image.SaveAsync(outputFilePath, _imageEncodingService.GetEncoder(toFormatString));

            return outputFilePath;
        }
    }
}