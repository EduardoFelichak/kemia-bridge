using KemiaBridge.Domain.DTos;
using KemiaBridge.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace KemiaBridgeApi.Controllers
{
    [ApiController]
    [Route("api/v1/station/form")]
    public class StationFormController : ControllerBase
    {
        private readonly IStationService _stationService;
        private readonly IAddressService _addressService;

        public StationFormController(IStationService stationService, IAddressService addressService)
        {
            _stationService = stationService;
            _addressService = addressService;
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Add(int id, StationFormDto formDto)
        {
            await _addressService.AddAsync( formDto.Address! );

            formDto.Station!.AddressId = formDto.Address!.AddressId;
            await _stationService.AddAsync( formDto.Station );

            return Ok(new
            {
                stationId = formDto.Station.StationId,
                addressId = formDto.Address.AddressId,
            });
        }
    }
}
