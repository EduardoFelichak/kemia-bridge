using KemiaBridge.Domain.DTos;
using KemiaBridge.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace KemiaBridgeApi.Controllers
{
    [ApiController]
    [Route("api/v1/personStation")]
    public class PersonStationController : ControllerBase
    {
        private readonly IPersonStationService _personStationService;

        public PersonStationController(IPersonStationService personStationService)
        {
            _personStationService = personStationService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(PersonStationDto personStationDto)
        {
            await _personStationService.AddAsync( personStationDto );
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var personStations = await _personStationService.GetAllAsync();
            return Ok( personStations );
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(PersonStationDto personStationDto)
        {
            await _personStationService.DeleteAsync( personStationDto );
            return NoContent();
        }
    }
}
