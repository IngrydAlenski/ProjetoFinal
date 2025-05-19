using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace APIProjetoFinal.Serveces
{
    public class TokenService
    {
        public string GenerateToken(string email)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, email)
            };

            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ee4f0db1a86eeddfe9d7e9b68be0ff11860114bc14cf867570e1e3a7fa1d93ad"));

            var creds = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
                (
                issuer: "APIProjetoFinal",
                audience: "APIProjetoFinal",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
