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
        public async Task<IActionResult> Add(LegalPersonFormDto legalPersonFormDto)
        {
            await _legalPersonService.AddAsync(legalPersonFormDto.LegalPersonDto);

            legalPersonFormDto.AddressDto.setPersonId(legalPersonFormDto.LegalPersonDto.PersonId);
            await _addressService.AddAsync(legalPersonFormDto.AddressDto);

            return Ok(new
            {
                legalPersonId = legalPersonFormDto.LegalPersonDto.PersonId,
                addressId     = legalPersonFormDto.AddressDto.AddressId,
            });
        }
    }
}
