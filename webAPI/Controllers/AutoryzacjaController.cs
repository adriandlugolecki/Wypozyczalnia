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
        private IUserService<LoginDto> _pracownikService;
        private UserManager<Pracownik> _pracownikManager;
        public AutoryzacjaController( IUserService<LoginDto> pracwonikService,UserManager<Pracownik> pracownikManager)
        {
            _pracownikManager = pracownikManager;
            _pracownikService = pracwonikService;
        }
        [HttpPost]
        public async Task<IActionResult> LoginAsync([FromBody] LoginDto login)
        {
            var result = new UserManagerResponse();
            result = await _pracownikService.LoginUserAsync(login);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
