// namespace Ipma.Extensions;
//
// public class AuthorizationExtensions
// {
//     public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
//     {
//         var jwtSection = configuration.GetSection(JwtSettings.SectionName);
//         services.Configure<JwtSettings>(jwtSection);
//
//         var jwtSettings = jwtSection.Get<JwtSettings>()!;
//
//         services.AddScoped<ITokenService, TokenService>();
//
//         services.AddAuthentication(options =>
//             {
//                 options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//                 options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//             })
//             .AddJwtBearer(options =>
//             {
//                 options.TokenValidationParameters = new TokenValidationParameters
//                 {
//                     ValidateIssuer = true,
//                     ValidateAudience = true,
//                     ValidateLifetime = true,
//                     ValidateIssuerSigningKey = true,
//                     ValidIssuer = jwtSettings.Issuer,
//                     ValidAudience = jwtSettings.Audience,
//                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key))
//                 };
//             });
//
//         services.AddAuthorization();
//
//         return services;
//     }
// }