using Anas_Abualsauod.News.Domain.Dtos.Users;
using Anas_Abualsauod.News.Domain.Interfaces;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUser _userService;

    public UserController(IUser userService)
    {
        _userService = userService;
    }

    [HttpGet("GetById/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var user = await _userService.GetById(id);
        var userInfo= user.Adapt< UserInfo >();
        if (user == null)
        {
            return NotFound();
        }
        return Ok(userInfo);
    }
}
