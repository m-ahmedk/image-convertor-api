using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace ImageConvertorAPI.Models
{
    public class ImageConversionRequest
    {
        [Required]
        public IFormFile File { get; set; }

        [Required]
        public ImageFormat FromFormat { get; set; }

        [Required]
        public ImageFormat ToFormat { get; set; }
    }

}
