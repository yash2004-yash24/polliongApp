namespace VottingApp.Models.DTOs
{
    public class PollResultDto
    {
        public string Title { get; set; }
        public List<PollOptionResultDto> Options { get; set; }
    }

    public class PollOptionResultDto
    {
        public string OptionText { get; set; }
        public int VoteCount { get; set; }
    }

}