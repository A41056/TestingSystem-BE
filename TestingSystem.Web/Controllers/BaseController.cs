using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestingSystem.Web.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class BaseController : ControllerBase
{
}
