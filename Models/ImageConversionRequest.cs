using System.ComponentModel.DataAnnotations;

namespace ImageConvertorAPI.Models
{
    public class ImageConversionRequest
    {
        [Required]
        public IFormFile File { get; set; }

        [Required]
        [RegularExpression("bmp|jpeg|jpg|png|gif|webp|tiff", ErrorMessage = "Invalid format.")]
        public string FromFormat { get; set; } // Enforced allowed values

        [Required]
        [RegularExpression("bmp|jpeg|jpg|png|gif|webp|tiff", ErrorMessage = "Invalid format.")]
        public string ToFormat { get; set; } // Enforced allowed values
    }

}
