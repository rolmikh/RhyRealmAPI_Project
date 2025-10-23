using System.Text.Json.Serialization;

namespace RhyRealmAPI_Project.Models
{
    public class Delivery
    {
        public int IdDelivery {  get; set; }
        public string? DeliveryCity { get; set; }
        public string? PostalCode { get; set; }
        public string? DeliveryAddress { get; set; }
        public decimal? DeliveryPrice { get; set; }
        public int? DeliveryMethodId { get; set; }

        [JsonIgnore]
        public DeliveryMethod? DeliveryMethod { get; set; }

        [JsonIgnore]
        public ICollection<Order>? Orders { get; set; }

        [JsonIgnore]
        public ICollection<ContentOrder>? ContentOrders { get; set; }
    }
}
