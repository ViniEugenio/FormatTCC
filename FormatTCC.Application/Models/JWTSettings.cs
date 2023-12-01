namespace FormatTCC.Application.Models
{
    public class JWTSettings
    {
        public required string Secret { get; set; }
        public required string Issuer { get; set; }
        public required string ValidIn { get; set; }
    }
}
