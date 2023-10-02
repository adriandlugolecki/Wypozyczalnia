using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webAPI.Data;
using webAPI.Models;

namespace webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SamochodController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SamochodController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<IEnumerable<Samochod>> GetSamochodyList() 
        {
            return await _context.Samochody.ToListAsync();
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetSamochod(int id)
        {
            var Samochod = await _context.Samochody.FindAsync(id);
            return Samochod == null ? NotFound("Brak takiego samochodu") : Ok(Samochod);
        }
        [HttpPost]
        public async Task<IActionResult> PostSamochod(Samochod samochod)
        {
            await _context.Samochody.AddAsync(samochod);
            await _context.SaveChangesAsync();
            return Ok(samochod);
        }
        [HttpGet("wolneSamochody/{data}/{dataZakonczenia}")]
        public IActionResult WolneAuta([FromRoute] DateTime data,[FromRoute] DateTime dataZakonczenia)
        {
            var samochody = _context.Samochody.Select(s=>s.Id).ToList();

            var zablokowaneAuta = _context.Kalendarz.Where(w => w.Data == data || w.Data.CompareTo(data)>=0 && w.Data.CompareTo(dataZakonczenia)==-1 || w.Data == dataZakonczenia).Select(w => w.IdSamochodu).ToList();
           
            
            foreach (var auto in zablokowaneAuta)
            {
                samochody.Remove(auto);
            }
            
            return Ok(samochody);

            

        }
    }
}
