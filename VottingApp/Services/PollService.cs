using System;
using VottingApp.Models.DTOs;
using VottingApp.Models;
using VottingApp.Data;
using Microsoft.EntityFrameworkCore;

namespace VottingApp.Services
{
    public class PollService : IPollService
    {
        private readonly ApplicationDbContext _context;

        public PollService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Poll> CreatePollAsync(CreatePollDto dto)
        {
            var poll = new Poll
            {
                Title = dto.Title,
                Description = dto.Description,
                EndDate = dto.EndDate,
                IsPublicResult = dto.IsPublicResult,
                CreatedByUserId = dto.  UserId,
                Options = dto.Options.Select(opt => new PollOption { OptionText = opt }).ToList(),
                AllowedUserIds = dto.AllowedUserIds
            };

            _context.Polls.Add(poll);
            await _context.SaveChangesAsync();
            return poll;
        }

        public async Task<string> VoteAsync(VoteDto dto)
        {
            var poll = await _context.Polls.Include(p => p.Options).FirstOrDefaultAsync(p => p.Id == dto.PollId);
            if (poll == null) return "Poll not found.";
            if (poll.EndDate < DateTime.UtcNow) return "Poll has ended.";

            if (!poll.AllowedUserIds.Contains(dto.UserId))
                return "You are not allowed to vote in this poll.";

            var alreadyVoted = await _context.Votes.AnyAsync(v => v.PollId == dto.PollId && v.UserId == dto.UserId);
            if (alreadyVoted) return "You have already voted.";

            var vote = new Vote
            {
                PollId = dto.PollId,
                OptionId = dto.OptionId,
                UserId = dto.UserId
            };

            var option = await _context.PollOptions.FirstOrDefaultAsync(o => o.Id == dto.OptionId);
            if (option == null) return "Option not found.";

            option.VoteCount++;
            _context.Votes.Add(vote);
            await _context.SaveChangesAsync();

            return "Vote submitted.";
        }

        public async Task<List<Poll>> GetAllPollsAsync()
        {
            return await _context.Polls.Include(p => p.Options).ToListAsync();
        }

        public async Task<PollResultDto> GetPollResultsAsync(int pollId)
        {
            var poll = await _context.Polls.Include(p => p.Options).FirstOrDefaultAsync(p => p.Id == pollId);
            if (poll == null) return null;

            var result = new PollResultDto
            {
                Title = poll.Title,
                Options = poll.Options.Select(o => new PollOptionResultDto
                {
                    OptionText = o.OptionText,
                    VoteCount = o.VoteCount
                }).ToList()
            };

            return result;
        }
    }

}
