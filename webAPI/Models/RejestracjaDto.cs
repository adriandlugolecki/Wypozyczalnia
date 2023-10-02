using System.ComponentModel.DataAnnotations;

namespace webAPI.Models
{
    public class RejestracjaDto
    {
        
        public string? Imie { get; set; } 
        public string? Nazwisko { get; set; } 
        public string? DataUrodzenia { get; set; } 
        public string? Pesel { get; set; } 
        public string? Email { get; set; } 
        public string? Haslo { get; set; } 

    }
}
