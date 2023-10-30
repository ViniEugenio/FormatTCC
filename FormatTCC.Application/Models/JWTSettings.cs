namespace FormatTCC.Application.Models
{
    public class JWTSettings
    {
        public string Secret { get; set; }
        public int Expiration { get; set; }
        public string Issuer { get; set; }
        public string ValidIn { get; set; }
    }
}
