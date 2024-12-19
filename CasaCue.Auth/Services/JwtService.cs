using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace CasaCue.Services
{
    public class JwtService
    {
        private readonly string _secret;
        private readonly int _tokenExpiryMinutes = 60;

        public JwtService(string secret)
        {
            _secret = secret;
        }

        public string GenerateToken(string username)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: "CasaCue",
                audience: "CasaCue",
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_tokenExpiryMinutes),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}