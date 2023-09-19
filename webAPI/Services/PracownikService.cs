using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using webAPI.Models;

namespace webAPI.Services
{
    public class PracownikService : IUserService<LoginDto> 
    {
        private readonly UserManager<Pracownik> _pracownikManager;
        private readonly IConfiguration _configuracja;
        public PracownikService(UserManager<Pracownik> pracownikManager, IConfiguration configuracja) 
        {
            _pracownikManager = pracownikManager;
            _configuracja = configuracja;
        }
        public async Task<UserManagerResponse> LoginUserAsync(LoginDto login)
        {
            var pracownik = await _pracownikManager.FindByEmailAsync(login.Email);
            if (pracownik == null)
            {
                return new UserManagerResponse
                {
                    Message = "Brak takiego użytkownika",
                    IsSuccess = false
                };

            }
            var claims = new[]
            {
                new Claim("Email",login.Email)
                
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuracja["Jwt:Key"]!));
            var credentials = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuracja["Jwt:Issuer"],
                audience: _configuracja["Jwt:Audience"],
                claims: claims,
                expires:DateTime.Now.AddDays(3),
                signingCredentials: credentials
                );

            return new UserManagerResponse
            {
                Message = "Login poprawny",
                IsSuccess = true,
                Token = new JwtSecurityTokenHandler().WriteToken(token),

            };
        }
    }
}
