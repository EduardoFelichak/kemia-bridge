using KemiaBridge.Domain.DTos;
using KemiaBridge.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace KemiaBridgeApi.Controllers
{
    [ApiController]
    [Route("api/v1/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(UserDto userDto)
        {
            await _userService.AddAsync( userDto );
            return Ok(new
            {
                userId = userDto.UserId,
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetByIdAsync( id );
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UserDto userDto)
        {
            await _userService.UpdateAsync( id, userDto );
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.DeleteAsync( id );
            return NoContent();
        }

        [HttpGet("{email};{password}")]
        public async Task<IActionResult> SignIn(string email, string password)
        {
            var user = await _userService.SignInAsync( email, password );
            if (user == null)
                return NotFound("Invalid credentials");
            return Ok();
        }
    }
}
