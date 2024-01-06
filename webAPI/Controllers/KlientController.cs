using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using webAPI.Data;
using webAPI.Models;

namespace webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KlientController : ControllerBase
    {
        private readonly AppDbContext _context;

        public KlientController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<IEnumerable<Klient>> GetKlientList()
        {
            return await _context.Klienci.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Klient([FromRoute] int id)
        {
            var Klient = await _context.Klienci.FindAsync(id);
            return Klient == null ? NotFound("Brak takiego Klienta") : Ok(Klient);
        }
        
        [Authorize(Roles = "klient")]
        [HttpPost("WypozyczenieSamochodu")]
        public async Task<IActionResult> WypozyczenieSamochodu(Wypozyczenie wypozyczenie)
        {
            if (ModelState.IsValid){
                var czyDostepne = _context.Kalendarz.Where(w => w.Data == wypozyczenie.Data && w.IdSamochodu == wypozyczenie.SamochodId || w.Data.CompareTo(wypozyczenie.Data) >= 0 && w.Data.CompareTo(wypozyczenie.DataZakonczenia) == -1 && w.IdSamochodu == wypozyczenie.SamochodId).Select(w => w.IdSamochodu).Distinct().ToList();
                if (czyDostepne.Count > 0) return BadRequest("Ten Samochód jest już zarezerwowany");
                
                string id = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)!;
                wypozyczenie.KlientId = id;
                await _context.Wypozyczenia.AddAsync(wypozyczenie);
                await _context.SaveChangesAsync();
                var ileDni = wypozyczenie.DataZakonczenia.Subtract(wypozyczenie.Data).Days;

                for (int i = 0; i < ileDni; i++)
                {
                    await _context.Kalendarz.AddAsync(new Kalendarz
                    {
                        IdWypozyczenia = wypozyczenie.Id,
                        IdSamochodu = wypozyczenie.SamochodId,
                        Data = wypozyczenie.Data.AddDays(i)
                    });  
                }
                await _context.SaveChangesAsync();
                return Ok(wypozyczenie);
            }
            return BadRequest("Błąd");
        }

        [Authorize(Roles = "klient")]
        [HttpGet("WypozyczeniaKlienta")]
        public IActionResult WypozyczeniaKlienta()
        {
            string id = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            var WypozyczeniaKlienta = _context.Wypozyczenia.Where(w => w.KlientId == id).OrderByDescending(w=> w.DataZakonczenia).Include(w=> w.Samochod).ToList();
            return Ok(WypozyczeniaKlienta);
        }

        [Authorize(Roles = "klient")]
        [HttpDelete("UsunWypozyczenie/{id}")]
        public async Task<IActionResult> UsunWypozyczenie([FromRoute] int id) 
        {
            await _context.Wypozyczenia.Where(w=>w.Id == id).ExecuteDeleteAsync();
            await _context.Kalendarz.Where(w => w.IdWypozyczenia == id).ExecuteDeleteAsync();
            await _context.SaveChangesAsync();
            return Ok("usunięto");
        }

        [Authorize(Roles = "klient")]
        [HttpGet("DostepnePrzedluzenia/{id}")]
        public async Task<IActionResult> DostepnePrzedluzenia([FromRoute] int id)
        {
            var wypozyczenie = await _context.Wypozyczenia.FindAsync(id);
            if (wypozyczenie == null) return NotFound("Nie znalezionow Wypożyczenia");
            DateTime dataPoczatkowa = wypozyczenie.DataZakonczenia;

            var temp = _context.Kalendarz.Where(w => w.Data == dataPoczatkowa
                                           && w.IdSamochodu == wypozyczenie.SamochodId).ToList();
            if (temp.Count > 0)
            {
                return Ok("brak terminu");
            }

            for (int i = 1; i< 20; i++)
            {
                temp = _context.Kalendarz.Where(w => w.Data == dataPoczatkowa.AddDays(1)
                                           && w.IdSamochodu == wypozyczenie.SamochodId).ToList();
                if (temp.Count > 0)
                {
                    
                    return Ok(dataPoczatkowa.AddDays(1));
                }
                else { dataPoczatkowa = dataPoczatkowa.AddDays(1); }
            }
            return Ok(dataPoczatkowa);
        }

        [Authorize(Roles = "klient")]
        [HttpPost("PrzedluzWypozyczenie/{id}/{doKiedy}")]
        public async Task<IActionResult> PrzedluzWypozyczenie([FromRoute] int id, [FromRoute] DateTime doKiedy)
        {
            var wypozyczenie = await _context.Wypozyczenia.FindAsync(id);
            if (wypozyczenie == null) return NotFound("Nie odnaleziono takiego ");
            
            var ileDni = doKiedy.Subtract(wypozyczenie.DataZakonczenia).Days;

            for (int i = 0; i < ileDni; i++)
            {
                await _context.Kalendarz.AddAsync(new Kalendarz
                {
                    IdWypozyczenia = wypozyczenie.Id,
                    IdSamochodu = wypozyczenie.SamochodId,
                    Data = wypozyczenie.DataZakonczenia.AddDays(i)
                });
            }
            var kwota = wypozyczenie.Kwota / wypozyczenie.DataZakonczenia.Subtract(wypozyczenie.Data).Days;
            kwota *= ileDni;
            var przedluzenie = new Oczekujace
            {
                WypozyczenieId = wypozyczenie.Id,
                DoKiedy = doKiedy,
                Kwota = kwota,
                Zaakceptowane = false,
            };
            await _context.Oczekujace.AddAsync(przedluzenie);
            await _context.SaveChangesAsync();
            return Ok(przedluzenie);

        }

        [Authorize(Roles = "klient")]
        [HttpDelete("AnulujPrzedluzenie/{id}")]
        public async Task<IActionResult> AnulujPrzedluzenie([FromRoute] int id)
        {
            var przedluzenie = await _context.Oczekujace.FindAsync(id);
            if (przedluzenie == null)  return NotFound("Nie ma przedluzenia o takim id"); 
            var wypozyczenie = await _context.Wypozyczenia.FindAsync(przedluzenie.WypozyczenieId);
            if (wypozyczenie == null) return NotFound("Nie odnaleziono wypozyczenia");
            DateTime data = wypozyczenie.DataZakonczenia;
            var ileDni = przedluzenie.DoKiedy.Subtract(wypozyczenie.DataZakonczenia).Days;
            for (int i = 0; i < ileDni; i++)
            {

                await _context.Kalendarz.Where(k => k.IdWypozyczenia == wypozyczenie.Id && k.Data == data).ExecuteDeleteAsync();
                data = data.AddDays(1);
            }
            await _context.Oczekujace.Where(o => o.Id == przedluzenie.Id).ExecuteDeleteAsync();
            return Ok("usunięto");
        }
    }
}
