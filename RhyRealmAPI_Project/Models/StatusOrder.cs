using System.Text.Json.Serialization;

namespace RhyRealmAPI_Project.Models
{
    public class StatusOrder
    {
        public int IdStatusOrder { get; set; }
        public string? NameStatusOrder { get; set; }

        [JsonIgnore]
        public ICollection<Order>? Orders { get; set; }
    }
}
