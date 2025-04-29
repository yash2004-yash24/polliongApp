using System.Text.Json.Serialization;

namespace VottingApp.Models
{
    public class PollOption
    {
        public int Id { get; set; }
        public int PollId { get; set; }
        public string OptionText { get; set; }
        public int VoteCount { get; set; }

        [JsonIgnore]
        public Poll Poll { get; set; }
    }

}
