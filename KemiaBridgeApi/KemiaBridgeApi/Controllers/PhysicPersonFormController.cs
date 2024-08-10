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
            _addressService      = addressService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(PhysicPersonDto physicPersonDto, AddressDto addressDto)
        {
            await _physicPersonService.AddAsync(physicPersonDto);

            addressDto.setPersonId(physicPersonDto.PersonId);
            await _addressService.AddAsync(addressDto);

            return Ok( new
            {
                personId  = physicPersonDto.PersonId,
                addressId = addressDto.AddressId,
            });
        }
    }
}
