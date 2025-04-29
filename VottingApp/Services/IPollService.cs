using VottingApp.Models.DTOs;
using VottingApp.Models;

namespace VottingApp.Services
{
    public interface IPollService
    {
        Task<Poll> CreatePollAsync(CreatePollDto dto);
        Task<string> VoteAsync(VoteDto dto);
        Task<List<Poll>> GetAllPollsAsync();
        Task<PollResultDto> GetPollResultsAsync(int pollId);
    }

}
