using KemiaBridge.Domain.DTos;
using KemiaBridge.Service.Interface;
using KemiaBridge.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace KemiaBridgeApi.Controllers
{
    [ApiController]
    [Route("api/v1/legalPerson")]
    public class LegalPersonController : ControllerBase
    {
        private readonly ILegalPersonService _legalPersonService;
        
        public LegalPersonController(ILegalPersonService legalPersonService)
        {
            _legalPersonService = legalPersonService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(LegalPersonDto legalPersonDto)
        {
            await _legalPersonService.AddAsync(legalPersonDto);
            return CreatedAtAction(nameof(GetById), new { id = legalPersonDto.PersonId }, legalPersonDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var legalPerson = await _legalPersonService.GetByIdAsync(id);
            if (legalPerson == null)
                return NotFound();

            return Ok(legalPerson);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var legalPeople = await _legalPersonService.GetAllAsync();
            return Ok(legalPeople); 
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, LegalPersonDto legalPersonDto)
        {
            await _legalPersonService.UpdateAsync(id, legalPersonDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _legalPersonService.DeleteAsync(id);
            return NoContent();
        }
    }
}
