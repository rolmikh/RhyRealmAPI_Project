namespace RhyRealmAPI_Project.Models
{
    public class SmtpSettings
    {
        public string Host { get; set; } = "";
        public int Port { get; set; }
        public bool UseSsl { get; set; }
        public string Login { get; set; } = "";
        public string Password { get; set; } = "";
    }
}
