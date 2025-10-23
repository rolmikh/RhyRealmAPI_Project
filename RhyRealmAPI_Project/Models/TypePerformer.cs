using System.Text.Json.Serialization;

namespace RhyRealmAPI_Project.Models
{
    public class TypePerformer
    {
        public int IdTypePerformer { get; set; }
        public string? NameTypePerformer { get; set; }

        [JsonIgnore]
        public ICollection<Performer>? Performers { get; set; }
    }
}
