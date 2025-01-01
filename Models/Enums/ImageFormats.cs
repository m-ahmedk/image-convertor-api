using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Formats.Bmp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.Formats.Gif;
using SixLabors.ImageSharp.Formats.Tiff;
using SixLabors.ImageSharp.Formats.Webp;
using System.ComponentModel.DataAnnotations;

namespace ImageConvertorAPI.Models.Enums
{
    public static class ImageFormats
    {
        public static readonly Dictionary<string, IImageEncoder> Formats = new()
        {
            { "bmp", new BmpEncoder() },
            { "jpeg", new JpegEncoder() },
            { "jpg", new JpegEncoder() },
            { "png", new PngEncoder() },
            { "gif", new GifEncoder() },
            { "webp", new WebpEncoder() },
            { "tiff", new TiffEncoder() }
        };

        public static IImageEncoder GetEncoder(string format)
        {
            var formatKey = format.ToLower();

            return Formats.ContainsKey(formatKey)
                ? Formats[formatKey]
                : throw new KeyNotFoundException("Format not supported.");
        }
    }
}