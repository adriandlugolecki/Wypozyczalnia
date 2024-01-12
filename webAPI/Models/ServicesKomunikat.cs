namespace webAPI.Models
{
    public class ServicesKomunikat
    {
        public string Wiadomosc { get; set; } = string.Empty;
        public bool Powodzenie { get; set; } = false;
        public string Token { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;

        public string Id { get; set; } = string.Empty;

    }
}
