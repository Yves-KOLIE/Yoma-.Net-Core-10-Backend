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
        private readonly PasswordService _passwordService;
        private readonly ForgotUserPasswordService _forgotUserPasswordService;

        public LoginController(Context context, PasswordService passwordService, ForgotUserPasswordService forgotUserPasswordService)
        {
            _context = context;
            _passwordService = passwordService;
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
                    switch(userEmail.UPDATED_USER_ID)
                    {
                        case 1: // Professeur
                            var user = await _context.Users
                                .Include(x => x.PROFESSIONAL_QUALIFICATION)
                                .Include(x => x.USER_ROLE)
                            .FirstOrDefaultAsync(x => x.USER_EMAIL_ID == userEmail.UPDATED_USER_ID);

                            if(user != null)
                            {
                                bool isValidPassword = _passwordService.IsValidPassword(loginModel.password, user.PASSWORD);
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
                            .FirstOrDefaultAsync(x => x.USER_EMAIL_ID == userEmail.UPDATED_USER_ID);

                            if(student != null)
                            {
                                bool isValidPassword = _passwordService.IsValidPassword(loginModel.password, student.PASSWORD);
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
                            .FirstOrDefaultAsync(x => x.USER_EMAIL_ID == userEmail.UPDATED_USER_ID);

                            if(parent != null)
                            {
                                bool isValidPassword = _passwordService.IsValidPassword(loginModel.password, parent.PASSWORD);
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
                    switch(userEmail.UPDATED_USER_ID)
                    {
                        case 1: // Professeur
                            var user = await _context.Users.FirstOrDefaultAsync(x => x.USER_EMAIL_ID == userEmail.UPDATED_USER_ID);
                            if(user != null)
                            {
                                bool isExpiredCode = await EmailHelper.IsExpiredCode(email, _context);
                                if(isExpiredCode)
                                {
                                    return BadRequest(new EmailValidation 
                                    { 
                                        Success = false,
                                        Message = "Nous vous avons déjà envoyé un code encore valide. Passez à l'étape 2 pour valider le code reçu.",
                                        Error = null,
                                        StatusCode = 400
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
                                            StatusCode = 200
                                        }); 
                                    }
                                }

                                return BadRequest(new EmailValidation 
                                { 
                                    Success = false,
                                    Message = "Une erreur serveur est survenue lors de la génération du code. Veuillez reessayer plutard.",
                                    Error = null,
                                    StatusCode = 400
                                });
                            }
                        break;

                        case 2: // Élèves
                            var student = await _context.Students.FirstOrDefaultAsync(x => x.USER_EMAIL_ID == userEmail.UPDATED_USER_ID);
                            if(student != null)
                            {
                                bool isExpiredCode = await EmailHelper.IsExpiredCode(email, _context);
                                if(isExpiredCode)
                                {
                                    return BadRequest(new EmailValidation 
                                    { 
                                        Success = false,
                                        Message = "Nous vous avons déjà envoyé un code encore valide. Passez à l'étape 2 pour valider le code reçu.",
                                        Error = null,
                                        StatusCode = 400
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
                                            StatusCode = 200
                                        }); 
                                    }
                                }

                                return BadRequest(new EmailValidation 
                                { 
                                    Success = false,
                                    Message = "Une erreur serveur est survenue lors de la génération du code. Veuillez reessayer plutard.",
                                    Error = null,
                                    StatusCode = 400
                                });
                            }
                        break;

                        case 3: // Parent d'élèves
                            var parent = await _context.Parents.FirstOrDefaultAsync(x => x.USER_EMAIL_ID == userEmail.UPDATED_USER_ID);
                            if(parent != null)
                            {
                                bool isExpiredCode = await EmailHelper.IsExpiredCode(email, _context);
                                if(isExpiredCode)
                                {
                                    return BadRequest(new EmailValidation 
                                    { 
                                        Success = false,
                                        Message = "Nous vous avons déjà envoyé un code encore valide. Passez à l'étape 2 pour valider le code reçu.",
                                        Error = null,
                                        StatusCode = 400
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
                                            StatusCode = 200
                                        }); 
                                    }
                                }

                                return BadRequest(new EmailValidation 
                                { 
                                    Success = false,
                                    Message = "Une erreur serveur est survenue lors de la génération du code. Veuillez reessayer plutard.",
                                    Error = null,
                                    StatusCode = 400
                                });
                            }
                        break;
                    }
                }

                return BadRequest(new LoginResult 
                { 
                    UserIsConnected = false,
                    Message = "Cette adresse email n'existe pas dans notre base de données.",
                    Error = null,
                    StatusCode = 401
                });
            }
            catch(Exception ex)
            {
                return BadRequest(new 
                { 
                    message = "Une erreur coté serveur s'est produite.",
                    error = ex,
                    success = false,
                    statusCode = 500
                });
            }
        }


        private string GetDayPeriod()
        {
            return DateTime.UtcNow.Hour < 12 ? "Bonjour" : "Bonsoir";
        }

        // private int RandomNumber()
        // {
        //     var numero = _random.Next(0, 10000);
        //     return numero.ToString("D4");  // Force 4 chiffres avec zéros
        // }

    }


}