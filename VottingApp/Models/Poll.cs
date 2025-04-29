namespace VottingApp.Models
{
    public class Poll
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime EndDate { get; set; }
        public bool IsPublicResult { get; set; } = true;

        public int CreatedByUserId { get; set; }
        public Users CreatedByUser { get; set; }
        public List<int> AllowedUserIds { get; set; } = new();

        public ICollection<PollOption> Options { get; set; }
    }

}
