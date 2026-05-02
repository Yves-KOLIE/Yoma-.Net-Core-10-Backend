using Microsoft.EntityFrameworkCore;
using YOMA.Helpers;
using YOMA.Models;
using YOMA.Models.Tables;

public interface IForgotUserPasswordService
{
    Task<ForgotUserPassword?> CreateForgotPasswordAsync(string email);
}

public class ForgotUserPasswordService : IForgotUserPasswordService
{
    private readonly Context _context;
    private readonly PasswordService _passwordService;

    public ForgotUserPasswordService(Context context, PasswordService passwordService)
    {
        _context = context;
        _passwordService = passwordService;
    }

    public async Task<ForgotUserPassword?> CreateForgotPasswordAsync(string email)
    {
        try
        {
            var now = DateTime.UtcNow;
            var expireDate = now.AddMinutes(15);
            var randomCode = EmailHelper.GenerateCode();

            var forgotUserPassword = _context.ForgotUserPasswords.Add(new ForgotUserPassword
            {
                ID = 0,
                CODE_GENERETED = _passwordService.HashPassword(randomCode),
                EMAIL = email.Trim().ToLower(),
                CREATION_DATE = now,
                EXPIRE_DATE = expireDate
            });
            await _context.SaveChangesAsync();

            // Envoie du code par mail
            bool codeIsSended = await EmailHelper.SendResetPasswordEmailAsync(email.Trim().ToLower(), randomCode, expireDate);
            if(codeIsSended)
            {
                return forgotUserPassword.Entity;
            }
            else
            {
                // On supprime la données de la bd sur l'envoie du mail à échoué
                await _context.ForgotUserPasswords.Where(x => x.ID == forgotUserPassword.Entity.ID).ExecuteDeleteAsync();
                return null;
            }
        }
        catch
        {
            return null;
        }
    }
}