using System.Text.Json.Serialization;

namespace RhyRealmAPI_Project.Models
{
    public class Content
    {
        public int IdContent { get; set; }
        public string? NameContent { get; set; }

        [JsonIgnore]
        public ICollection<ContentAlbum>? ContentAlbums { get; set; }
    }
}
