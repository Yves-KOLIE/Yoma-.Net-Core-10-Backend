using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

public interface IJwtTokenService
{
    /// <summary>
    /// Crée un access token JWT pour un utilisateur.
    /// </summary>
    /// <param name="userId">Identifiant unique de l'utilisateur.</param>
    /// <param name="role">Rôle de l'utilisateur (ex: "User", "Admin").</param>
    /// <returns>Chaîne formatée du JWT (access token).</returns>
    string CreateAccessToken(int userId, string role);

    /// <summary>
    /// Valide si un token JWT est encore valide (signature, lifetime, issuer, audience).
    /// Utile si tu veux faire une vérification côté service avant de le rejouer à l'API.
    /// </summary>
    /// <param name="token">Token JWT à valider.</param>
    /// <returns>True si valide, false sinon.</returns>
    bool IsTokenValid(string token);
}

public class JwtTokenService : IJwtTokenService
{
    private readonly IConfiguration _configuration;

    public JwtTokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string CreateAccessToken(int userId, string role)
    {
        var issuer    = _configuration["Jwt:Issuer"];
        var audience  = _configuration["Jwt:Audience"];
        var key       = Encoding.UTF8.GetBytes(_configuration["Jwt:SigningKey"]!);

        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
            new Claim(ClaimTypes.Role, role),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()) // jti pour revocation éventuelle
        };

        var creds = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            notBefore: DateTime.UtcNow,
            expires: DateTime.UtcNow.AddMinutes(15), // access token court, tu peux ajuster
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public bool IsTokenValid(string token)
    {
        var issuer   = _configuration["Jwt:Issuer"];
        var audience = _configuration["Jwt:Audience"];
        var key      = Encoding.UTF8.GetBytes(_configuration["Jwt:SigningKey"]!);

        var parameters = new TokenValidationParameters
        {
            ValidateIssuer           = true,
            ValidIssuer              = issuer,
            ValidateAudience         = true,
            ValidAudience            = audience,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey         = new SymmetricSecurityKey(key),
            ValidateLifetime         = true,
            ClockSkew                = TimeSpan.FromMinutes(1)
        };

        var handler = new JwtSecurityTokenHandler();

        try
        {
            handler.ValidateToken(token, parameters, out _);
            return true;
        }
        catch
        {
            return false;
        }
    }
}
