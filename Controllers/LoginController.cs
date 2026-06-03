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
        private readonly JwtTokenService _jwtTokenService;

        public LoginController(Context context, ForgotUserPasswordService forgotUserPasswordService, JwtTokenService jwtTokenService)
        {
            _context = context;
            _forgotUserPasswordService = forgotUserPasswordService;
            _jwtTokenService = jwtTokenService;
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
                                .Include(x => x.USER_EMAIL)
                            .FirstOrDefaultAsync(x => x.USER_EMAIL_ID == userEmail.ID);

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
                                            Message = $"{GetDayPeriod()} {getSplitedUserName(user.SURNAME)}, vous devez obligatoirement changer votre mot de passe avant de continuer.",
                                            Error = null,
                                            StatusCode = 200,
                                            IsChangePassword = true,
                                            ConnectedUser = user
                                        }); 
                                    }
                                    else
                                    {
                                        var professionalQualification = await _context.ProfessionalQualifications.FirstOrDefaultAsync(x => x.ID == user.PROFESSIONAL_QUALIFICATION_ID);
                                        if(professionalQualification != null)
                                        {
                                            user.PROFESSIONAL_QUALIFICATION_ID = professionalQualification.ID;
                                            user.PROFESSIONAL_QUALIFICATION = professionalQualification;
                                        }

                                        var userRole = await _context.UserRoles.FirstOrDefaultAsync(x => x.ID == user.USER_ROLE_ID);
                                        if(userRole != null)
                                        {
                                            user.USER_ROLE_ID = userRole.ID;
                                            user.USER_ROLE = userRole;
                                        }

                                        user.TOKEN = _jwtTokenService.CreateAccessToken(user.ID, user.USER_ROLE.DESCRIPTION);

                                        return Ok(new LoginResult 
                                        { 
                                            UserIsConnected = isValidPassword,
                                            Message = $"{GetDayPeriod()} {getSplitedUserName(user.SURNAME)} 🖐️",
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
                                .Include(x => x.USER_EMAIL)
                            .FirstOrDefaultAsync(x => x.USER_EMAIL_ID == userEmail.ID);

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
                                            Message = $"{GetDayPeriod()} {getSplitedUserName(student.SURNAME)}, vous devez obligatoirement changer votre mot de passe avant de continuer.",
                                            Error = null,
                                            StatusCode = 200,
                                            IsChangePassword = true,
                                            ConnectedUser = student
                                        }); 
                                    }
                                    else
                                    {
                                        var userRole = await _context.UserRoles.FirstOrDefaultAsync(x => x.ID == student.USER_ROLE_ID);
                                        if(userRole != null)
                                        {
                                            student.USER_ROLE_ID = userRole.ID;
                                            student.USER_ROLE = userRole;
                                        }

                                        student.TOKEN = _jwtTokenService.CreateAccessToken(student.ID, student.USER_ROLE.DESCRIPTION);

                                        return Ok(new LoginResult 
                                        { 
                                            UserIsConnected = isValidPassword,
                                            Message = $"{GetDayPeriod()} {getSplitedUserName(student.SURNAME)} 🖐️",
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
                                .Include(x => x.USER_EMAIL)
                            .FirstOrDefaultAsync(x => x.USER_EMAIL_ID == userEmail.ID);

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
                                            Message = $"{GetDayPeriod()} {getSplitedUserName(parent.SURNAME)}, vous devez obligatoirement changer votre mot de passe avant de continuer.",
                                            Error = null,
                                            StatusCode = 200,
                                            IsChangePassword = true,
                                            ConnectedUser = parent
                                        }); 
                                    }
                                    else
                                    {
                                        var professionalQualification = await _context.ProfessionalQualifications.FirstOrDefaultAsync(x => x.ID == parent.PROFESSIONAL_QUALIFICATION_ID);
                                        if(professionalQualification != null)
                                        {
                                            parent.PROFESSIONAL_QUALIFICATION_ID = professionalQualification.ID;
                                            parent.PROFESSIONAL_QUALIFICATION = professionalQualification;
                                        }

                                        var userRole = await _context.UserRoles.FirstOrDefaultAsync(x => x.ID == parent.USER_ROLE_ID);
                                        if(userRole != null)
                                        {
                                            parent.USER_ROLE_ID = userRole.ID;
                                            parent.USER_ROLE = userRole;
                                        }

                                        parent.TOKEN = _jwtTokenService.CreateAccessToken(parent.ID, parent.USER_ROLE.DESCRIPTION);

                                        return Ok(new LoginResult 
                                        { 
                                            UserIsConnected = isValidPassword,
                                            Message = $"{GetDayPeriod()} {getSplitedUserName(parent.SURNAME)} 🖐️",
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
                    Message = "Adresse email et/ou mot de passe invalide.",
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
        public async Task<ActionResult> GenerateEmailValidationCode(string email)
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
        public async Task<ActionResult> ValidateEmailCode(string email, string generedCode)
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

        [HttpPost("ChangePassword")]
        public async Task<ActionResult<LoginResult>> ChangePassword([FromBody] LoginModel loginModel)
        {
            try
            {
                if(loginModel.password == ConstantHelper.DEFAULT_PASSWORD)
                {
                    return BadRequest(new LoginResult 
                    { 
                        IsChangePassword = false,
                        Message = "Le nouveau mot de passe doit-être différent du mot de passe par defaut.",
                        Error = null,
                        StatusCode = 400
                    });
                }
                else
                {
                    if(loginModel.password == loginModel.confirmPassword)
                    {
                        var userEmail = await _context.UserEmails.FirstOrDefaultAsync(x => x.EMAIL == loginModel.email);
                        if(userEmail != null)
                        {
                            var forgotUserPassword = await EmailHelper.IsValidForgotUserPassword(loginModel.email, _context);
                            if(forgotUserPassword != null)
                            {
                                switch(userEmail.USER_TYPE_ID)
                                {
                                    case 1: // Professeur
                                        int updateUser = await _context.Users
                                            .Where(x => x.USER_EMAIL_ID == userEmail.ID)
                                        .ExecuteUpdateAsync(u => u.SetProperty(x => x.PASSWORD, PasswordHelper.HashPassword(loginModel.password)));

                                        if(updateUser > 0)
                                        {
                                            return Ok(new LoginResult 
                                            { 
                                                UserIsConnected = false,
                                                Message = "Mot de passe modifié avec succès.",
                                                Error = null,
                                                StatusCode = 200,
                                                IsChangePassword = true,
                                            }); 
                                        }
                                    break;

                                    case 2: // Élèves
                                        int updateStudent = await _context.Students
                                            .Where(x => x.USER_EMAIL_ID == userEmail.ID)
                                        .ExecuteUpdateAsync(u => u.SetProperty(x => x.PASSWORD, PasswordHelper.HashPassword(loginModel.password)));

                                        if(updateStudent > 0)
                                        {
                                            return Ok(new LoginResult 
                                            { 
                                                UserIsConnected = false,
                                                Message = "Mot de passe modifié avec succès.",
                                                Error = null,
                                                StatusCode = 200,
                                                IsChangePassword = true,
                                            }); 
                                        }
                                    break;

                                    case 3: // Parent d'élèves
                                        int updateParent = await _context.Parents
                                            .Where(x => x.USER_EMAIL_ID == userEmail.ID)
                                        .ExecuteUpdateAsync(u => u.SetProperty(x => x.PASSWORD, PasswordHelper.HashPassword(loginModel.password)));

                                        if(updateParent > 0)
                                        {
                                            return Ok(new LoginResult 
                                            { 
                                                UserIsConnected = false,
                                                Message = "Mot de passe modifié avec succès.",
                                                Error = null,
                                                StatusCode = 200,
                                                IsChangePassword = true,
                                            }); 
                                        }
                                    break;
                                }

                                return BadRequest(new LoginResult 
                                { 
                                    IsChangePassword = false,
                                    Message = "Impossible de modifié le mot de passe. Veillez reessayer plutard.",
                                    Error = null,
                                    StatusCode = 400
                                });
                            }
                            else
                            {
                                return BadRequest(new LoginResult 
                                { 
                                    IsChangePassword = false,
                                    Message = "Le code que vous avez saisi a expiré ou est invalide.",
                                    Error = null,
                                    StatusCode = 400
                                });
                            }
                        }
                        else
                        {
                            return BadRequest(new LoginResult 
                            { 
                                IsChangePassword = false,
                                Message = "Cette adresse email est introuvable dans notre base de données.",
                                Error = null,
                                StatusCode = 400
                            });
                        }
                    }
                    else
                    {
                        return BadRequest(new LoginResult 
                        { 
                            IsChangePassword = false,
                            Message = "Les deux adresses email sont différentes.",
                            Error = null,
                            StatusCode = 400
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new LoginResult 
                { 
                    IsChangePassword = false,
                    Message = "Une erreur coté serveur s'est produite.",
                    Error = ex,
                    StatusCode = 500
                });
            }
        }

        private string GetDayPeriod()
        {
            return DateTime.UtcNow.Hour < 12 ? "Bonjour" : "Bonsoir";
        }

        private string getSplitedUserName(string name)
        {
            if(name.Contains(" "))
            {
                return name.Split(" ")[0].Trim();
            }
            return name;
        }
    }


}