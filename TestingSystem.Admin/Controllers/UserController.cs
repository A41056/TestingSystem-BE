using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestingSystem.Core.Services.Interfaces;
using TestingSystem.Data.Models;
using TestingSystem.Data.Models.User;

namespace TestingSystem.Admin.Controllers;

public class UserController : BaseController
{
    private readonly IUserService _userService;
    private readonly IUserHistoryService _userHistoryService;

    public UserController(IUserService userService, IUserHistoryService userHistoryService)
    {
        _userService = userService;
        _userHistoryService = userHistoryService;
    }

    [Authorize(Roles = "Admin")]
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

    [Authorize(Roles = "Admin")]
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

    [HttpGet("{userId}/history")]
    public async Task<IActionResult> GetUserHistory(Guid userId)
    {
        try
        {
            var userHistory = await _userHistoryService.GetHistoryByUserId(userId);
            return Ok(userHistory);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPost("history")]
    public async Task<IActionResult> InsertUserHistory([FromBody] UserHistoryInsertDto request)
    {
        try
        {
            if (request.UserId == null)
            {
                return BadRequest("Mismatched userId between URL and request body");
            }

            await _userHistoryService.InsertUserHistory(request);
            return Ok("User history inserted successfully");
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}
