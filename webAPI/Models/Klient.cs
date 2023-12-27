using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace webAPI.Models
{
    public class Klient:IdentityUser
    {
        
        [Required]
        public string Imie { get; set; } = string.Empty;
        [Required]
        public string Nazwisko { get; set; } = string.Empty;
        [Required]
        public string DataUrodzenia { get; set; } = string.Empty;
        [Required]
        [StringLength(11)]
        public string Pesel { get; set; } = string.Empty;
        public string? KodWeryfikacyjny { get; set; }

    }
}
