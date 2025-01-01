namespace ImageConvertorAPI.Interfaces
{
    public interface IImageConverter
    {
        Task<string> ConvertImageAsync(IFormFile file, string fromFormat, string toFormat);
    }
}
