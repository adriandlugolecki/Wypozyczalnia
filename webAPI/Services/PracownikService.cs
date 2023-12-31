using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using webAPI.Models;

namespace webAPI.Services
{
    public class PracownikService
    {
        private readonly UserManager<Pracownik> _pracownikManager;
        private readonly IConfiguration _konfiguracja;
        public PracownikService(UserManager<Pracownik> pracownikManager, IConfiguration konfiguracja) 
        {
            _pracownikManager = pracownikManager;
            _konfiguracja = konfiguracja;
        }
        public async Task<ServicesResponse> RejestracjaPacownikAsync(RejestracjaPracownikDto rejestracja)
        {
            if (rejestracja == null)
            {
                throw new NullReferenceException("Wypełnij wymagane pola");
            }
            var pracownik = new Pracownik
            {
                Email = rejestracja.Email,
                UserName = rejestracja.Email,
                Imie = rejestracja.Imie,
                Nazwisko = rejestracja.Nazwisko,
                DataUrodzenia = rejestracja.DataUrodzenia,
                Pesel = rejestracja.Pesel,
                czyAdmin = rejestracja.czyAdmin
            };
            var result = await _pracownikManager.CreateAsync(pracownik, rejestracja.Haslo!);

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
            var pracownik = await _pracownikManager.FindByEmailAsync(login.Email);
            if (pracownik == null)
            {
                return new ServicesResponse
                {
                    Wiadomosc = "Brak takiego Pracownika",
                    Powodzenie = false
                };

            }
            var result = await _pracownikManager.CheckPasswordAsync(pracownik, login.Password);

            if (!result)
            {
                return new ServicesResponse
                {
                    Wiadomosc = "Błędne hasło",
                    Powodzenie = false,
                };
            }
            string role = pracownik.czyAdmin ? "admin": "pracownik";
            Claim[] claims = new[]
            {
                new Claim("Email",login.Email),
                new Claim("Id", pracownik.Id),
                new Claim(ClaimTypes.Role, role),

            };
            
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_konfiguracja["Jwt:Key"]!));
            var credentials = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _konfiguracja["Jwt:Issuer"],
                audience: _konfiguracja["Jwt:Audience"],
                claims: claims,
                expires:DateTime.Now.AddDays(3),
                signingCredentials: credentials
                );

            return new ServicesResponse
            {
                Wiadomosc = "Zalogowano",
                Powodzenie = true,
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Role = role,

            };
        }
    }
}
