using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YOMA.Helpers;
using YOMA.Models;

namespace YOMA.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly Context _context;
        private readonly ForgotUserPasswordService _forgotUserPasswordService;

        public LoginController(Context context, ForgotUserPasswordService forgotUserPasswordService)
        {
            _context = context;
            _forgotUserPasswordService = forgotUserPasswordService;
        }

        [HttpPost("Auth")]
        public async Task<ActionResult<LoginResult>> Auth([FromBody] LoginModel loginModel)
        {
            try
            {
                var userEmail = await _context.UserEmails.FirstOrDefaultAsync(x => x.EMAIL == loginModel.email);
                if(userEmail != null)
                {
                    switch(userEmail.USER_TYPE_ID)
                    {
                        case 1: // Professeur
                            var user = await _context.Users
                                .Include(x => x.PROFESSIONAL_QUALIFICATION)
                                .Include(x => x.USER_ROLE)
                                .Include(x => x.USER_EMAIL)
                            .FirstOrDefaultAsync(x => x.USER_EMAIL_ID == userEmail.USER_TYPE_ID);

                            if(user != null)
                            {
                                bool isValidPassword = PasswordHelper.IsValidPassword(loginModel.password, user.PASSWORD);
                                if(isValidPassword)
                                {
                                    if(loginModel.password.Equals(ConstantHelper.DEFAULT_PASSWORD))
                                    {
                                        return Ok(new LoginResult 
                                        { 
                                            UserIsConnected = false,
                                            Message = $"{GetDayPeriod()} {user.NAME}, vous devez obligatoirement changer votre mot de passe avant de continuer.",
                                            Error = null,
                                            StatusCode = 200,
                                            IsChangePassword = true,
                                            ConnectedUser = user
                                        }); 
                                    }
                                    else
                                    {
                                        return Ok(new LoginResult 
                                        { 
                                            UserIsConnected = isValidPassword,
                                            Message = $"{GetDayPeriod()} {user.NAME}",
                                            Error = null,
                                            StatusCode = 200,
                                            ConnectedUser = user
                                        });
                                    }
                                }
                            }
                        break;

                        case 2: // Élèves
                            var student = await _context.Students
                                .Include(x => x.USER_ROLE)
                                .Include(x => x.USER_EMAIL)
                            .FirstOrDefaultAsync(x => x.USER_EMAIL_ID == userEmail.USER_TYPE_ID);

                            if(student != null)
                            {
                                bool isValidPassword = PasswordHelper.IsValidPassword(loginModel.password, student.PASSWORD);
                                if(isValidPassword)
                                {
                                    if(loginModel.password.Equals(ConstantHelper.DEFAULT_PASSWORD))
                                    {
                                        return Ok(new LoginResult 
                                        { 
                                            UserIsConnected = false,
                                            Message = $"{GetDayPeriod()} {student.NAME}, vous devez obligatoirement changer votre mot de passe avant de continuer.",
                                            Error = null,
                                            StatusCode = 200,
                                            IsChangePassword = true,
                                            ConnectedUser = student
                                        }); 
                                    }
                                    else
                                    {
                                        return Ok(new LoginResult 
                                        { 
                                            UserIsConnected = isValidPassword,
                                            Message = $"{GetDayPeriod()} {student.NAME}",
                                            Error = null,
                                            StatusCode = 200,
                                            ConnectedUser = student
                                        });
                                    }
                                }
                            }
                        break;

                        case 3: // Parent d'élèves
                            var parent = await _context.Parents
                                .Include(x => x.PROFESSIONAL_QUALIFICATION)
                                .Include(x => x.USER_ROLE)
                                .Include(x => x.USER_EMAIL)
                            .FirstOrDefaultAsync(x => x.USER_EMAIL_ID == userEmail.USER_TYPE_ID);

                            if(parent != null)
                            {
                                bool isValidPassword = PasswordHelper.IsValidPassword(loginModel.password, parent.PASSWORD);
                                if(isValidPassword)
                                {
                                    if(loginModel.password.Equals(ConstantHelper.DEFAULT_PASSWORD))
                                    {
                                        return Ok(new LoginResult 
                                        { 
                                            UserIsConnected = false,
                                            Message = $"{GetDayPeriod()} {parent.NAME}, vous devez obligatoirement changer votre mot de passe avant de continuer.",
                                            Error = null,
                                            StatusCode = 200,
                                            IsChangePassword = true,
                                            ConnectedUser = parent
                                        }); 
                                    }
                                    else
                                    {
                                        return Ok(new LoginResult 
                                        { 
                                            UserIsConnected = isValidPassword,
                                            Message = $"{GetDayPeriod()} {parent.NAME}",
                                            Error = null,
                                            StatusCode = 200,
                                            ConnectedUser = parent
                                        });
                                    }
                                }
                            }
                        break;
                    }
                }

                return BadRequest(new LoginResult 
                { 
                    UserIsConnected = false,
                    Message = "Le choix du type d'utilisateur est obligatoire.",
                    Error = null,
                    StatusCode = 400
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new LoginResult 
                { 
                    UserIsConnected = false,
                    Message = "Une erreur coté serveur s'est produite.",
                    Error = ex,
                    StatusCode = 500
                });
            }
        }

        [HttpGet("generateEmailValidationCode/{email}")]
        public async Task<ActionResult> generateEmailValidationCode(string email)
        {
            try
            {
                var userEmail = await _context.UserEmails.FirstOrDefaultAsync(x => x.EMAIL == email);
                if(userEmail != null)
                {
                    switch(userEmail.USER_TYPE_ID)
                    {
                        case 1: // Professeur
                            var user = await _context.Users
                                .Include(x => x.PROFESSIONAL_QUALIFICATION)
                                .Include(x => x.USER_ROLE)
                                .Include(x => x.USER_EMAIL)
                            .FirstOrDefaultAsync(x => x.USER_EMAIL_ID == userEmail.USER_TYPE_ID);

                            if(user != null)
                            {
                                var isValidForgotUserPassword = await EmailHelper.IsValidForgotUserPassword(email, _context);
                                if(isValidForgotUserPassword != null)
                                {
                                    return BadRequest(new EmailValidation 
                                    { 
                                        Success = false,
                                        Message = "Nous vous avons déjà envoyé un code encore valide.",
                                        Error = null,
                                        StatusCode = 400,
                                        ConnectedUser = user
                                    });
                                }
                                else
                                {
                                    var forgotUserPassword = await _forgotUserPasswordService.CreateForgotPasswordAsync(email);
                                    if(forgotUserPassword != null)
                                    {
                                        return Ok(new EmailValidation 
                                        { 
                                            Success = true,
                                            Message = $"Nous venons d'envoyer un code de validation à l'adresse email {email}.",
                                            Error = null,
                                            StatusCode = 200,
                                            ConnectedUser = user
                                        }); 
                                    }
                                }

                                return BadRequest(new EmailValidation 
                                { 
                                    Success = false,
                                    Message = "Une erreur serveur est survenue lors de la génération du code. Veuillez reessayer plutard.",
                                    Error = null,
                                    StatusCode = 400,
                                    ConnectedUser = null
                                });
                            }
                        break;

                        case 2: // Élèves
                            var student = await _context.Students
                                .Include(x => x.USER_ROLE)
                                .Include(x => x.USER_EMAIL)
                            .FirstOrDefaultAsync(x => x.USER_EMAIL_ID == userEmail.USER_TYPE_ID);

                            if(student != null)
                            {
                                var isValidForgotUserPassword = await EmailHelper.IsValidForgotUserPassword(email, _context);
                                if(isValidForgotUserPassword != null)
                                {
                                    return BadRequest(new EmailValidation 
                                    { 
                                        Success = false,
                                        Message = "Nous vous avons déjà envoyé un code encore valide.",
                                        Error = null,
                                        StatusCode = 400,
                                        ConnectedUser = student
                                    });
                                }
                                else
                                {
                                    var forgotUserPassword = await _forgotUserPasswordService.CreateForgotPasswordAsync(email);
                                    if(forgotUserPassword != null)
                                    {
                                        return Ok(new EmailValidation 
                                        { 
                                            Success = true,
                                            Message = $"Nous venons d'envoyer un code de validation à l'adresse email {email}.",
                                            Error = null,
                                            StatusCode = 200,
                                            ConnectedUser = student
                                        }); 
                                    }
                                }

                                return BadRequest(new EmailValidation 
                                { 
                                    Success = false,
                                    Message = "Une erreur serveur est survenue lors de la génération du code. Veuillez reessayer plutard.",
                                    Error = null,
                                    StatusCode = 400,
                                    ConnectedUser = null
                                });
                            }
                        break;

                        case 3: // Parent d'élèves
                            var parent = await _context.Parents
                                .Include(x => x.PROFESSIONAL_QUALIFICATION)
                                .Include(x => x.USER_ROLE)
                                .Include(x => x.USER_EMAIL)
                            .FirstOrDefaultAsync(x => x.USER_EMAIL_ID == userEmail.USER_TYPE_ID);

                            if(parent != null)
                            {
                                var isValidForgotUserPassword = await EmailHelper.IsValidForgotUserPassword(email, _context);
                                if(isValidForgotUserPassword != null)
                                {
                                    return BadRequest(new EmailValidation 
                                    { 
                                        Success = false,
                                        Message = "Nous vous avons déjà envoyé un code encore valide.",
                                        Error = null,
                                        StatusCode = 400,
                                        ConnectedUser = parent
                                    });
                                }
                                else
                                {
                                    var forgotUserPassword = await _forgotUserPasswordService.CreateForgotPasswordAsync(email);
                                    if(forgotUserPassword != null)
                                    {
                                        return Ok(new EmailValidation 
                                        { 
                                            Success = true,
                                            Message = $"Nous venons d'envoyer un code de validation à l'adresse email {email}.",
                                            Error = null,
                                            StatusCode = 200,
                                            ConnectedUser = parent
                                        }); 
                                    }
                                }

                                return BadRequest(new EmailValidation 
                                { 
                                    Success = false,
                                    Message = "Une erreur serveur est survenue lors de la génération du code. Veuillez reessayer plutard.",
                                    Error = null,
                                    StatusCode = 400,
                                    ConnectedUser = null
                                });
                            }
                        break;
                    }
                }

                return BadRequest(new EmailValidation 
                { 
                    Success = false,
                    Message = "Cette adresse email n'existe pas dans notre base de données.",
                    Error = null,
                    StatusCode = 400,
                    ConnectedUser = null
                });
            }
            catch(Exception ex)
            {
                return BadRequest(new EmailValidation
                { 
                    Success = false,
                    Message = "Cette adresse email n'existe pas dans notre base de données.",
                    Error = ex,
                    StatusCode = 400,
                    ConnectedUser = null
                });
            }
        }

        [HttpGet("validateEmailCode/{email}/{generedCode}")]
        public async Task<ActionResult> validateEmailCode(string email, string generedCode)
        {
            try
            {
                var userEmail = await _context.UserEmails.FirstOrDefaultAsync(x => x.EMAIL == email);
                if(userEmail != null)
                {
                    switch(userEmail.USER_TYPE_ID)
                    {
                        case 1: // Professeur
                            var user = await _context.Users
                                .Include(x => x.PROFESSIONAL_QUALIFICATION)
                                .Include(x => x.USER_ROLE)
                                .Include(x => x.USER_EMAIL)
                            .FirstOrDefaultAsync(x => x.USER_EMAIL_ID == userEmail.USER_TYPE_ID);

                            if(user != null)
                            {
                                var forgotUserPassword = await EmailHelper.IsValidForgotUserPassword(email, _context);
                                if(forgotUserPassword != null)
                                {
                                    bool isValidCode = PasswordHelper.IsValidCode(generedCode, forgotUserPassword.CODE_GENERETED);
                                    if(isValidCode)
                                    {
                                        // Désactiver le code validé
                                        await _context.ForgotUserPasswords
                                            .Where(x => x.ID == forgotUserPassword.ID)
                                        .ExecuteUpdateAsync(u => u.SetProperty(x => x.IS_VALIDED, true));

                                        return Ok(new EmailValidation 
                                        { 
                                            Success = true,
                                            Message = "Code validé avec succès.",
                                            Error = null,
                                            StatusCode = 400,
                                            ConnectedUser = user
                                        });
                                    }
                                }

                                return BadRequest(new EmailValidation 
                                { 
                                    Success = false,
                                    Message = "Le code que vous avez saisi a expiré ou est invalide.",
                                    Error = null,
                                    StatusCode = 400,
                                    ConnectedUser = user
                                });
                            }
                        break;

                        case 2: // Élèves
                            var student = await _context.Students
                                .Include(x => x.USER_ROLE)
                                .Include(x => x.USER_EMAIL)
                            .FirstOrDefaultAsync(x => x.USER_EMAIL_ID == userEmail.USER_TYPE_ID);

                            if(student != null)
                            {
                                var forgotUserPassword = await EmailHelper.IsValidForgotUserPassword(email, _context);
                                if(forgotUserPassword != null)
                                {
                                    bool isValidCode = PasswordHelper.IsValidCode(generedCode, forgotUserPassword.CODE_GENERETED);
                                    if(isValidCode)
                                    {
                                        // Désactiver le code validé
                                        await _context.ForgotUserPasswords
                                            .Where(x => x.ID == forgotUserPassword.ID)
                                        .ExecuteUpdateAsync(u => u.SetProperty(x => x.IS_VALIDED, true));

                                        return Ok(new EmailValidation 
                                        { 
                                            Success = true,
                                            Message = "Code validé avec succès.",
                                            Error = null,
                                            StatusCode = 400,
                                            ConnectedUser = student
                                        });
                                    }
                                }

                                return BadRequest(new EmailValidation 
                                { 
                                    Success = false,
                                    Message = "Le code que vous avez saisi a expiré ou est invalide.",
                                    Error = null,
                                    StatusCode = 400,
                                    ConnectedUser = student
                                });
                            }
                        break;

                        case 3: // Parent d'élèves
                            var parent = await _context.Parents
                                .Include(x => x.PROFESSIONAL_QUALIFICATION)
                                .Include(x => x.USER_ROLE)
                                .Include(x => x.USER_EMAIL)
                            .FirstOrDefaultAsync(x => x.USER_EMAIL_ID == userEmail.USER_TYPE_ID);

                            if(parent != null)
                            {
                                var forgotUserPassword = await EmailHelper.IsValidForgotUserPassword(email, _context);
                                if(forgotUserPassword != null)
                                {
                                    bool isValidCode = PasswordHelper.IsValidCode(generedCode, forgotUserPassword.CODE_GENERETED);
                                    if(isValidCode)
                                    {
                                        // Désactiver le code validé
                                        await _context.ForgotUserPasswords
                                            .Where(x => x.ID == forgotUserPassword.ID)
                                        .ExecuteUpdateAsync(u => u.SetProperty(x => x.IS_VALIDED, true));

                                        return Ok(new EmailValidation 
                                        { 
                                            Success = true,
                                            Message = "Code validé avec succès.",
                                            Error = null,
                                            StatusCode = 400,
                                            ConnectedUser = parent
                                        });
                                    }
                                }

                                return BadRequest(new EmailValidation 
                                { 
                                    Success = false,
                                    Message = "Le code que vous avez saisi a expiré ou est invalide.",
                                    Error = null,
                                    StatusCode = 400,
                                    ConnectedUser = parent
                                });
                            }
                        break;
                    }
                }

                return BadRequest(new EmailValidation 
                { 
                    Success = false,
                    Message = "Cette adresse email n'existe pas dans notre base de données.",
                    Error = null,
                    StatusCode = 400,
                    ConnectedUser = null
                });
            }
            catch(Exception ex)
            {
                return BadRequest(new EmailValidation
                { 
                    Success = false,
                    Message = "Cette adresse email n'existe pas dans notre base de données.",
                    Error = ex,
                    StatusCode = 400,
                    ConnectedUser = null
                });
            }
        }

        private string GetDayPeriod()
        {
            return DateTime.UtcNow.Hour < 12 ? "Bonjour" : "Bonsoir";
        }
    }


}