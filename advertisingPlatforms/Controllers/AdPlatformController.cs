using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using advertisingPlatforms.Services;
namespace advertisingPlatforms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdPlatformController : ControllerBase
    {
        private readonly AdPlatformServices _service;

        public AdPlatformController(AdPlatformServices service)
        {
            _service = service;
        }

        [HttpPost("load")]
        public IActionResult Load([FromBody] string filePath)
        {
            try
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "platforms.txt");
                _service.LoadFromFile(path);
                return Ok("Файл успешно загружен");
            }
            catch (Exception ex)
            {
                return BadRequest($"Ошибка при загрузке файла{ex.Message}");
            }
            
        }

        [HttpPost("search")]
        public IActionResult Search([FromBody] string location)
        {
            if (string.IsNullOrWhiteSpace(location))
                return BadRequest("Локация не указана");

            var result = _service.Search(location);
            if (result.Count == 0)
                return BadRequest("Локация не найдена");

            return Ok(result);

        }
    }
}
