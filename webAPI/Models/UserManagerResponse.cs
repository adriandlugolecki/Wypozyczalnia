namespace webAPI.Models
{
    public class UserManagerResponse
    {
        public string Message { get; set; } = string.Empty;
        public bool IsSuccess { get; set; } = false;
        public string Token { get; set; } = string.Empty;
    }
}
