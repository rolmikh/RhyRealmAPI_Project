namespace RhyRealmAPI_Project.DTO
{
    public class AlbumDTO
    {
        public int IdAlbum { get; set; }
        public string? NameAlbum { get; set; }
        public string? DescriptionAlbum { get; set; }
        public decimal? PriceAlbum { get; set; } = 0;
        public decimal? Rating { get; set; } = 0;
        public string? PhotoAlbum { get; set; }
        public bool? IsDeleted { get; set; }
        public string? ArticleNumber { get; set; }
        public int? PerformerId { get; set; }
    }

    

    public class AlbumUpdateDTO
    {
        public int IdAlbum { get; set; }
        public string? NameAlbum { get; set; }
        public string? DescriptionAlbum { get; set; }
        public decimal? PriceAlbum { get; set; } = 0;
        public string? PhotoAlbum { get; set; }
        public bool? IsDeleted { get; set; }
        public int? PerformerId { get; set; }
    }


}
