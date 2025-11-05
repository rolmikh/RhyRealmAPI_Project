using System.Text.Json.Serialization;

namespace RhyRealmAPI_Project.Models
{
    public class User
    {
        public int IdUser { get; set; }
        public string? SurnameUser { get; set; } = null;
        public string? NameUser { get; set; } = null;
        public string? PatronymicNameUser { get; set; } = null;
        public DateTime? DateBirthUser { get; set; } = null;
        public string EmailUser { get; set;} = string.Empty;
        public string PasswordUser { get; set;} = string.Empty;
        public string SaltUser { get; set; } = string.Empty;
        public int? BonusUser { get; set; } = null;
        public int RoleId { get; set; } 
        public string? PhotoUser { get; set; } = null;


        [JsonIgnore]
        public Role? Role { get; set; } = null;

        [JsonIgnore]
        public ICollection<Order>? Orders { get; set; } = null;

        [JsonIgnore]
        public ICollection<Rating>? Rating { get; set; } = null;
    }
}
