using System.Text.Json.Serialization;

namespace RhyRealmAPI_Project.Models
{
    public class PhotoForFeedback
    {
        public int IdPhotoForFeedback { get; set; }
        public string? Photo { get; set; }

        [JsonIgnore]
        public ICollection<Rating>? Rating { get; set; }
    }
}
