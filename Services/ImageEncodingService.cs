using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Formats.Bmp;
using SixLabors.ImageSharp.Formats.Gif;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Formats.Pbm;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.Formats.Qoi;
using SixLabors.ImageSharp.Formats.Tga;
using SixLabors.ImageSharp.Formats.Tiff;
using SixLabors.ImageSharp.Formats.Webp;

namespace ImageConvertorAPI.Services
{
    public class ImageEncodingService : IImageEncodingService
    {
        // formats initialization
        private readonly Dictionary<string, IImageEncoder> _formats = new()
        {
            { "bmp", new BmpEncoder() },
            { "gif", new GifEncoder() },
            { "jpeg", new JpegEncoder() },
            { "jpg", new JpegEncoder() },
            { "png", new PngEncoder() },
            { "pbm", new PbmEncoder() },
            { "qoi", new QoiEncoder() },
            { "tiff", new TiffEncoder() },
            { "tga", new TgaEncoder() },
            { "webp", new WebpEncoder() }
        };

        // return format based on param passed
        public IImageEncoder GetEncoder(string format)
        {
            var formatKey = format.ToLower();

            return _formats.ContainsKey(formatKey)
                ? _formats[formatKey]
                : throw new KeyNotFoundException("Format not supported.");
        }
    }
}