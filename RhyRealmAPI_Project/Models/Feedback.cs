using System.Text.Json.Serialization;

namespace RhyRealmAPI_Project.Models
{
    public class Feedback
    {
        public int IdFeedback { get; set; }
        public int Mark { get; set; }
        public string? Text { get; set; }
        public DateTime? DateCreated { get; set; }

        [JsonIgnore]
        public ICollection<Rating>? Rating { get; set; }
    }
}
