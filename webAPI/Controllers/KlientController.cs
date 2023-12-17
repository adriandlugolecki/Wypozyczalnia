using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    }
}
