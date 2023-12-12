using System.ComponentModel.DataAnnotations;

namespace webAPI.Models
{
    public class Samochod
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Marka { get; set; }
        [Required]
        public string? Model { get; set; }
        [Required]
        public string? Rejestracja { get; set; }
        [Required]
        public int Rocznik { get; set; }
        [Required]
        public int LiczbaMiejsc { get; set; }
        [Required]  
        public int LiczbaDrzwi {  get; set; }
        [Required]
        public RodzajSkrzyni RodzajSkrzyni { get; set; }
        [Required]
        public RodzajPaliwa RodzajPaliwa { get; set; }
        [Required]
        public int Cena {  get; set; }

    }
    public enum RodzajSkrzyni
    {
        Manualna, Automatyczna
    }

    public enum RodzajPaliwa
    {
        Benzyna, Diesel
    }
}
