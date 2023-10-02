using System.ComponentModel.DataAnnotations;

namespace webAPI.Models
{
    public class Wypozyczenie
    {
    [Key]
    public int Id { get; set; }
    [Required]
    public int SamochodId { get; set; } 
    [Required]
    public string? KlientId { get; set; }
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
