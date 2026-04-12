using Microsoft.EntityFrameworkCore;
using YOMA.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.WriteIndented = true;
});

builder.Services.AddScoped<ISchoolYearService, SchoolYearService>();
builder.Services.AddScoped<IBankService, BankService>();
builder.Services.AddScoped<IBirthPlaceService, BirthPlaceService>();
builder.Services.AddScoped<IBusFessService, BusFessService>();
builder.Services.AddScoped<ISubdivision, SubdivisionService>();

builder.Services.AddDbContext<Context>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers(); // IMPORTANT : Expose tes contrôleurs
app.Run();