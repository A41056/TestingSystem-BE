using Microsoft.AspNetCore.Mvc;
using TestingSystem.Core.Services.Implements;
using TestingSystem.Core.Services.Interfaces;
using TestingSystem.Data.Common;
using TestingSystem.Data.Entities;
using TestingSystem.Data.Models.Submission;

//Admin
namespace TestingSystem.Admin.Controllers
{
    public class SubmissionController : BaseController
    {
        private readonly ISubmissionService _submissionService;

        public SubmissionController(ISubmissionService submissionService)
        {
            _submissionService = submissionService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Submission>> GetSubmission(Guid id)
        {
            var submission = await _submissionService.GetSubmission(id);
            if (submission == null)
            {
                return NotFound();
            }
            return submission;
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

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<PaginatedResponseModel<Submission>>> GetListSubmitOfUser(SearchingSubmitRequest request)
        {
            var submissions = await _submissionService.GetListSubmitOfUser(request);

            return Ok(submissions);
        }

        [HttpGet("getSubmissions")]
        public async Task<ActionResult<PaginatedResponseModel<Submission>>> GetSubmissionByUserId([FromQuery] SearchingSubmitRequest request)
        {
            var result = await _submissionService.GetListSubmitOfUser(request);

            return Ok(result);
        }
    }
}
