using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidateAudience = true,
            ValidAudience = builder.Configuration["Jwt:Audience"],
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SigningKey"]!)),
            RequireExpirationTime = true,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.FromMinutes(1)
        };

        // Intercepter l'erreur "invalid token" pour renvoyer un JSON explicite
        options.Events = new JwtBearerEvents
        {
            OnChallenge = context =>
            {
                // Sur Unauthorized (token manquant ou invalide)
                context.HandleResponse();
                context.Response.StatusCode = 401;
                context.Response.ContentType = "application/json";

                var problem = new
                {
                    Message = "Token invalide ou expiré. Veuillez vous déconnecté et vous reconnecté à nouveau.",
                    Error = context.Error,
                    ErrorDescription = context.ErrorDescription
                };

                return context.Response.WriteAsync(JsonSerializer.Serialize(problem));
            }
        };
});
builder.Services.AddAuthorization();

builder.Services.AddScoped<JwtTokenService>();
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
builder.Services.AddScoped<UserTypeService>();
builder.Services.AddScoped<ForgotUserPasswordService>();


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

app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;
        context.Response.StatusCode = 500;
        context.Response.ContentType = "application/json";
        var result = JsonSerializer.Serialize(new { error = "Une erreur serveur est survenue.", message = exception?.Message });
        await context.Response.WriteAsync(result);
    });
});

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers(); // IMPORTANT : Expose tes contrôleurs
app.Run();