namespace webAPI.Models
{
    public class ServicesResponse
    {
        public string Wiadomosc { get; set; } = string.Empty;
        public bool Powodzenie { get; set; } = false;
        public string? Id { get; set; }
        public string Token { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }
}
