using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using MimeKit;
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
        public async Task<ServicesKomunikat> RejestracjaAsync(RejestracjaDto rejestracja)
        {
            if (rejestracja == null)
            {
                throw new NullReferenceException("Wypełnij wymagane pola");
            }
            string kod = "";
            Random losowa = new();
            for (int j = 0; j < 6; j++)
            {
                kod += losowa.Next(0, 9).ToString();
            }
            var klient = new Klient
            {
                Email = rejestracja.Email,
                UserName = rejestracja.Email,
                Imie = rejestracja.Imie,
                Nazwisko = rejestracja.Nazwisko,
                DataUrodzenia = rejestracja.DataUrodzenia,
                Pesel = rejestracja.Pesel,
                EmailConfirmed = false,
                KodWeryfikacyjny = kod,
                PhoneNumber = rejestracja.NumerTelefonu
            };
            var wynik = await _klientManager.CreateAsync(klient, rejestracja.Haslo);

            if (wynik.Succeeded)
            {
                await _klientManager.AddToRoleAsync(klient, "klient");
                WyslanieMaila(klient,kod);
                return new ServicesKomunikat
                {
                    Wiadomosc = "ok",
                    Powodzenie = true,
                   
                };
            }
            return new ServicesKomunikat
            {
                Wiadomosc = "Nie utworzono",
                Powodzenie = false
            };
        }
        public async Task<ServicesKomunikat> LoginAsync(LoginDto login)
        {
            var klient = await _klientManager.FindByEmailAsync(login.Email);
            if (klient == null)
            {
                return new ServicesKomunikat
                {
                    Wiadomosc = "Brak takiego Klienta",
                    Powodzenie = false
                };

            }
            if (klient.EmailConfirmed == false)
            {
                return new ServicesKomunikat
                {
                    Wiadomosc = "Konto nie zostało aktywowane",
                    Powodzenie = false
                };
            }

            var wynik = await _klientManager.CheckPasswordAsync(klient, login.Password);

            if(!wynik)
            {
                return new ServicesKomunikat
                {
                    Wiadomosc = "Błędne hasło",
                    Powodzenie = false,
                };
            }
            var claims = new[]
            {
                new Claim("id", klient.Id),
                new Claim("Email",login.Email),
                new Claim(ClaimTypes.NameIdentifier, klient.Id),
                new Claim(ClaimTypes.Role,"klient"),

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

            return new ServicesKomunikat
            {

                Wiadomosc = "Zalogowano jako klient",
                Powodzenie = true,
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Role = "klient",

            };
        }
        public void WyslanieMaila(Klient klient, string kod)
        {
            var mimeMessage = new MimeMessage();
            mimeMessage.From.Add(new MailboxAddress("Wypozyczalnia", "pracowniadyplomowawypozyczalni@gmail.com"));
            mimeMessage.To.Add(new MailboxAddress(klient.Email, klient.Email));
            mimeMessage.Subject = "Kod Weryfikacyjny";
            var tresc = new BodyBuilder
            {
                HtmlBody = "Kod " + kod
            };
            mimeMessage.Body = tresc.ToMessageBody();

            using var smtpClient = new MailKit.Net.Smtp.SmtpClient();
            smtpClient.Connect("smtp.gmail.com", 587, false);
            smtpClient.Authenticate("pracowniadyplomowawypozyczalni@gmail.com", "asargzwtgkqpbklq");
            smtpClient.Send(mimeMessage);
            smtpClient.Disconnect(true);
        }


    }
}
