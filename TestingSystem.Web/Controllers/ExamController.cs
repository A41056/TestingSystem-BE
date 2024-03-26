using Microsoft.AspNetCore.Mvc;
using TestingSystem.Core.Services.Interfaces;
using TestingSystem.Data.Models.Exam;

namespace TestingSystem.Web.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ExamController : BaseController
{
    private readonly IExamService _examService;

    public ExamController(IExamService examService)
    {
        _examService = examService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var exam = await _examService.GetById(id);
        if (exam == null)
        {
            return NotFound(); // Or any appropriate response
        }
        return Ok();
    }

    [HttpGet("list")]
    public async Task<IActionResult> GetList([FromQuery] SearchingExamRequest request)
    {
        try
        {
            var paginatedResponse = await _examService.GetList(request);
            return Ok(paginatedResponse);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet("detail/{id}")]
    public async Task<IActionResult> GetExamDetail(Guid id)
    {
        try
        {
            var paginatedResponse = await _examService.GetDetail(id);
            return Ok(paginatedResponse);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}
