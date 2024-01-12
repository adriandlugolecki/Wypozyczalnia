using Microsoft.AspNetCore.Authorization;
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
        private UserManager<Klient> _klientManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AppDbContext _context;
        public AutoryzacjaController( UserManager<Pracownik> pracownikManager,PracownikService pracwonikService,KlientService klientService, UserManager<Klient> klientManager, RoleManager<IdentityRole> roleManager, AppDbContext context)
        {
            _pracownikManager = pracownikManager;
            _klientManager = klientManager;
            _pracownikService = pracwonikService;
            _klientService = klientService;
            _roleManager = roleManager;
            _context = context;
        }

        [HttpPost("Rejestracja")]
        public async Task<IActionResult> RejestracjaAsync([FromBody] RejestracjaDto rejestracja)
        {
            
            var wynik = await _klientService.RejestracjaAsync(rejestracja);
            if (wynik.Powodzenie)
            {
                return Ok(wynik);
            }
            return BadRequest(wynik);
            
        }

        [HttpPatch("PotwierdzenieKonta/{id}/{kod}")]
        public async Task<IActionResult> PotwierdzenieKonta([FromRoute] string id, [FromRoute] string kod)
        {
            var klient = await _context.Klienci.FindAsync(id);
            if (klient == null) return NotFound("Nie ma takiego konta");
            if(klient.KodWeryfikacyjny == kod)
            {
               klient.EmailConfirmed = true;
               _context.SaveChanges();
                return Ok("Aktywowano Konto");
            }
            return BadRequest("Błędny kod");
        }

        [HttpPost("PracownikRejestracja")]
        public async Task<IActionResult> RejestracjaPracownikAsync([FromBody] RejestracjaPracownikDto rejestracja)
        {
            var wynik = await _pracownikService.RejestracjaPacownikAsync(rejestracja);
            if (wynik.Powodzenie)
            {
                return Ok(wynik);
            }
            return BadRequest(wynik);
        }
        
        [HttpPost("Logowanie")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginDto login)
        {
            var wynik = await _pracownikService.LoginAsync(login);
            if (wynik.Powodzenie)
            {
                return Ok(wynik);

            }else if (!wynik.Powodzenie)
            {
                wynik = await _klientService.LoginAsync(login);
                if (wynik.Powodzenie)
                {
                    return Ok(wynik);
                }
            }
            return BadRequest(wynik);
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

        [HttpPatch("ZmianaHasla")]
        public async Task<IActionResult> ZmianaHasla([FromBody] ZmianaHaslaDto dto)
        {
            var klient = await _klientManager.FindByEmailAsync(dto.Email);

            if (klient == null) return BadRequest("nie ma takiego klienta");
            if (klient.AccessFailedCount > 10) return BadRequest("Zmiana hasła została zablokowana");
            if (klient.KodWeryfikacyjny == dto.Kod)
            {
                var ResetToken = await _klientManager.GeneratePasswordResetTokenAsync(klient);
                var wynik = await _klientManager.ResetPasswordAsync(klient, ResetToken, dto.Haslo);
                if(wynik.Succeeded) { return Ok("Hasło Zmienione"); }
                return BadRequest("Nie udało się zmienić hasła");
            }
            klient.AccessFailedCount++;
            _context.SaveChanges();
            return BadRequest("Błędny Kod Weryfikujący");

        }

        [Authorize(Roles = "admin")]
        [HttpPatch("ZmianaHaslaPracownik")]
        public async Task<IActionResult> ZmianaHaslaPracownika([FromBody] ZmianaHaslaDto dto)
        {
            var pracownik = await _pracownikManager.FindByEmailAsync(dto.Email);
            if (pracownik == null) return BadRequest("nie ma takiego pracownika");
            pracownik.PasswordHash = new PasswordHasher<Pracownik>().HashPassword(pracownik, dto.Haslo);
            await _context.SaveChangesAsync();
            return Ok("Hasło Zmienione"); 
        }

        [HttpPost("WyslijMaila")]
        public async Task<IActionResult> WyslijMaila([FromBody] ZmianaHaslaDto dto)
        {
            
            var klient = await _klientManager.FindByEmailAsync(dto.Email);
            if (klient == null) return BadRequest("Nie ma takiego klienta");
            _klientService.WyslanieMaila(klient, klient.KodWeryfikacyjny);
            return Ok("Mail został wysłany");
           
            
        }

    }
}
