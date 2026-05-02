using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YOMA.Helpers;
// using YOMA.Models.Tables;
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
                switch(loginModel.userTypeId)
                {
                    case 1: // Professeur
                        var user = await _context.Users
                            .Include(x => x.PROFESSIONAL_QUALIFICATION)
                            .Include(x => x.USER_ROLE)
                        .FirstOrDefaultAsync(x => 
                            !string.IsNullOrEmpty(x.EMAIL) && x.EMAIL.ToLower().Equals(loginModel.email.ToLower())
                        );

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
                    return Unauthorized(new LoginResult 
                    { 
                        UserIsConnected = false,
                        Message = "L'adresse email et ou le mot de passe est invalide.",
                        Error = null,
                        StatusCode = 401
                    });
                    
                    case 2: // Élèves
                        var student = await _context.Students
                            .Include(x => x.USER_ROLE)
                        .FirstOrDefaultAsync(x => 
                            !string.IsNullOrEmpty(x.EMAIL) && x.EMAIL.ToLower().Equals(loginModel.email.ToLower())
                        );

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
                    return Unauthorized(new LoginResult 
                    { 
                        UserIsConnected = false,
                        Message = "L'adresse email et ou le mot de passe est invalide.",
                        Error = null,
                        StatusCode = 401
                    });

                    case 3: // Parent d'élèves
                        var parent = await _context.Parents
                            .Include(x => x.PROFESSIONAL_QUALIFICATION)
                            .Include(x => x.USER_ROLE)
                        .FirstOrDefaultAsync(x => 
                            !string.IsNullOrEmpty(x.EMAIL) 
                            && x.EMAIL.ToLower().Equals(loginModel.email.ToLower())
                        );

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
                    return Unauthorized(new LoginResult 
                    { 
                        UserIsConnected = false,
                        Message = "L'adresse email et ou le mot de passe est invalide.",
                        Error = null,
                        StatusCode = 401
                    });
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

        [HttpGet("generateEmailValidationCode/{userTypeId}/{email}")]
        public async Task<ActionResult> generateEmailValidationCode(int userTypeId, string email)
        {
            try
            {
                switch(userTypeId)
                {
                    case 1: // Professeur
                        var user = await _context.Users.FirstOrDefaultAsync(x => x.USER_TYPE_ID == userTypeId && !string.IsNullOrEmpty(x.EMAIL) && x.EMAIL.Equals(email));
                        if(user != null)
                        {
                            var now = DateTime.UtcNow; 
                            var validCode = await _context.ForgotUserPasswords
                                .Where(x => EF.Functions.Like(x.EMAIL.ToLower(), email.ToLower()))
                            .FirstOrDefaultAsync(x => x.EXPIRE_DATE > now);

                            if(validCode != null)
                            {
                                return BadRequest(new EmailValidation 
                                { 
                                    Success = false,
                                    Message = "Nous vous avons déjà envoyé un code encore valide. Passez à l'étape 2 pour valider le code reçu.",
                                    Error = null,
                                    StatusCode = 400
                                });
                            }

                            var forgotUserPassword = await _forgotUserPasswordService.CreateForgotPasswordAsync(email);
                            if(forgotUserPassword != null)
                            {
                                // Appel de la fonction qui envoi des mail ici

                                return Ok(new EmailValidation 
                                { 
                                    Success = true,
                                    Message = $"Nous venons d'envoyer un code de validation à l'adresse email {user.EMAIL}.",
                                    Error = null,
                                    StatusCode = 200
                                }); 
                            }
                            else
                            {
                                return BadRequest(new EmailValidation 
                                { 
                                    Success = false,
                                    Message = "Une erreur serveur est survenue lors de la génération du code. Veuillez reessayer plutard.",
                                    Error = null,
                                    StatusCode = 400
                                });
                            }
                        }
                        else
                        {
                            return BadRequest(new LoginResult 
                            { 
                                UserIsConnected = false,
                                Message = "L'adresse email fournit n'existe pas dans notre base de données.",
                                Error = null,
                                StatusCode = 400
                            });
                        }

                    case 2: // Élèves
                        var student = await _context.Students.FirstOrDefaultAsync(x => x.USER_TYPE_ID == userTypeId && !string.IsNullOrEmpty(x.EMAIL) && x.EMAIL.Equals(email));
                        if(student != null)
                        {
                            
                        }
                        else
                        {
                            
                        }
                    break;

                    case 3: // Parent d'élèves
                        var parent = await _context.Parents.FirstOrDefaultAsync(x => x.USER_TYPE_ID == userTypeId && !string.IsNullOrEmpty(x.EMAIL) && x.EMAIL.Equals(email));
                        if(parent != null)
                        {
                            
                        }
                        else
                        {
                            
                        }
                    break;
                }

                // return BadRequest(new LoginResult 
                // { 
                //     UserIsConnected = false,
                //     Message = "Le choix du type d'utilisateur est obligatoire.",
                //     Error = null,
                //     StatusCode = 401
                // });

                return BadRequest(new 
                { 
                    message = "Le choix du type d'utilisateur est obligatoire.",
                    error = "",
                    success = false,
                    statusCode = 400
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