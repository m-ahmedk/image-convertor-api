using SixLabors.ImageSharp.Formats;

namespace ImageConvertorAPI.Interfaces
{
    public interface IImageEncodingService
    {
        IImageEncoder GetEncoder(string format);
    }
}