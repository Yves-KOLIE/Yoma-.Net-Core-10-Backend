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
builder.Services.AddScoped<SchoolEducationService>();
builder.Services.AddScoped<HightSchoolOptionService>();
builder.Services.AddScoped<EducationLevelService>();
builder.Services.AddScoped<GasStationService>();
builder.Services.AddScoped<MonthOfSalaryService>();
builder.Services.AddScoped<MonthlySalaryAssignmentService>();
builder.Services.AddScoped<NoteMonthService>();
builder.Services.AddScoped<CoursService>();
builder.Services.AddScoped<StudentRegistrationService>();
builder.Services.AddScoped<StudentService>();
builder.Services.AddScoped<PasswordService>();


builder.Services.AddDbContext<Context>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();

// 1. Ajoute les contrôleurs
builder.Services.AddControllers();

// 2. Ajoute CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularOrigins", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

// 3. Active CORS (important : avant les routes)
app.UseCors("AllowAngularOrigins");

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers(); // IMPORTANT : Expose tes contrôleurs
app.Run();