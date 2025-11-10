using Anas_Abualsauod.News.Domain.Dtos.Articale;
using Anas_Abualsauod.News.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ArticaleController : ControllerBase
{
    private readonly ILogger<ArticaleController> _logger;
    private readonly IArticale _articale;

    public ArticaleController(ILogger<ArticaleController> logger, IArticale articale)
    {
        _logger = logger;
        _articale = articale;
    }
 
    [HttpPost("Insert")]
    public async Task<IActionResult> AddNewsRequest(AddArticaleRequest request)
    {
        //await _articale.Validation(request);
        await _articale.Add(request);
        return Redirect("AddNews");
    }

}
