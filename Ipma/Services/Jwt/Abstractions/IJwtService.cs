using Ipma.Services.Jwt.Dto;

namespace Ipma.Services.Jwt.Abstractions;

public interface IJwtService
{
    public string GenerateAccessToken(AuthUserDto user);
}