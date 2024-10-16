using KemiaBridge.Domain.DTos;
using KemiaBridge.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace KemiaBridgeApi.Controllers
{
    [ApiController]
    [Route("api/v1/squeezer")]
    public class SqueezerController : ControllerBase
    {
        private readonly ISqueezerService _squeezerService;

        public SqueezerController(ISqueezerService squeezerService)
        {
            _squeezerService = squeezerService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(SqueezerDto squeezerDto)
        {
            await _squeezerService.AddAsync(squeezerDto);
            return Ok(new
            {
                squeezerId = squeezerDto.SqueezerId,
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var squeezers = await _squeezerService.GetAllAsync();
            return Ok(squeezers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var squeezer = await _squeezerService.GetByIdAsync(id);
            if (squeezer == null)
                return NotFound();
            return Ok(squeezer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, SqueezerDto squeezerDto)
        {
            await _squeezerService.UpdateAsync(id, squeezerDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _squeezerService.DeleteAsync(id);
            return NoContent();
        }
    }
}
