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
        public async Task<IActionResult> Add(LegalPersonFormDto formDto)
        {
            await _legalPersonService.AddAsync( formDto.LegalPerson );

            formDto.Address.setPersonId(formDto.LegalPerson.PersonId);
            await _addressService.AddAsync( formDto.Address );

            return Ok(new
            {
                legalPersonId = formDto.LegalPerson.PersonId,
                addressId     = formDto.Address.AddressId,
            });
        }
    }
}
