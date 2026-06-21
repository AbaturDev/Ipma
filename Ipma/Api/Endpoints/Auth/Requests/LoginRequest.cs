using System.ComponentModel.DataAnnotations;

namespace Ipma.Api.Endpoints.Auth.Requests;

public sealed record LoginRequest
{
    [Required(ErrorMessage = "Login is required.")]
    [MaxLength(200, ErrorMessage = "Login must not exceed 200 characters.")]
    public required string Login { get; init; }

    [Required(ErrorMessage = "Password is required.")]
    [MaxLength(200, ErrorMessage = "Password must not exceed 200 characters.")]
    public required string Password { get; init; }
}
