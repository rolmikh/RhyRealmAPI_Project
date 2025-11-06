namespace RhyRealmAPI_Project.DTO
{
    public class UserDTO
    {
        public int IdUser { get; set; }
        public string? SurnameUser { get; set; }
        public string? NameUser { get; set; }
        public string? PatronymicNameUser { get; set; }
        public DateTime? DateBirthUser { get; set; }
        public string? EmailUser { get; set; }
        public int? BonusUser { get; set; }
        public int RoleId { get; set; }
        public string? PhotoUser { get; set; }
    }

    public class UserUpdatePhotoDTO
    {
        public int IdUser { get; set; }
        public string? PhotoUser { get; set; }
    }

    public class UserRegistrationDTO
    {
        public string? EmailUser { get; set; }
        public string? PasswordUser { get; set; }
        public string? SaltUser { get; set; }

    }

    public class UserPersonalPageClientDTO
    {
        public int IdUser { get; set; }
        public string? SurnameUser { get; set; }
        public string? NameUser { get; set; }
        public string? PatronymicNameUser { get; set; }
        public DateTime? DateBirthUser { get; set; }
        public string? EmailUser { get; set; }
        public int? BonusUser { get; set; }
        public int RoleId { get; set; }
        public string? PhotoUser { get; set; }
    }

    public class UserPersonalPageDTO
    {
        public int IdUser { get; set; }
        public string? SurnameUser { get; set; }
        public string? NameUser { get; set; }
        public string? PatronymicNameUser { get; set; }
        public DateTime? DateBirthUser { get; set; }
        public string? EmailUser { get; set; }
        public int RoleId { get; set; }
        public string? PhotoUser { get; set; }
    }

    public class UserUpdatePersonalPageDTO
    {
        public int IdUser { get; set; }
        public string? SurnameUser { get; set; }
        public string? NameUser { get; set; }
        public string? PatronymicNameUser { get; set; }
        public DateTime? DateBirthUser { get; set; }
        public string EmailUser { get; set; } = string.Empty;

    }
}
