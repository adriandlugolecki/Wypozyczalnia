using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using webAPI.Data;
using webAPI.Models;
using webAPI.Services;

namespace webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoryzacjaController : ControllerBase
    {

        private PracownikService _pracownikService;
        private KlientService _klientService;
        private UserManager<Pracownik> _pracownikManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AppDbContext _context;
        public AutoryzacjaController( PracownikService pracwonikService,KlientService klientService, UserManager<Pracownik> pracownikManager, RoleManager<IdentityRole> roleManager, AppDbContext context)
        {
            _pracownikManager = pracownikManager;
            _pracownikService = pracwonikService;
            _klientService = klientService;
            _roleManager = roleManager;
            _context = context;
        }

        [HttpPost("Rejestracja")]
        public async Task<IActionResult> RejestracjaAsync([FromBody] RejestracjaDto rejestracja)
        {
            if (ModelState.IsValid)
            {
                var result = await _klientService.RejestracjaAsync(rejestracja);
                if (result.Powodzenie)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            return BadRequest("niedziala");

        }
        [HttpPatch("PotwierdzenieKonta/{id}/{kod}")]
        public async Task<IActionResult> PotwierdzenieKonta([FromRoute] string id, [FromRoute] string kod)
        {
            var klient = await _context.Klienci.FindAsync(id);
            if(klient.KodWeryfikacyjny == kod)
            {
               klient.EmailConfirmed = true;
               _context.SaveChanges();
                return Ok("Aktywowano Konto");
            }
            return BadRequest("Błędny kod");
        }
        //[Authorize(Roles = "admin")]
        [HttpPost("PracownikRejestracja")]
        public async Task<IActionResult> RejestracjaPracownikAsync([FromBody] RejestracjaPracownikDto rejestracja)
        {
            if (ModelState.IsValid)
            {
                var result = await _pracownikService.RejestracjaPacownikAsync(rejestracja);
                if (result.Powodzenie)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            return BadRequest("niedziala");
            
        }
        
        [HttpPost("Logowanie")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginDto login)
        {
            
            var result = await _pracownikService.LoginAsync(login);
            if (result.Powodzenie)
            {
                return Ok(result);

            }else if (!result.Powodzenie)
            {
                result = await _klientService.LoginAsync(login);
                if (result.Powodzenie)
                {
                    return Ok(result);
                }
            }

            
            return BadRequest(result);
        }
        [HttpPost("DodanieRoli")]
        public async Task<IActionResult> DodanieRoliAsync([FromBody] string nazwa)
        {
            if (nazwa == null) return BadRequest("Nazwa jest pusta");
            if (!_roleManager.RoleExistsAsync(nazwa).GetAwaiter().GetResult())
            {
                await _roleManager.CreateAsync(new IdentityRole(nazwa));

                return Ok("Dodano role");
            }

            return BadRequest("Error");
        }
        //[HttpPatch("ZmianaHasla")]
        //public async Task<IActionResult> ZmianaHasla([FromBody] ZmianaHaslaDto dto)
        //{
        //    var klient = await _context.Klienci.FindAsync(dto.Id);

        //    if (klient == null) return BadRequest("nie ma takiego klienta");
        //    if (klient.KodWeryfikacyjny == dto.Kod)
        //    {
                
        //    }
            
        //}

    }
}
