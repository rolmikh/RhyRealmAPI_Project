using System.Text.Json.Serialization;

namespace RhyRealmAPI_Project.Models
{
    public class Order
    {
        public int IdOrder { get; set; }
        public string? NumberOrder { get; set; }
        public decimal? PriceOrder { get; set; }
        public int? UserId { get; set; }
        public int DeliveryId { get; set; }
        public DateTime? DateCreatedOrder { get; set; }
        public int StatusOrderId { get; set; }

        [JsonIgnore]
        public StatusOrder? StatusOrder { get; set; }
        [JsonIgnore]
        public User? User { get; set; }
        [JsonIgnore]
        public Delivery? Delivery { get; set; }

        [JsonIgnore]
        public ICollection<ContentOrder>? ContentOrders { get; set; }
    }
}
