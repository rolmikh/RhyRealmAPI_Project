using System.Text.Json.Serialization;

namespace RhyRealmAPI_Project.Models
{
    public class Rating
    {
        public int IdRating { get; set; }
        public int FeedbackId { get; set; }
        public int? PhotoForFeedbackId { get; set; }
        public int AlbumId { get; set; }
        public int UserId { get; set; }

        [JsonIgnore]
        public Feedback? Feedback { get; set; }

        [JsonIgnore]
        public PhotoForFeedback? PhotoForFeedback { get; set; }

        [JsonIgnore]
        public Album? Album { get; set; }

        [JsonIgnore]
        public User? User { get; set; }

    }
}
