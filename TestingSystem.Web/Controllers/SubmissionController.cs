using Microsoft.AspNetCore.Mvc;
using TestingSystem.Core.Services.Interfaces;
using TestingSystem.Data.Entities;
using TestingSystem.Data.Models.Submission;

namespace TestingSystem.Web.Controllers;
[Route("api/[controller]")]
[ApiController]
public class SubmissionController : BaseController
{
    private readonly ISubmissionService _submissionService;

    public SubmissionController(ISubmissionService submissionService)
    {
        _submissionService = submissionService;
    }

    [HttpGet("getSubmissions")]
    public async Task<IActionResult> GetSubmissionByUserId([FromQuery]SearchingSubmitRequest request)
    {
        var result = await _submissionService.GetListSubmitOfUser(request);

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Submission>> GetSubmission(Guid id)
    {
        try
        {
            var submission = await _submissionService.GetSubmission(id);
            if (submission == null)
            {
                return NotFound();
            }
            return Ok(submission);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
        }
    }

    [HttpPost("submit")]
    public async Task<IActionResult> Submit(SubmissionDto request)
    {
        try
        {
            var submission = await _submissionService.Submit(request);
            return CreatedAtAction(nameof(GetSubmission), new { id = submission.Id }, submission);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
        }
    }

}
