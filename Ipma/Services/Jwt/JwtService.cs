using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Ipma.Options;
using Ipma.Services.Jwt.Abstractions;
using Ipma.Services.Jwt.Dto;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Ipma.Services.Jwt;

public class JwtService : IJwtService
{
    private readonly JwtOptions _jwtOptions;
    private readonly TimeProvider _timeProvider;
    
    public JwtService(IOptions<JwtOptions> jwtOptions, TimeProvider timeProvider)
    {
        _timeProvider = timeProvider;
        _jwtOptions = jwtOptions.Value;
    }
    
    public string GenerateAccessToken(AuthUserDto user)
    {
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new(JwtRegisteredClaimNames.UniqueName, user.Login),
            new("role", user.Role),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };
        
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Secret));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

        var token = new JwtSecurityToken(
            issuer: _jwtOptions.Issuer,
            audience: _jwtOptions.Audience,
            claims: claims,
            expires: _timeProvider.GetUtcNow().DateTime.AddMinutes(_jwtOptions.ExpirationInMinutes),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
        
    }
}