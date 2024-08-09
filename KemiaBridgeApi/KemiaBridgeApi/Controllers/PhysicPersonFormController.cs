using KemiaBridge.Domain.DTos;
using KemiaBridge.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace KemiaBridgeApi.Controllers
{
    [ApiController]
    [Route("api/v1/physicPersonForm")]
    public class PhysicPersonFormController : ControllerBase
    {
        private readonly IPhysicPersonFormService _physicPersonFormService;
        
        public PhysicPersonFormController(IPhysicPersonFormService physicPersonFormService)
        {
            _physicPersonFormService = physicPersonFormService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(PhysicPersonFormDto physicPersonFormDto)
        {
            await _physicPersonFormService.AddAsync( physicPersonFormDto );
            return Ok( new
            {
                personId  = physicPersonFormDto.PhysicPersonDto.PersonId,
                addressId = physicPersonFormDto.AddressDto.AddressId,
            });
        }
    }
}
