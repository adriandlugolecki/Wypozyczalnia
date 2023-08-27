using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace webAPI.Models
{
    public class Pracownik:IdentityUser
    {
        
        [Required]
        public string Imie { get; set; } = string.Empty;
        [Required]
        public string Nazwisko { get; set; } = string.Empty;

        [Required]
        public string DataUrodzenia { get; set; } = string.Empty;
        [Required]
        public string Pesel { get; set; } = string.Empty;

    }
}
