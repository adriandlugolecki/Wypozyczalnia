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
        public async Task<IEnumerable<Samochody>> GetSamochodyList() 
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
        public async Task<IActionResult> PostSamochod(Samochody samochod)
        {
            await _context.Samochody.AddAsync(samochod);
            await _context.SaveChangesAsync();
            return Ok(samochod);
        }
    }
}
