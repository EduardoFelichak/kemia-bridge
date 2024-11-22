using KemiaBridge.Domain.DTos;
using KemiaBridge.Service.Interface;
using KemiaBridge.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace KemiaBridgeApi.Controllers
{
    [ApiController]
    [Route("api/v1/sensor")]
    public class SensorController : ControllerBase
    {
        private readonly ISensorService _sensorService;

        public SensorController(ISensorService sensorService)
        {
            _sensorService = sensorService;
        }

        [HttpPost("{stepId}")]
        public async Task<IActionResult> Add(int stepId, SensorDto sensorDto)
        {
            sensorDto.setStepId(stepId);
            await _sensorService.AddAsync(sensorDto);
            return Ok(new
            {
                sensorId = sensorDto.SensorId,
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var sensors = await _sensorService.GetAllAsync();
            return Ok(sensors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var sensor = await _sensorService.GetByIdAsync(id);
            if (sensor == null)
                return NotFound();
            return Ok(sensor);  
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, SensorDto sensorDto)
        {
            await _sensorService.UpdateAsync(id, sensorDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _sensorService.DeleteAsync(id);
            return NoContent();
        }
    }
}
