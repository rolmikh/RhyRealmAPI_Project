using System.Text.Json.Serialization;

namespace RhyRealmAPI_Project.Models
{
    public class ContentOrder
    {
        public int IdContentOrder { get; set; }
        public int AlbumId { get; set; }
        public int OrderId { get; set; }

        [JsonIgnore]
        public Album? Album { get; set;}

        [JsonIgnore]
        public Order? Order { get; set; }
    }
}
