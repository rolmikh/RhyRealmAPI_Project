using System.Text.Json.Serialization;

namespace RhyRealmAPI_Project.Models
{
    public class Album
    {
        public int IdAlbum { get; set; }
        public string? NameAlbum { get; set; }
        public string? DescriptionAlbum { get; set;}
        public decimal? PriceAlbum { get; set; } = 0;
        public decimal? Rating { get; set; } = 0;
        public string? PhotoAlbum { get; set; }
        public bool? IsDeleted { get; set; }
        public string? ArticleNumber { get; set; }
        public int? PerformerId { get; set; }

        [JsonIgnore]
        public Performer? Performer { get; set; }

        [JsonIgnore]
        public ICollection<ContentOrder>? ContentOrders { get; set; }

        [JsonIgnore]
        public ICollection<ContentAlbum>? ContentAlbums { get; set; }

        [JsonIgnore]
        public ICollection<Rating>? Ratings { get; set; }
    }
}
