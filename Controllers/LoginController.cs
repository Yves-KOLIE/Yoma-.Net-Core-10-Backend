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

        public LoginController(Context context, PasswordService passwordService)
        {
            _context = context;
            _passwordService = passwordService;
        }

        [HttpPost("Auth")]
        public async Task<ActionResult<LoginResult>> Auth([FromBody] LoginModel loginModel)
        {
            try
            {
                switch(loginModel.userType)
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
                                if(loginModel.password.Equals(Constant.DEFAULT_PASSWORD))
                                {
                                    return Ok(new LoginResult 
                                    { 
                                        UserIsConnected = false,
                                        Message = $"{getDayPeriod()} {user.NAME}, vous devez obligatoirement changer votre mot de passe avant de continuer.",
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
                                        Message = $"{getDayPeriod()} {user.NAME}",
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
                                if(loginModel.password.Equals(Constant.DEFAULT_PASSWORD))
                                {
                                    return Ok(new LoginResult 
                                    { 
                                        UserIsConnected = false,
                                        Message = $"{getDayPeriod()} {student.NAME}, vous devez obligatoirement changer votre mot de passe avant de continuer.",
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
                                        Message = $"{getDayPeriod()} {student.NAME}",
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
                                if(loginModel.password.Equals(Constant.DEFAULT_PASSWORD))
                                {
                                    return Ok(new LoginResult 
                                    { 
                                        UserIsConnected = false,
                                        Message = $"{getDayPeriod()} {parent.NAME}, vous devez obligatoirement changer votre mot de passe avant de continuer.",
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
                                        Message = $"{getDayPeriod()} {parent.NAME}",
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

                    default:
                        return BadRequest(new LoginResult 
                        { 
                            UserIsConnected = false,
                            Message = "Le choix du type d'utilisateur est obligatoire.",
                            Error = null,
                            StatusCode = 401
                        });
                }
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

        // [HttpPost("emailValidationCode")]
        // public async Task<ActionResult> generateEmailValidationCode(string email)
        // {
        //     try
        //     {
        //         // var 
        //     }
        //     catch(Exception ex)
        //     {
        //         return BadRequest(new 
        //         { 
        //             message = "Une erreur coté serveur s'est produite.",
        //             error = ex,
        //             success = false,
        //             statusCode = 500
        //         });
        //     }
        // }


        private string getDayPeriod()
        {
            return DateTime.UtcNow.Hour < 12 ? "Bonjour" : "Bonsoir";
        }

    }
}