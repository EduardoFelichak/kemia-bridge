using KemiaBridge.Domain.DTos;
using KemiaBridge.Domain.Enums;
using KemiaBridge.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace KemiaBridgeApi.Controllers
{
    [ApiController]
    [Route("api/v1/tank")]
    public class TankController : ControllerBase
    {
        private readonly ITankService _tankService;

        public TankController(ITankService tankService)
        {
            _tankService = tankService;
        }

        [HttpPost("{stepId}")]
        public async Task<IActionResult> Add(int stepId, TankDto tankDto)
        {
            tankDto.SetStepId(stepId);
            await _tankService.AddAsync( tankDto );
            return Ok(new
            {
                tankId = tankDto.TankId,
            });     
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tanks = await _tankService.GetAllAsync();
            return Ok(tanks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var tank = await _tankService.GetByIdAsync( id );
            if ( tank == null )
                return NotFound();
            return Ok(tank);
        }

        [HttpGet("/type/{type}")]
        public async Task<IActionResult> GetByType(TankType type)
        {
            var tanksByType = await _tankService.GetByTypeAsync( type );
            return Ok(tanksByType);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TankDto tankDto)
        {
            await _tankService.UpdateAsync( id, tankDto );
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _tankService.DeleteAsync( id );
            return NoContent();
        }
    }
}
