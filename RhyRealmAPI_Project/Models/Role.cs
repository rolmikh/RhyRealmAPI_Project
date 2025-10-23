using System.Text.Json.Serialization;

namespace RhyRealmAPI_Project.Models
{
    public class Role
    {
        public int IdRole { get; set; }
        public string? NameRole { get; set; }

        [JsonIgnore]
        public ICollection<User>? User { get; set;}
    }
}
