using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VottingApp.Models.DTOs;
using VottingApp.Services;

namespace VottingApp.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class PollController : ControllerBase
    {
        private readonly IPollService _pollService;

        public PollController(IPollService pollService)
        {
            _pollService = pollService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreatePollDto dto)
        {
            var result = await _pollService.CreatePollAsync(dto);
            return Ok(result);
        }

        [HttpPost("vote")]
        public async Task<IActionResult> Vote([FromBody] VoteDto dto)
        {
            var result = await _pollService.VoteAsync(dto);
            return Ok(result);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var polls = await _pollService.GetAllPollsAsync();
            return Ok(polls);
        }

        [HttpGet("results/{pollId}")]
        public async Task<IActionResult> GetResults(int pollId)
        {
            var result = await _pollService.GetPollResultsAsync(pollId);
            if (result == null) return NotFound("Poll not found");
            return Ok(result);
        }
    }

}
