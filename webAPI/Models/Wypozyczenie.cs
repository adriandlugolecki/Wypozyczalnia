using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webAPI.Models
{
    public class Wypozyczenie
    {
    [Key]
    public int Id { get; set; }
    [Required]
    [ForeignKey("Samochod")]
    public int SamochodId { get; set; } 
    public Samochod? Samochod { get; set; }
    [Required]
    [ForeignKey("Klient")]
    public string? KlientId { get; set; }
    public Klient? Klient { get; set; }
    [Required]
    public DateTime Data { get; set; }
    [Required]
    public DateTime DataZakonczenia { get; set; }
    [Required]
    public float kwota { get; set; }
    public bool CzyZapłacono { get; set; } = false;
    public bool CzyOddano { get; set; } = false;

    

    }
    
}
