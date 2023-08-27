using Microsoft.AspNetCore.Http;
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

        [HttpGet]
        public async Task<IEnumerable<Ubezpieczenie>> GetUbezpieczeniaList()
        {
            return await _context.Ubezpieczenia.ToListAsync();
        }
    }
}
