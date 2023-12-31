using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webAPI.Models
{
    public class WypozyczenieDto
    {

        public bool CzyWydano { get; set; } = false;
        public bool CzyOddano { get; set; } = false;
        public string Notatka { get; set; } = string.Empty;

    }
}