using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Helpers.Attributes;
using Project.Models;
using Project.Models.DTOs;
using Project.Models.Enums;
using Project.Services.UserServices;
using BCryptNet = BCrypt.Net.BCrypt;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("create-user")]
        public async Task<IActionResult> CreateUser(UserRequestDTO user)
        {
            var userToCreate = new User
            {
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Age = user.Age,
                Role = Role.User,
                Email = user.Email,
                PasswordHash = BCryptNet.HashPassword(user.Password)
            };
            await _userService.Create(userToCreate);
            return Ok();
        }
        [HttpPost("create-admin")]
        public async Task<IActionResult> CreateAdmin(UserRequestDTO user)
        {
            var userToCreate = new User
            {
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Age= user.Age,
                Role = Role.Admin,
                Email = user.Email,
                PasswordHash = BCryptNet.HashPassword(user.Password)
            };

            await _userService.Create(userToCreate);
            return Ok();
        }
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(UserRequestDTO user)
        {
            var response = _userService.Authenticate(user);
            if (response == null)
            {
                return BadRequest("Username or password is invalid!");
            }
            return Ok();
        }
        [Authorization(Role.Admin)]
        [HttpGet("admin")]
        public IActionResult GetAllAdmin()
        {
            var users = _userService.GetAllUsers();
            return Ok(users);
        }
        [Authorization(Role.User)]
        [HttpGet("user")]
        public IActionResult GetAllUser()
        {
            return Ok("User");
        }

        [HttpPut("edit/{id}"), Authorize]
        public IActionResult EditUser(Guid id, [FromBody] UserRequestDTO user)
        {
            var userFound = _userService.GetById(id);
            if (userFound == null)
            {
                return BadRequest("The ID does not exist.");
            }
            userFound.FirstName = user.FirstName;
            userFound.LastName = user.LastName;
            userFound.Email = user.Email;
            userFound.Age = user.Age;
            if (_userService.Save() == false)
            {
                return BadRequest("Database error.");
            }
            return Ok();
        }
        [HttpDelete("delete/{id}"), Authorize]
        public IActionResult DeleteUser(Guid id)
        {
            var userFound = _userService.GetById(id);
            if (userFound == null)
            {
                return BadRequest("The ID does not exist.");
            }
            _userService.Delete(userFound);
            if (_userService.Save() == false)
            {
                return BadRequest("Database error.");
            }
            return Ok();
        }
    }
}
