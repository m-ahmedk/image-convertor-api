using Microsoft.AspNetCore.Mvc;

namespace ImageConvertorAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImageConverterController : ControllerBase
    {
        private readonly IImageConverter _imageConverter;

        public ImageConverterController(IImageConverter imageConverterService)
        {
            _imageConverter = imageConverterService;
        }

        [HttpPost("convert")]
        public async Task<IActionResult> ConvertImage([FromForm] IFormFile file, [FromForm] string fromFormat, [FromForm] string toFormat)
        {
            if (file == null || string.IsNullOrWhiteSpace(fromFormat) || string.IsNullOrWhiteSpace(toFormat))
                return BadRequest("Invalid input.");

            try
            {
                var outputFilePath = await _imageConverter.ConvertImageAsync(file, fromFormat, toFormat);
                var fileBytes = await System.IO.File.ReadAllBytesAsync(outputFilePath);
                System.IO.File.Delete(outputFilePath);
                return File(fileBytes, "application/octet-stream", Path.GetFileName(outputFilePath));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
