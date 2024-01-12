namespace webAPI.Models
{
    public class RejestracjaPracownikDto
    {
        public string? Imie {  get; set; }
        public string? Nazwisko {  get; set; }
        public string? DataUrodzenia {  get; set; }
        public string? Pesel {  get; set; }
        public string? Email { get; set; } 
        public string? Haslo {  get; set; }
        public bool CzyAdmin { get; set; }
        public string? NumerTelefonu { get; set;}

    }
}
