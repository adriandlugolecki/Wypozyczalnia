using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace webAPI.Models
{
    public class Oczekujace
    {
        
            [Key]
            public int Id { get; set; }
            [Required]
            [ForeignKey("Wypozyczenie")]
            public int WypozyczenieId { get; set; }
            public Wypozyczenie Wypozyczenie { get; set; }
            [Required]
            public DateTime DoKiedy { get; set; }
            public float Kwota {  get; set; }
            public bool Zaakceptowane { get; set; }
        
    }
}
