﻿using System.ComponentModel.DataAnnotations;
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

    
    [ForeignKey("Ubezpieczenie")]
    public int? UbezpieczenieId { get; set; }
    public Ubezpieczenie? Ubezpieczenie { get; set; }
    [Required]
    public DateTime Data { get; set; }
    [Required]
    public DateTime DataZakonczenia { get; set; }
    public int IleDni {  get; set; }
    [Required]
    public int Wiek {  get; set; } = 1;
    public float Kwota { get; set; }
    public bool CzyWydano { get; set; } = false;
    public bool CzyOddano { get; set; } = false;
    public string Notatka { get; set; } = string.Empty;

    public string? Imie { get; set; }
    public string? Nazwisko { get; set; }
    public string? Telefon { get; set; }
    public string? Adres { get; set; }
    public string? Miejscowosc { get; set; }
    public string? KodPocztowy { get; set; }
    }
    
}
