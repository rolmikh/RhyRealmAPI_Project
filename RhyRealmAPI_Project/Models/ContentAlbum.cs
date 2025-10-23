using System.Text.Json.Serialization;

namespace RhyRealmAPI_Project.Models
{
    public class ContentAlbum
    {
        public int IdContentAlbum {  get; set; }
        public int AlbumId { get; set; }
        public int ContentId { get; set; }

        [JsonIgnore]
        public Album? Album { get; set; }

        [JsonIgnore]
        public Content? Content { get; set; }
    }
}
