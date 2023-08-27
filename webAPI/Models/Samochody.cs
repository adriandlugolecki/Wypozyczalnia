using System.ComponentModel.DataAnnotations;

namespace webAPI.Models
{
    public class Samochody
    {
        [Key]
        public int Id { get; set; }
        public string Nazwa { get; set; } = string.Empty;
        public string Marka { get; set; } = string.Empty;
        public string MocSilnika { get; set; } = string.Empty;
        public string Rocznik { get; set; } = string.Empty;
        public string liczbaMiejsc { get; set; } = string.Empty;
        public string RodzajSkrzyni { get; set; } = string.Empty;


    }
}
