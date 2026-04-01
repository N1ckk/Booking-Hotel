using Booking_Hotel.Application.DTOs;
using Booking_Hotel.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Booking_Hotel.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;
        public UsersController(UserService userSerice)
        {
            _userService = userSerice;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            return Ok(user);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> RegisterUser(UserRegisterDto dto)
        {
            var user = await _userService.AddAsync(dto);
            return CreatedAtAction(
                nameof(GetById),
                new { id = user.Id },
                user);
        }
    }
}
