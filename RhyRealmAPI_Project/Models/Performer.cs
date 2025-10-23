using System.Text.Json.Serialization;

namespace RhyRealmAPI_Project.Models
{
    public class Performer
    {
        public int IdPerformer { get; set; }
        public string? NamePerformer { get; set; }
        public string? PhotoPerformer { get; set; }
        public bool? isDeleted { get; set; }
        public int TypePerformerId { get; set; }

        [JsonIgnore]
        public TypePerformer? TypePerformer { get; set; }

        [JsonIgnore]
        public ICollection<Album>? Albums { get; set; }
    }
}
