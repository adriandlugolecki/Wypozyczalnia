namespace webAPI.Models
{
    public class ZmianaHaslaDto
    {
        public required string Email { get; set; }
        public string Kod { get; set; } = string.Empty;
        public string Haslo { get; set; } = string.Empty;
    }
}
