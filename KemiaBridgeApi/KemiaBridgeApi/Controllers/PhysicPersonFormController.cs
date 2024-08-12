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
        public async Task<IActionResult> Add(PhysicPersonFormDto formDto)
        {
            await _physicPersonService.AddAsync( formDto.PhysicPerson! );

            formDto.Address!.setPersonId(formDto.PhysicPerson!.PersonId);
            await _addressService.AddAsync( formDto.Address );

            return Ok( new
            {
                personId  = formDto.PhysicPerson.PersonId,
                addressId = formDto.Address.AddressId,
            });
        }
    }
}
