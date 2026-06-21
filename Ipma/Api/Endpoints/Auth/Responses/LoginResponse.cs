namespace Ipma.Api.Endpoints.Auth.Responses;

public sealed record LoginResponse
{
    public required string AccessToken { get; init; }
}