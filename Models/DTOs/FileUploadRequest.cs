using System.ComponentModel.DataAnnotations;

namespace ImageConvertorAPI.Models.DTOs
{
    public class FileUploadRequest
    {
        [Required]
        public IFormFile File { get; set; }

        [Required]
        [MaxLength(10)]
        public string FromFormat { get; set; }

        [Required]
        [MaxLength(10)]
        public string ToFormat { get; set; }
    }

}
