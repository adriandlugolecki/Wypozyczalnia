using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace webAPI.Models
{
    public class Pracownik:IdentityUser
    {
        
        [Required]
        public string? Imie { get; set; } 
        [Required]
        public string? Nazwisko { get; set; } 

        [Required]
        public string? DataUrodzenia { get; set; } 
        [Required]
        [StringLength(11)]
        public string? Pesel { get; set; }
        [Required]
        public bool czyAdmin {  get; set; }

    }
}
