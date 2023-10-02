using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using webAPI.Models;

namespace webAPI.Services
{
    public class KlientService
    {
        private readonly UserManager<Klient> _klientManager;
        private readonly IConfiguration _konfiguracja;
        public KlientService(UserManager<Klient> klientManager, IConfiguration konfiguracja)
        {
            _klientManager = klientManager;
            _konfiguracja = konfiguracja;
        }
        public async Task<ServicesResponse> RejestracjaAsync(RejestracjaDto rejestracja)
        {
            if (rejestracja == null)
            {
                throw new NullReferenceException("Wypełnij wymagane pola");
            }
            var klient = new Klient
            {
                Email = rejestracja.Email,
                UserName = rejestracja.Email,
                Imie = rejestracja.Imie,
                Nazwisko = rejestracja.Nazwisko,
                DataUrodzenia = rejestracja.DataUrodzenia,
                Pesel = rejestracja.Pesel,

            };
            var result = await _klientManager.CreateAsync(klient, rejestracja.Haslo);

            if (result.Succeeded)
            {
                return new ServicesResponse
                {
                    Wiadomosc = "ok",
                    Powodzenie = true
                };
            }
            return new ServicesResponse
            {
                Wiadomosc = "Nie utworzono",
                Powodzenie = false
            };
        }
        public async Task<ServicesResponse> LoginAsync(LoginDto login)
        {
            var klient = await _klientManager.FindByEmailAsync(login.Email);
            if (klient == null)
            {
                return new ServicesResponse
                {
                    Wiadomosc = "Brak takiego Klienta",
                    Powodzenie = false
                };

            }
            var claims = new[]
            {
                new Claim("Email",login.Email),
                new Claim(ClaimTypes.NameIdentifier, klient.Id),

            };
            
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_konfiguracja["Jwt:Key"]!));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _konfiguracja["Jwt:Issuer"],
                audience: _konfiguracja["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(3),
                signingCredentials: credentials
                );

            return new ServicesResponse
            {
                Wiadomosc = "Zaogowano jako klient",
                Powodzenie = true,
                Token = new JwtSecurityTokenHandler().WriteToken(token),

            };
        }

    }
}
