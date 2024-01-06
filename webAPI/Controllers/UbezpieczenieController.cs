using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webAPI.Data;
using webAPI.Models;

namespace webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UbezpieczenieController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UbezpieczenieController(AppDbContext context) => _context = context;

        [HttpGet("ListaUbezpieczen")]
        public async Task<IEnumerable<Ubezpieczenie>> ListaUbezpieczen()
        {
            return await _context.Ubezpieczenia.ToListAsync();
        }
        
        [HttpPost("DodajUbezpieczenie")]
        public async Task<IActionResult> DodajUbezpieczenie(Ubezpieczenie ubezpieczenie)
        {
            await _context.Ubezpieczenia.AddAsync(ubezpieczenie);
            await _context.SaveChangesAsync();
            return Ok(ubezpieczenie);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Ubezpieczenie([FromRoute] int id)
        {
            var Ubezpieczenie = await _context.Ubezpieczenia.FindAsync(id);
            return Ubezpieczenie == null ? NotFound("Brak takiego Ubezpieczenia") : Ok(Ubezpieczenie);
        }
    }
}
