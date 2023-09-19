using System.ComponentModel.DataAnnotations;

namespace webAPI.Models
{
    public class Samochod
    {
        [Key]
        public int Id { get; set; }
        public string Nazwa { get; set; } = string.Empty;
        public string Marka { get; set; } = string.Empty;
        public float MocSilnika { get; set; } 
        public int Rocznik { get; set; }
        public int liczbaMiejsc { get; set; }
        public string RodzajSkrzyni { get; set; } = string.Empty;


    }
}
