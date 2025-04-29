namespace VottingApp.Models
{
    public class Vote
    {   
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PollId { get; set; }
        public int OptionId { get; set; }
        public DateTime VotedOn { get; set; } = DateTime.UtcNow;

        public Users User { get; set; }
        public Poll Poll { get; set; }
        public PollOption Option { get; set; }
    }

}
