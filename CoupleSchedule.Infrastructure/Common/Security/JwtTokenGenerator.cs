using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CoupleSchedule.Application.Common.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace CoupleSchedule.Infrastructure.Common.Security;

public sealed class JwtTokenGenerator(JwtSettings jwtSettings) : IJwtTokenGenerator
{
    public string GenerateToken(Guid userId, string email)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
            new Claim("id", userId.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, email)
        };

        var token = new JwtSecurityToken(
            jwtSettings.Issuer,
            jwtSettings.Audience,
            claims,
            expires: DateTime.UtcNow.AddMinutes(jwtSettings.ExpiryMinutes),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}