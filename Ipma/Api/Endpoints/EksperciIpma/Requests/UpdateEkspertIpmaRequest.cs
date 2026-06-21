using System.ComponentModel.DataAnnotations;
using Ipma.Api.Validation;

namespace Ipma.Api.Endpoints.EksperciIpma.Requests;

public sealed record UpdateEkspertIpmaRequest
{
    [Required]
    [Range(1900, int.MaxValue, ErrorMessage = "RokUkończeniaSzkoleńPeb must be at least 1900.")]
    [NotInFuture]
    public required int RokUkończeniaSzkoleńPeb { get; init; }

    [Required]
    [MaxLength(100, ErrorMessage = "Imie must not exceed 100 characters.")]
    public required string Imie { get; init; }

    [Required]
    [MaxLength(100, ErrorMessage = "Nazwisko must not exceed 100 characters.")]
    public required string Nazwisko { get; init; }

    [Required]
    [EmailAddress(ErrorMessage = "AdresEmail must be a valid email address.")]
    [MaxLength(200, ErrorMessage = "AdresEmail must not exceed 200 characters.")]
    public required string AdresEmail { get; init; }

    [Required]
    [Phone(ErrorMessage = "NrTelefonu must be a valid phone number.")]
    [MaxLength(20, ErrorMessage = "NrTelefonu must not exceed 20 characters.")]
    public required string NrTelefonu { get; init; }
}
