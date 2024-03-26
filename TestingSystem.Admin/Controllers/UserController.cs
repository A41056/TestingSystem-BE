using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestingSystem.Core.Services.Interfaces;
using TestingSystem.Data.Models.User;

namespace TestingSystem.Admin.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Admin")]

public class UserController : BaseController
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("add")]
    public async Task<IActionResult> AddUser([FromBody] CreateUserRequest request)
    {
        try
        {
            await _userService.AddUser(request);
            return Ok("User added successfully");
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet("list")]
    public async Task<IActionResult> GetListUser([FromQuery] SearchingUserRequest request)
    {
        try
        {
            var userList = await _userService.GetListUser(request);
            return Ok(userList);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetUser(Guid userId)
    {
        try
        {
            var user = await _userService.GetUser(userId);
            if (user == null)
                return NotFound("User not found");

            return Ok(user);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPost("register")]
    [AllowAnonymous] // Allow non-authenticated users to register
    public async Task<IActionResult> RegisterUser([FromBody] CreateUserRequest request)
    {
        try
        {
            await _userService.RegisterUser(request);
            return Ok("User registered successfully");
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateUserInfo([FromBody] UpdateUserRequest request)
    {
        try
        {
            await _userService.UpdateUserInfo(request);
            return Ok("User information updated successfully");
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}
