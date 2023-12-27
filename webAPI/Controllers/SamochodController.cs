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
        public async Task<IEnumerable<Samochod>> ListaSamochodow() 
        {
            return await _context.Samochody.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Samochod([FromRoute]int id)
        {
            var Samochod = await _context.Samochody.FindAsync(id);
            return Samochod == null ? NotFound("Brak takiego samochodu") : Ok(Samochod);
        }
        [HttpPost]
        public async Task<IActionResult> DodajSamochod(Samochod samochod)
        {
            await _context.Samochody.AddAsync(samochod);
            await _context.SaveChangesAsync();
            return Ok(samochod);
        }
        [HttpGet("wolneSamochody/{data}/{dataZakonczenia}")]
        public IActionResult WolneAuta([FromRoute] DateTime data,[FromRoute] DateTime dataZakonczenia)
        {
            var samochody = _context.Samochody.ToList();

            var zablokowaneAuta = _context.Kalendarz.Where(w => w.Data == data || w.Data.CompareTo(data) >= 0 && w.Data.CompareTo(dataZakonczenia) == -1).Select(w => w.IdSamochodu).Distinct().ToList();

            var ListaDostepnychSamochodow = samochody.Where(s=> s.CzyZablokowany == false).ToList();

            foreach(var auto in samochody)
            {
                foreach(var zablokowane in zablokowaneAuta)
                {
                    if(auto.Id == zablokowane )
                    {
                        ListaDostepnychSamochodow.Remove(auto);
                    }
                }
            }
            

            return Ok(ListaDostepnychSamochodow);
            
        }
    }
}
