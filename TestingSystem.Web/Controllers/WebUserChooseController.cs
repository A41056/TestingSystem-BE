using Microsoft.AspNetCore.Mvc;
using TestingSystem.Core.Services.Interfaces;
using TestingSystem.Data.Models.WebUserChoose;

namespace TestingSystem.Web.Controllers;
[Route("api/[controller]")]
[ApiController]
public class WebUserChooseController : BaseController
{
    private readonly IWebUserChooseService _webUserChooseService;

    public WebUserChooseController(IWebUserChooseService webUserChooseService)
    {
        _webUserChooseService = webUserChooseService;
    }

    [HttpPost("save-choose")]
    public async Task<IActionResult> SaveChoose(CreateOrUpdateWebUserChooseRequest request)
    {
        var saved = await _webUserChooseService.SaveChoose(request);

        if (saved == null)
            return BadRequest();

        return Ok(saved);
    }
}
