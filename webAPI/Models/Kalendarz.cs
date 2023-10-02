using System.ComponentModel.DataAnnotations;

namespace webAPI.Models
{
    public class Kalendarz
    {
        [Key]
        public int Id { get; set; }
        public int IdWypozyczenia { get; set; }
        public int IdSamochodu { get; set; }
        public DateTime Data { get; set; }
        
    }
}
