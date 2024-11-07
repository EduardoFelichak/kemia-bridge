using KemiaBridge.Domain.DTos;
using KemiaBridge.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace KemiaBridgeApi.Controllers
{
    [ApiController]
    [Route("api/v1/address")]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService ?? throw new ArgumentNullException(nameof(addressService));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, AddressDto addressDto)
        {
            await _addressService.UpdateAsync(id, addressDto);
            return NoContent();
        }
    }
}
