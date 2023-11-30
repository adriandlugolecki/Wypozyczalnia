using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        [Authorize(Roles = "pracownik")]
        [HttpGet("ListaWypozyczenNaDzis/{data}")]
        public IActionResult ListaWypozyczenNaDzis([FromRoute] DateTime data)
        {
            var WypozyczeniaKlienta = _context.Wypozyczenia.Where(w => w.Data == data).Include(w=> w.Samochod).Include(w => w.Klient).OrderBy(w => w.CzyWydano).ToList();
            return Ok(WypozyczeniaKlienta);
        }
        [Authorize(Roles = "pracownik")]
        [HttpGet("ListaZakonczenNaDzis/{data}")]
        public IActionResult ListaZakonczenNaDzis([FromRoute] DateTime data)
        {
            var WypozyczeniaKlienta = _context.Wypozyczenia.Where(w => w.DataZakonczenia == data).Include(w => w.Samochod).Include(w => w.Klient).OrderBy(w=> w.CzyOddano).ToList();
            return Ok(WypozyczeniaKlienta);
        }
        [Authorize(Roles = "pracownik")]
        [HttpGet("WypozyczenieInfo/{id}")]
        public IActionResult WypozyczenieInfo([FromRoute] int id)
        {
            var Wypozyczenie = _context.Wypozyczenia.Include(w => w.Samochod).Include(w => w.Klient).FirstOrDefault(w=>w.Id == id);
            return Ok(Wypozyczenie);
        }
        [Authorize(Roles = "pracownik")]
        [HttpPatch("ZmianaStatusuWypozyczenia/{id}")]
        public async Task<IActionResult> ZmianaStatusuWypozyczenie([FromRoute] int id, [FromBody] WypozyczenieDto dto)
        {
            var Wypozyczenie = _context.Wypozyczenia.FirstOrDefault(w => w.Id == id);
            Wypozyczenie.CzyWydano=dto.CzyWydano;
            Wypozyczenie.CzyOddano=dto.CzyOddano;
            await _context.SaveChangesAsync();
            return Ok("zaktualizowano");
        }
    }
}
