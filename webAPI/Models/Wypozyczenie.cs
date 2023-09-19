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
    public int KlientId { get; set; }
    [Required]
    public string Data { get; set; }
    [Required]
    public int IleDni { get; set; }
    }
}
