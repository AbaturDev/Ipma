using System.Text;
using Ipma.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Ipma.Extensions;

public static class AuthorizationExtensions
{
    public static void AddApiAuthentication(this IHostApplicationBuilder builder)
    {
        AddAuthentication(builder);
        AddAuthorization(builder);
    }

    public static void UseApiAuthentication(this WebApplication app)
    {
        app.UseAuthentication();
        app.UseAuthorization();
    }

    private static void AddAuthentication(IHostApplicationBuilder builder)
    {
        var jwtOptions = builder.Configuration.GetSection(JwtOptions.SectionName).Get<JwtOptions>();

        if (jwtOptions is null)
            return;

        builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ValidIssuer = jwtOptions.Issuer,
                    ValidAudience = jwtOptions.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Secret))
                };

                options.Events = new JwtBearerEvents
                {
                    OnChallenge = async context =>
                    {
                        context.HandleResponse();
                        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        context.Response.ContentType = "application/problem+json";

                        await context.Response.WriteAsJsonAsync(new ProblemDetails
                        {
                            Type = "https://tools.ietf.org/html/rfc7235#section-3.1",
                            Title = "Unauthorized",
                            Status = StatusCodes.Status401Unauthorized,
                            Detail = "You have to be authorized.",
                            Instance = context.Request.Path
                        });
                    },
                    OnForbidden = async context =>
                    {
                        context.Response.StatusCode = StatusCodes.Status403Forbidden;
                        context.Response.ContentType = "application/problem+json";

                        await context.Response.WriteAsJsonAsync(new ProblemDetails
                        {
                            Type = "https://tools.ietf.org/html/rfc7231#section-6.5.3",
                            Title = "Forbidden",
                            Status = StatusCodes.Status403Forbidden,
                            Detail = "You don not have access to this resource.",
                            Instance = context.Request.Path
                        });
                    }
                };
            });
    }

    private static void AddAuthorization(IHostApplicationBuilder builder)
    {
        builder.Services.AddAuthorization(options =>
        {
            options.AddPolicy(Policies.Aplikant, policy =>
                policy.RequireRole(Roles.Aplikant));

            options.AddPolicy(Policies.Asesor, policy =>
                policy.RequireRole(Roles.Asesor));

            options.AddPolicy(Policies.CzłonekJury, policy =>
                policy.RequireRole(Roles.CzłonekJury));

            options.AddPolicy(Policies.PrzedstawicielBiuraNagrody, policy =>
                policy.RequireRole(Roles.PrzedstawicielBiuraNagrody));
        });
    }
}

public static class Roles
{
    public const string Aplikant = nameof(Aplikant);
    public const string Asesor = nameof(Asesor);
    public const string CzłonekJury = nameof(CzłonekJury);
    public const string PrzedstawicielBiuraNagrody = nameof(PrzedstawicielBiuraNagrody);
}

public static class Policies
{
    public const string Aplikant = nameof(Aplikant);
    public const string Asesor = nameof(Asesor);
    public const string CzłonekJury = nameof(CzłonekJury);
    public const string PrzedstawicielBiuraNagrody = nameof(PrzedstawicielBiuraNagrody);
}
