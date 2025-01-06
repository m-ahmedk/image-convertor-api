using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace ImageConvertorAPI.Models
{
    public class ImageConversionRequest
    {
        [Required]
        public IFormFile File { get; set; }

        [SwaggerSchema(Description = "ImageFormat")]
        [Required]
        //[RegularExpression("bmp|jpeg|jpg|png|gif|webp|tiff", ErrorMessage = "Invalid format.")]
        public ImageFormat FromFormat { get; set; } // Enforced allowed values

        [SwaggerSchema(Description = "ImageFormat")]
        [Required]
        //[RegularExpression("bmp|jpeg|jpg|png|gif|webp|tiff", ErrorMessage = "Invalid format.")]
        public ImageFormat ToFormat { get; set; } // Enforced allowed values
    }

}
