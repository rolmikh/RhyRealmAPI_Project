using System.Text.Json.Serialization;

namespace RhyRealmAPI_Project.Models
{
    public class User
    {
        public int IdUser { get; set; }
        public string? SurnameUser { get; set; }
        public string? NameUser { get; set; }
        public string? PatronymicNameUser { get; set; } = null;
        public DateTime? DateBirthUser { get; set; }
        public string? EmailUser { get; set;}
        public string? PasswordUser { get; set;}
        public string? SaltUser { get; set; }
        public int? BonusUser { get; set; }
        public int? RoleId {  get; set; }
        public string? PhotoUser { get; set; } = null;


        [JsonIgnore]
        public Role? Role { get; set; }

        [JsonIgnore]
        public ICollection<Order>? Orders { get; set; }

        [JsonIgnore]
        public ICollection<Rating>? Rating { get; set; }
    }
}
