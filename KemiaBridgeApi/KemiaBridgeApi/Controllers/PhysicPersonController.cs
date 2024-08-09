using KemiaBridge.Domain.DTos;
using KemiaBridge.Service.Interface;
using KemiaBridge.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace KemiaBridgeApi.Controllers
{
    [ApiController]
    [Route("api/v1/physicPerson")]
    public class PhysicPersonController : ControllerBase
    {
        private readonly IPhysicPersonService _physicPersonService;

        public PhysicPersonController(IPhysicPersonService physicPersonService)
        {
            _physicPersonService = physicPersonService ?? throw new ArgumentNullException(nameof(physicPersonService));
        }

        [HttpPost]
        public async Task<IActionResult> Add(PhysicPersonDto physicPersonDto)
        {
            await _physicPersonService.AddAsync(physicPersonDto);
            return CreatedAtAction(nameof(GetById), new { id = physicPersonDto.PersonId }, physicPersonDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var physicPerson = await _physicPersonService.GetByIdAsync(id);
            if (physicPerson == null)
                return NotFound();

            return Ok(physicPerson);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var physicPeople = await _physicPersonService.GetAllAsync();
            return Ok(physicPeople);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PhysicPersonDto physicPersonDto)
        {
            await _physicPersonService.UpdateAsync(id, physicPersonDto);    
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _physicPersonService.DeleteAsync(id);
            return NoContent();
        }
    }
}
