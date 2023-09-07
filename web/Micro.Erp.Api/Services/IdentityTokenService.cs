using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Micro.Erp.Application.Users.Commands.responses;
using Micro.Erp.Utils;
using Microsoft.IdentityModel.Tokens;

namespace Micro.Erp.Api.Services;

/// <summary>
/// Gerar Token de Autenticação e registrar Autorização
/// </summary>
public class IdentityTokenService
{
    public Task<string> GenerateToken(UserAutenticated data)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(Settings.JwtSecret);
        var claims = new List<Claim>();
        claims.AddRange(new []
        {
            new Claim(ClaimTypes.Name, data.User.Name),
            new Claim(ClaimTypes.NameIdentifier, data.User.Id.ToString()),
            new Claim(ClaimTypes.Email, data.User.Email),
            new Claim(ClaimTypes.Role, data.User.UserType),
            
        });
        claims.AddRange(data.Roles.Select(role => new Claim(ClaimTypes.Role, role)));
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = data.TokenExpires.AddMinutes(5),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return Task.FromResult(tokenHandler.WriteToken(token));
    }
}