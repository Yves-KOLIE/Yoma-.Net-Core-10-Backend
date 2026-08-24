using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using YOMA.Models;

var builder = WebApplication.CreateBuilder(args);

// 1. Configuration des contrôleurs et du JSON (en une seule fois)
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.WriteIndented = true;
});

// 2. Configuration CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularOrigins", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// 3. Configuration de l'Authentification JWT
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

        options.Events = new JwtBearerEvents
        {
            OnChallenge = context =>
            {
                context.HandleResponse();
                context.Response.StatusCode = 401;
                context.Response.ContentType = "application/json";

                var problem = new
                {
                    Message = "Token invalide ou expiré. Veuillez vous déconnecter et vous reconnecter à nouveau.",
                    Error = context.Error,
                    ErrorDescription = context.ErrorDescription
                };

                return context.Response.WriteAsync(JsonSerializer.Serialize(problem));
            }
        };
    });

builder.Services.AddAuthorization();

// 4. Injection des dépendances Services
builder.Services.AddScoped<JwtTokenService>();
builder.Services.AddScoped<LoginService>();
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

var app = builder.Build();

// --- PIPELINE DE MIDDLEWARE (L'ordre est crucial) ---

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
else
{
    app.UseExceptionHandler("/Error");
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

// A. CORS DOIT ÊTRE EN PREMIER (avant UseHttpsRedirection, UseRouting, Authentication, etc.)
app.UseCors("AllowAngularOrigins");

// B. Redirection HTTPS
app.UseHttpsRedirection();

// C. Authentification & Autorisation
app.UseAuthentication();
app.UseAuthorization();

// D. Mappage des routes
app.MapControllers();

app.Run();