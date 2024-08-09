using KemiaBridge.Domain.DTos;
using KemiaBridge.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace KemiaBridgeApi.Controllers
{
    [ApiController]
    [Route("api/v1/person/physic/form")]
    public class PhysicPersonFormController : ControllerBase
    {
        private readonly IPhysicPersonService _physicPersonService;
        private readonly IAddressService      _addressService;
        
        public PhysicPersonFormController(IPhysicPersonService physicPersonService,
                                          IAddressService addressService)
        {
            _physicPersonService = physicPersonService;
            _addressService = addressService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(PhysicPersonFormDto physicPersonFormDto)
        {
            await _physicPersonService.AddAsync(physicPersonFormDto.PhysicPersonDto);

            physicPersonFormDto.AddressDto.setPersonId(physicPersonFormDto.PhysicPersonDto.PersonId);
            await _addressService.AddAsync(physicPersonFormDto.AddressDto);

            return Ok( new
            {
                personId  = physicPersonFormDto.PhysicPersonDto.PersonId,
                addressId = physicPersonFormDto.AddressDto.AddressId,
            });
        }
    }
}
