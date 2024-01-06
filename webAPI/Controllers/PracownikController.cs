using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webAPI.Data;
using webAPI.Models;

namespace webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PracownikController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PracownikController(AppDbContext context) => _context = context;

        [Authorize(Roles = "pracownik, admin")]
        [HttpGet("ListaWypozyczenNaDzis/{data}")]
        public IActionResult ListaWypozyczenNaDzis([FromRoute] DateTime data)
        {
            var WypozyczeniaKlienta = _context.Wypozyczenia.Where(w => w.Data == data).Include(w=> w.Samochod).Include(w => w.Klient).OrderBy(w => w.CzyWydano).ToList();
            return Ok(WypozyczeniaKlienta);
        }

        [Authorize(Roles = "pracownik, admin")]
        [HttpGet("ListaZakonczenNaDzis/{data}")]
        public IActionResult ListaZakonczenNaDzis([FromRoute] DateTime data)
        {
            var WypozyczeniaKlienta = _context.Wypozyczenia.Where(w => w.DataZakonczenia == data).Include(w => w.Samochod).Include(w => w.Klient).OrderBy(w=> w.CzyOddano).ToList();
            return Ok(WypozyczeniaKlienta);
        }

        [Authorize(Roles = "pracownik, admin")]
        [HttpGet("WypozyczenieInfo/{id}")]
        public IActionResult WypozyczenieInfo([FromRoute] int id)
        {
            var Wypozyczenie = _context.Wypozyczenia.Include(w => w.Samochod).Include(w => w.Klient).FirstOrDefault(w=>w.Id == id);
            return Ok(Wypozyczenie);
        }

        [Authorize(Roles = "pracownik, admin")]
        [HttpPatch("ZmianaStatusuWypozyczenia/{id}")]
        public async Task<IActionResult> ZmianaStatusuWypozyczenie([FromRoute] int id, [FromBody] WypozyczenieDto dto)
        {
            var Wypozyczenie = _context.Wypozyczenia.FirstOrDefault(w => w.Id == id);
            if (Wypozyczenie == null) return NotFound("Nie odnaleziono wypozyczenia");
            Wypozyczenie.CzyWydano=dto.CzyWydano;
            Wypozyczenie.CzyOddano=dto.CzyOddano;
            Wypozyczenie.Notatka =dto.Notatka;
            await _context.SaveChangesAsync();
            return Ok("zaktualizowano");
        }

        [Authorize(Roles = "pracownik, admin")]
        [HttpGet("DoPrzedluzenia")]
        public IActionResult DoPrzedluzenia()
        {
            var ListaPrzedluzen = _context.Oczekujace.Where(w => w.Zaakceptowane == false).ToList();
            return Ok(ListaPrzedluzen);
        }

        [Authorize(Roles = "pracownik, admin")]
        [HttpDelete("UsunPrzedluzenie/{id}")]
        public async Task<IActionResult> AnulujPrzedluzenie([FromRoute] int id) {
            var przedluzenie = await _context.Oczekujace.FindAsync(id);
            if(przedluzenie == null) return NotFound("Nie odnaleziono przedłużenia");

            var wypozyczenie = await _context.Wypozyczenia.FindAsync(przedluzenie.WypozyczenieId);
            if(wypozyczenie == null) return NotFound("Nie odnaleziono wypożyczenia");

            DateTime data = wypozyczenie.DataZakonczenia;
            var ileDni = przedluzenie.DoKiedy.Subtract(wypozyczenie.DataZakonczenia).Days;
            for (int i = 0; i< ileDni; i++)
            {
                
                await _context.Kalendarz.Where(k => k.IdWypozyczenia == wypozyczenie.Id && k.Data == data).ExecuteDeleteAsync();
                data = data.AddDays(1);
            }
            await _context.Oczekujace.Where(o => o.Id == przedluzenie.Id).ExecuteDeleteAsync();
            return Ok("usunięto");
        }

        [Authorize(Roles = "pracownik, admin")]
        [HttpPatch("ZaakceptujPrzedluzenie/{id}")]
        public async Task<IActionResult> ZaakceptujPrzedluzenie([FromRoute] int id)
        {
            var przedluzenie = await _context.Oczekujace.FindAsync(id);
            if (przedluzenie == null) return NotFound("Nie odnaleziono przedłużenia");
            var wypozyczenie = await _context.Wypozyczenia.FindAsync(przedluzenie.WypozyczenieId);
            if (wypozyczenie == null) return NotFound("Nie odnaleziono wypożyczenia");
            
            wypozyczenie.DataZakonczenia = przedluzenie.DoKiedy;
            przedluzenie.Zaakceptowane = true;
            await _context.SaveChangesAsync();

            return Ok("Zaakceptowano");
        }
    }
}
