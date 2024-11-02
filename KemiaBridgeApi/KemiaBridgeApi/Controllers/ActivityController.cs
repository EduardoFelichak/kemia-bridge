using KemiaBridge.Domain.DTos;
using KemiaBridge.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace KemiaBridgeApi.Controllers
{
    [ApiController]
    [Route("api/v1/activity")]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityService _activityService;
        
        public ActivityController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(ActivityDto activityDto)
        {
            await _activityService.AddAsync(activityDto);
            return Ok(new
            {
                activityId = activityDto.ActivityId,
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _activityService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var activity = await _activityService.GetByIdAsync(id);
            if (activity == null) 
                return NotFound();

            return Ok(activity);
        }

        [HttpGet("/status/{status}")]
        public async Task<IActionResult> GetByStatus(int status)
        {
            return Ok(await _activityService.GetByStatusAsync(status));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ActivityDto activityDto)
        {
            await _activityService.UpdateAsync(id, activityDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _activityService.DeleteAsync(id);
            return NoContent();
        }
    }
}
