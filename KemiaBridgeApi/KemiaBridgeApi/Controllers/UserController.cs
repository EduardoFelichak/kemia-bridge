﻿using KemiaBridge.Domain.DTos;
using KemiaBridge.Domain.Enums;
using KemiaBridge.Service.Helpers;
using KemiaBridge.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Add([FromBody] UserDto userDto)
        {
            await _userService.AddAsync(userDto);
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
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UserDto userDto)
        {
            await _userService.UpdateAsync(id, userDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.DeleteAsync(id);
            return NoContent();
        }

        [HttpPost("auth")]
        public async Task<IActionResult> SignIn([FromQuery] string email, [FromQuery] string password)
        {
            var user = await _userService.SignInAsync(email, password);

            if (user == null)
                return NotFound("Invalid credentials");

            return Ok(TokenService.GenerateToken(user));
        }

        [HttpGet("type/{userType}")]
        public async Task<IActionResult> GetByType(UserType userType)
        {
            var usersByType = await _userService.GetByTypeAsync(userType);
            return Ok(usersByType);
        }
    }
}
