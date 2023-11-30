using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webAPI.Data;
using webAPI.Models;

namespace webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AdminController(AppDbContext context) => _context = context;

        [HttpGet("ListaPracownikow")]
        public async Task<IEnumerable<Pracownik>> ListaPracownikow()
        {
            var lista = await _context.Pracownicy.OrderBy(p=>p.czyAdmin).Reverse().ToListAsync();
            return lista;
        }
        [HttpGet("ListaSamochodow")]
        public async Task<IEnumerable<Samochod>> GetSamochodyList()
        {
            return await _context.Samochody.ToListAsync();
        }
    }
}
