using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestingSystem.Admin.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class BaseController : ControllerBase
{
}
