using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestingSystem.Core.Services.Implements;
using TestingSystem.Data.Common;
using TestingSystem.Data.Entities;
using TestingSystem.Data.Models.Submission;
using TestingSystem.Infrastructure.Repositories.Interfaces;

namespace TestingSystem.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin, Teacher")]
    public class SubmissionController : ControllerBase
    {
        private readonly SubmissionService _submissionService;

        public SubmissionController(SubmissionService submissionService)
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
                return Ok(submission);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<PaginatedResponseModel<Submission>>> GetListSubmitOfUser(SearchingSubmitRequest request)
        {
            var submissions = await _submissionService.GetListSubmitOfUser(request);

            return Ok(submissions);
        }
    }
}
