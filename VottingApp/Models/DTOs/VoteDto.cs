namespace VottingApp.Models.DTOs
{
    public class VoteDto
    {
        public int PollId { get; set; }
        public int OptionId { get; set; }
        public int UserId { get; set; }
    }

}
