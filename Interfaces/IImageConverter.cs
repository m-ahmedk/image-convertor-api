namespace ImageConvertorAPI.Interfaces
{
    public interface IImageConverter
    {
        Task<string> ConvertImageAsync(IFormFile file, ImageFormat fromFormat, ImageFormat toFormat);
    }
}
