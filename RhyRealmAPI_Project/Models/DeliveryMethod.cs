using System.Text.Json.Serialization;

namespace RhyRealmAPI_Project.Models
{
    public class DeliveryMethod
    {
        public int IdDeliveryMethod { get; set; }
        public string? NameDeliveryMethod { get; set; }

        [JsonIgnore]
        public ICollection<Delivery>? Deliveries { get; set; }
    }
}
