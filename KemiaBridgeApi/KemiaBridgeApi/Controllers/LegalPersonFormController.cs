using KemiaBridge.Domain.DTos;
using KemiaBridge.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace KemiaBridgeApi.Controllers
{
    [ApiController]
    [Route("api/v1/person/legal/form")]
    public class LegalPersonFormController : ControllerBase
    {
        private readonly ILegalPersonService _legalPersonService;
        private readonly IAddressService     _addressService;

        public LegalPersonFormController(ILegalPersonService legalPersonService, 
                                         IAddressService addressService)
        {
            _legalPersonService = legalPersonService;
            _addressService = addressService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(LegalPersonDto legalPersonDto, AddressDto addressDto)
        {
            await _legalPersonService.AddAsync(legalPersonDto);

            addressDto.setPersonId(legalPersonDto.PersonId);
            await _addressService.AddAsync(addressDto);

            return Ok(new
            {
                legalPersonId = legalPersonDto.PersonId,
                addressId     = addressDto.AddressId,
            });
        }
    }
}
