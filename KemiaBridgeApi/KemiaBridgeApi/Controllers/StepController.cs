﻿using KemiaBridge.Domain.DTos;
using KemiaBridge.Domain.Entities;
using KemiaBridge.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace KemiaBridgeApi.Controllers
{
    [ApiController]
    [Route("api/v1/step")]
    public class StepController : ControllerBase
    {
        private readonly IStepService _stepService;

        public StepController(IStepService stepService)
        {
            _stepService = stepService;
        }

        [HttpPost("stationId")]
        public async Task<IActionResult> Add(int stationId, StepDto stepDto)
        {
            stepDto.SetStationId(stationId);
            await _stepService.AddAsync(stepDto);
            return Ok(new
            {
                stepId = stepDto.StepId,
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var steps = await _stepService.GetAllAsync();
            return Ok(steps);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var step = await _stepService.GetByIdAsync(id);
            if (step == null)
                return NotFound();
            
            return Ok(step);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, StepDto stepDto)
        {
            await _stepService.UpdateAsync(id, stepDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _stepService.DeleteAsync(id);
            return NoContent();
        }
    }
}
