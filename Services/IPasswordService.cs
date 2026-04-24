using Microsoft.AspNetCore.Identity;
using BCrypt.Net;

public interface IPasswordService
{
    public string HashPassword(string password) => BCrypt.Net.BCrypt.HashPassword(password);
    public bool IsValidPassword(string password, string hash) => BCrypt.Net.BCrypt.Verify(password, hash);
    public string GetDefaultPassword();
}
public class PasswordService : IPasswordService
{
    private string defaultPassword = "12345";
    public string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    public bool IsValidPassword(string password, string hash)
    {
        return BCrypt.Net.BCrypt.Verify(password, hash);
    }
    
    public string GetDefaultPassword()
    {
        return defaultPassword;
    }
}