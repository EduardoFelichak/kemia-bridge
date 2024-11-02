using KemiaBridge.Domain.DTos;
using KemiaBridge.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace KemiaBridgeApi.Controllers
{
    [ApiController]
    [Route("api/v1/station")]
    public class StationController : ControllerBase
    {
        private readonly IStationService _stationService;
        private readonly IAddressService _addressService;
        private readonly IStepService    _stepService;
            
        public StationController(IStationService stationService, IAddressService addressService, IStepService stepService)
        {
            _stationService = stationService;
            _addressService = addressService;
            _stepService    = stepService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(StationDto stationDto)
        {
            if (stationDto.Address == null)
                return BadRequest("Endereço precisa ser informado");

            await _addressService.AddAsync( stationDto.Address );
            stationDto.SetAddressId(stationDto.Address.AddressId);

            await _stationService.AddAsync( stationDto );

            foreach (var step in stationDto.Steps)
            {
                step.StationId = stationDto.StationId;
                await _stepService.AddAsync( step );
            }

            return Ok( stationDto );
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var station = await _stationService.GetByIdAsync( id );
            if ( station == null )
                return NotFound();

            return Ok( station );
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var stations = await _stationService.GetAllAsync(); 

            return Ok( stations );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, StationDto stationDto)
        {
            await _stationService.UpdateAsync( id, stationDto );
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _stationService.DeleteAsync( id );
            return NoContent();
        }
    }
}
