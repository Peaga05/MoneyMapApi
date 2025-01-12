namespace Infrastructure.Auth.Dto
{
    public class JwtSettingsDto
    {
        public string SecretKey { get; set; } = default!;
        public string Issuer { get; set; } = default!;
        public string Audience { get; set; } = default!;
        public int ExpirationInMinutes { get; set; }
    }
}
