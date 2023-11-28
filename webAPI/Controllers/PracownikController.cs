using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webAPI.Data;

namespace webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PracownikController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PracownikController(AppDbContext context) => _context = context;

        [HttpGet("ListaWypozyczenNaDzis")]
        public IActionResult ListaWypozyczenNaDzis()
        {
            var WypozyczeniaKlienta = _context.Wypozyczenia.Where(w => w.Data == DateTime.Today).Include(w=> w.Samochod).Include(w => w.Klient).ToList();
            return Ok(WypozyczeniaKlienta);
        }
    }
}
