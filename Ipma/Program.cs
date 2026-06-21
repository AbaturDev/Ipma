using Ipma.Api;
using Ipma.Extensions;
using Ipma.Persistance;
using Ipma.Persistance.Seeders;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton(TimeProvider.System);

builder.Services.AddDbContext<IpmaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddOpenApi();

builder.Services.AddProblemDetails();

builder.Services.RegisterOptions();
builder.Services.RegisterServices();

builder.AddApiAuthentication();

builder.Services.AddScoped<DbSeeder>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseApiAuthentication();

app.RegisterEndpoints();

using (var scope = app.Services.CreateScope())
{
    var seeder = scope.ServiceProvider.GetRequiredService<DbSeeder>();
    await seeder.SeedAsync();
}

app.Run();
