namespace HotChoco.GprahQL.Jwt.Auth.Models
{
    public class TokenSettings
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Key { get; set; }
    }
}