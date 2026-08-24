using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YOMA;
using YOMA.Helpers;
using YOMA.Models;
using YOMA.Models.Tables;

public interface ILoginService
{
    EmailValidation CodeAlreadySent();
    EmailValidation CodeIsGenerated();
    EmailValidation EmptyCodeGenerated();
    string GetDayPeriod();
    string getSplitedUserName(string name);
}

public class LoginService : ILoginService
{
    public readonly Context _context;

    public LoginService(Context context)
    {
        _context = context;
    }

    public EmailValidation CodeAlreadySent()
    {
        return new EmailValidation 
        {
            codeAlreadyIsSent = true,
            message = "Nous vous avons déjà envoyé un code encore valide.",
        };
    }

    public EmailValidation CodeIsGenerated(string userEmail)
    {
        return new EmailValidation 
        { 
            codeIsGenerated = true,
            message = $"Nous venons d'envoyer un code de validation à l'adresse email {userEmail}.",
        };
    }

    public EmailValidation CodeIsGenerated()
    {
        throw new NotImplementedException();
    }

    public EmailValidation EmptyCodeGenerated()
    {
        return new EmailValidation 
        { 
            message = "Une erreur serveur est survenue lors de la génération du code. Veuillez reessayer plutard.",
        };
    }

    public string GetDayPeriod()
    {
        return DateTime.UtcNow.Hour < 12 ? "Bonjour" : "Bonsoir";
    }

    public string getSplitedUserName(string name)
    {
        if(name.Contains(" "))
        {
            return name.Split(" ")[0].Trim();
        }
        return name;
    }
}