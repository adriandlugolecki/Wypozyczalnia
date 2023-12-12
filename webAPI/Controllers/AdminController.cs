using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using webAPI.Data;
using webAPI.Models;

namespace webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _environment;
        public AdminController(AppDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        [HttpGet("ListaPracownikow")]
        public async Task<IEnumerable<Pracownik>> ListaPracownikow()
        {
            var lista = await _context.Pracownicy.OrderBy(p => p.czyAdmin).Reverse().ToListAsync();
            return lista;
        }
        [HttpGet("ListaSamochodow")]
        public async Task<IEnumerable<Samochod>> ListaSamochodow()
        {
            return await _context.Samochody.ToListAsync();
        }
        [HttpGet("ListaUbezpieczen")]
        public async Task<IEnumerable<Ubezpieczenie>> ListaUbezpieczen()
        {
            return await _context.Ubezpieczenia.ToListAsync();
        }
        
        [HttpPost("DodajSamochod")]
        public async Task<IActionResult> DodajSamochod([FromBody] Samochod samochod)
        {
            await _context.Samochody.AddAsync(samochod);
            await _context.SaveChangesAsync();
            return Ok(samochod);
        }
        [HttpPost("DodajZdjecie/{nazwa}")]
        public async Task<IActionResult> DodajZdjecie([FromRoute] string nazwa, [FromForm] IFormFile zdjecie)
        {
            string nazwaPliku = nazwa + ".png";
            string path = Path.Combine(_environment.ContentRootPath, "Photos");
            using (Stream stream = new FileStream(Path.Combine(path, nazwaPliku), FileMode.Create))
            {
                await zdjecie.CopyToAsync(stream);
            }

            return Ok();
        }

    }
}
