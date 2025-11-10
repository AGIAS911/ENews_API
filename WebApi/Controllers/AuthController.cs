using Anas_Abualsauod.News.Domain.Dtos.Users;
using Anas_Abualsauod.News.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using News.Service;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUser _userService;
    private readonly JwtService _jwtService;

    public AuthController(IUser userService, JwtService jwtService)
    {
        _userService = userService;
        _jwtService = jwtService;
    }

    [AllowAnonymous]
    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromForm] AddUserRequest request)
    {
        await _userService.Add(request);
        return Ok("User registered successfully");
    }



    [AllowAnonymous]
    [HttpPost("Login")]
    public async Task<IActionResult> Authenticate(LoginUserRequest loginRequest)
    {
        var response = await _jwtService.AuthenticateUser(loginRequest);
        if (response == null)
        {
            return Unauthorized(new { Message = "Invalid username or password" });
        }
        return Ok(response);
    }

    
}
