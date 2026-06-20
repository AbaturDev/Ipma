using Ipma.Api.Endpoints.Auth.Responses;
using Ipma.Persistance;
using Ipma.Persistance.Entities;
using Ipma.Persistance.Entities.Commons;
using Ipma.Services.Jwt.Abstractions;
using Ipma.Services.Jwt.Dto;
using Ipma.Services.PasswordHasher.Abstractions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LoginRequest = Ipma.Api.Endpoints.Auth.Requests.LoginRequest;

namespace Ipma.Features.Auth;

public static class Login
{
    public static async Task<Results<Ok<LoginResponse>, BadRequest<ProblemDetails>>> HandleAsync(
        [FromBody] LoginRequest request,
        [FromServices] IpmaDbContext context,
        [FromServices] IJwtService jwtService,
        [FromServices] IPasswordHasher passwordHasher,
        CancellationToken ct
        )
    {
        var użytkownik = await context.Użytkownicy
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Login == request.Login, ct);

        if (użytkownik is null)
            return TypedResults.BadRequest(new ProblemDetails
            {
                
            });

        if (!passwordHasher.Verify(request.Password, użytkownik.Hasło))
            return TypedResults.BadRequest(new ProblemDetails
            {
                
            });
        
        var role = użytkownik switch
        {
            Aplikant => nameof(Aplikant),
            Asesor => nameof(Asesor),
            CzłonekJury => nameof(CzłonekJury),
            PrzedstawicielBiuraNagrody => nameof(PrzedstawicielBiuraNagrody),
            _ => nameof(KontoUżytkownika)
        };

        var authUserDto = new AuthUserDto
        {
            Id = użytkownik.Id,
            Login = request.Login,
            Role = role
        };

        var token = jwtService.GenerateAccessToken(authUserDto);

        return TypedResults.Ok(new LoginResponse
        {
            AccessToken = token
        });
    }
}
