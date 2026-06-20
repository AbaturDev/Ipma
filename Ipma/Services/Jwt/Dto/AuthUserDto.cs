namespace Ipma.Services.Jwt.Dto;

public sealed record AuthUserDto
{
    public required Guid Id { get; init; }
    public required string Login { get; init; }
    public required string Role { get; init; }
}