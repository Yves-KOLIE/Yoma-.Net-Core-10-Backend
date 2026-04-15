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

builder.Services.AddScoped<BankService>();
builder.Services.AddScoped<BirthPlaceService>();
builder.Services.AddScoped<BusFessService>();
builder.Services.AddScoped<SchoolYearService>();
builder.Services.AddScoped<SubdivisionByYearService>();
builder.Services.AddScoped<SubdivisionService>();
builder.Services.AddScoped<TypePrimeService>();
builder.Services.AddScoped<EducationLevelService>();
builder.Services.AddScoped<GasStationService>();
builder.Services.AddScoped<MonthOfSalaryService>();


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