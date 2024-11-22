using KemiaBridge.Domain.DTos;
using KemiaBridge.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace KemiaBridgeApi.Controllers
{
    [ApiController]
    [Route("api/v1/sensorReading")]
    public class SensorReadingController : ControllerBase
    {
        private readonly ISensorReadingService _sensorReadingService;

        public SensorReadingController(ISensorReadingService sensorReadingService)
        {
            _sensorReadingService = sensorReadingService;
        }

        [HttpPost("{sensorId}/{userId}")]
        public async Task<IActionResult> Add(int sensorId, int userId, SensorReadingDto sensorReadingDto)
        {
            sensorReadingDto.setSensorId(sensorId);
            sensorReadingDto.setUserId(userId);
            await _sensorReadingService.AddAsync(sensorReadingDto);
            return Ok(sensorReadingDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _sensorReadingService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _sensorReadingService.GetByIdAsync(id));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, SensorReadingDto sensorReadingDto)
        {
            await _sensorReadingService.UpdateAsync(id, sensorReadingDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _sensorReadingService.DeleteAsync(id);
            return NoContent();
        }
    }
}
