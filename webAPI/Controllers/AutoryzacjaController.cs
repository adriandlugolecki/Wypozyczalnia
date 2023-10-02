using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
        public AutoryzacjaController( PracownikService pracwonikService,KlientService klientService, UserManager<Pracownik> pracownikManager)
        {
            _pracownikManager = pracownikManager;
            _pracownikService = pracwonikService;
            _klientService = klientService;
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
    }
}
