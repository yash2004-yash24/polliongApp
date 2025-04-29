namespace VottingApp.Models.DTOs
{
    public class CreatePollDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsPublicResult { get; set; }
        public List<string> Options { get; set; }

        public int UserId { get; set; }
        public List<int> AllowedUserIds { get; set; }
    }

}
