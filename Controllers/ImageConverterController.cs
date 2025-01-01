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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> ConvertImage([FromForm] ImageConversionRequest request)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var outputFilePath = await _imageConverter.ConvertImageAsync(request.File, request.FromFormat, request.ToFormat);
                
                if (!System.IO.File.Exists(outputFilePath))
                    return StatusCode(500, "File conversion failed.");

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
