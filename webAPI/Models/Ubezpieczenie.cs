using System.ComponentModel.DataAnnotations;

namespace webAPI.Models
{
    public class Ubezpieczenie
    {
        [Key] 
        public int Id { get; set; }
        public string Nazwa { get; set; } = string.Empty;
        public bool Kradziez { get; set; }
        public bool UszkodzeniePojazdu {  get; set; }
        public bool UszkodzenieSzyby {  get; set; }
        public bool UszkodzenieOpony {  get; set; }
        public bool UdzialWSzkodzie {  get; set; }
        public int Kwota { get; set; }

    }
}
