using Microsoft.AspNetCore.Mvc;
using PluginFramework.RequestModels;
using PluginFramework.Services;
using PluginFramework.Utility;

namespace PluginFramework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly ImageProcessor _imageProcessor;
        private readonly ILogger<ImageController> _logger;
        public ImageController(ImageProcessor imageProcessor, ILogger<ImageController> logger)
        {
            _imageProcessor = imageProcessor;
            _logger = logger;
        }

        [HttpPost("apply-effects")]
        public IActionResult ApplyEffects([FromBody] ImageProcessingRequest request)
        {
            _logger.LogInformation("Received request: {@Request}", request);

            if (request == null || request.Effects == null)
            {
                _logger.LogWarning("Invalid request payload.");
                return BadRequest("Invalid request payload.");
            }

            var image = new DummyImage();
            try
            {
                _imageProcessor.ApplyEffects(image, request.Effects);
                return Ok("Effects applied successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Internal server error.");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }

}
