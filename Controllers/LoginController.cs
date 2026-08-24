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
                                            userIsConnected = false,
                                            message = $"{GetDayPeriod()} {getSplitedUserName(user.SURNAME)}, vous devez obligatoirement changer votre mot de passe avant de continuer.",
                                            error = null,
                                            statusCode = 200,
                                            isChangePassword = true,
                                            user = user
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

                                        return Ok(new LoginResult 
                                        { 
                                            userIsConnected = isValidPassword,
                                            message = $"{GetDayPeriod()} {getSplitedUserName(user.SURNAME)} 🖐️",
                                            error = null,
                                            statusCode = 200,
                                            user = user,
                                            token = _jwtTokenService.CreateAccessToken(user.ID, user.USER_ROLE.DESCRIPTION)
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
                                            userIsConnected = false,
                                            message = $"{GetDayPeriod()} {getSplitedUserName(student.SURNAME)}, vous devez obligatoirement changer votre mot de passe avant de continuer.",
                                            error = null,
                                            statusCode = 200,
                                            isChangePassword = true,
                                            user = student
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

                                        return Ok(new LoginResult 
                                        { 
                                            userIsConnected = isValidPassword,
                                            message = $"{GetDayPeriod()} {getSplitedUserName(student.SURNAME)} 🖐️",
                                            error = null,
                                            statusCode = 200,
                                            user = student,
                                            token = _jwtTokenService.CreateAccessToken(student.ID, student.USER_ROLE.DESCRIPTION)
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
                                            userIsConnected = false,
                                            message = $"{GetDayPeriod()} {getSplitedUserName(parent.SURNAME)}, vous devez obligatoirement changer votre mot de passe avant de continuer.",
                                            error = null,
                                            statusCode = 200,
                                            isChangePassword = true,
                                            user = parent
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

                                        return Ok(new LoginResult 
                                        { 
                                            userIsConnected = isValidPassword,
                                            message = $"{GetDayPeriod()} {getSplitedUserName(parent.SURNAME)} 🖐️",
                                            error = null,
                                            statusCode = 200,
                                            user = parent,
                                            token = _jwtTokenService.CreateAccessToken(parent.ID, parent.USER_ROLE.DESCRIPTION)
                                        });
                                    }
                                }
                            }
                        break;
                    }
                }

                return BadRequest(new LoginResult 
                { 
                    userIsConnected = false,
                    message = "Adresse email et/ou mot de passe invalide.",
                    error = null,
                    statusCode = 400
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new LoginResult 
                { 
                    userIsConnected = false,
                    message = "Une erreur coté serveur s'est produite.",
                    error = ex,
                    statusCode = 500
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
                            .FirstOrDefaultAsync(x => x.USER_EMAIL_ID == userEmail.ID);

                            if(user != null)
                            {
                                var isValidForgotUserPassword = await EmailHelper.IsValidForgotUserPassword(email, _context);
                                if(isValidForgotUserPassword != null)
                                {
                                    return BadRequest(new EmailValidation 
                                    { 
                                        success = false,
                                        message = "Nous vous avons déjà envoyé un code encore valide.",
                                        error = null,
                                        statusCode = 400,
                                        connectedUser = user
                                    });
                                }
                                else
                                {
                                    var forgotUserPassword = await _forgotUserPasswordService.CreateForgotPasswordAsync(email);
                                    if(forgotUserPassword != null)
                                    {
                                        return Ok(new EmailValidation 
                                        { 
                                            success = true,
                                            message = $"Nous venons d'envoyer un code de validation à l'adresse email {email}.",
                                            error = null,
                                            statusCode = 200,
                                            connectedUser = user
                                        }); 
                                    }
                                }

                                return BadRequest(new EmailValidation 
                                { 
                                    success = false,
                                    message = "Une erreur serveur est survenue lors de la génération du code. Veuillez reessayer plutard.",
                                    error = null,
                                    statusCode = 400,
                                    connectedUser = null
                                });
                            }
                        break;

                        case 2: // Élèves
                            var student = await _context.Students
                                .Include(x => x.USER_EMAIL)
                            .FirstOrDefaultAsync(x => x.USER_EMAIL_ID == userEmail.ID);

                            if(student != null)
                            {
                                var isValidForgotUserPassword = await EmailHelper.IsValidForgotUserPassword(email, _context);
                                if(isValidForgotUserPassword != null)
                                {
                                    return BadRequest(new EmailValidation 
                                    { 
                                        success = false,
                                        message = "Nous vous avons déjà envoyé un code encore valide.",
                                        error = null,
                                        statusCode = 400,
                                        connectedUser = student
                                    });
                                }
                                else
                                {
                                    var forgotUserPassword = await _forgotUserPasswordService.CreateForgotPasswordAsync(email);
                                    if(forgotUserPassword != null)
                                    {
                                        return Ok(new EmailValidation 
                                        { 
                                            success = true,
                                            message = $"Nous venons d'envoyer un code de validation à l'adresse email {email}.",
                                            error = null,
                                            statusCode = 200,
                                            connectedUser = student
                                        }); 
                                    }
                                }

                                return BadRequest(new EmailValidation 
                                { 
                                    success = false,
                                    message = "Une erreur serveur est survenue lors de la génération du code. Veuillez reessayer plutard.",
                                    error = null,
                                    statusCode = 400,
                                    connectedUser = null
                                });
                            }
                        break;

                        case 3: // Parent d'élèves
                            var parent = await _context.Parents
                                .Include(x => x.USER_EMAIL)
                            .FirstOrDefaultAsync(x => x.USER_EMAIL_ID == userEmail.ID);

                            if(parent != null)
                            {
                                var isValidForgotUserPassword = await EmailHelper.IsValidForgotUserPassword(email, _context);
                                if(isValidForgotUserPassword != null)
                                {
                                    return BadRequest(new EmailValidation 
                                    { 
                                        success = false,
                                        message = "Nous vous avons déjà envoyé un code encore valide.",
                                        error = null,
                                        statusCode = 400,
                                        connectedUser = parent
                                    });
                                }
                                else
                                {
                                    var forgotUserPassword = await _forgotUserPasswordService.CreateForgotPasswordAsync(email);
                                    if(forgotUserPassword != null)
                                    {
                                        return Ok(new EmailValidation 
                                        { 
                                            success = true,
                                            message = $"Nous venons d'envoyer un code de validation à l'adresse email {email}.",
                                            error = null,
                                            statusCode = 200,
                                            connectedUser = parent
                                        }); 
                                    }
                                }

                                return BadRequest(new EmailValidation 
                                { 
                                    success = false,
                                    message = "Une erreur serveur est survenue lors de la génération du code. Veuillez reessayer plutard.",
                                    error = null,
                                    statusCode = 400,
                                    connectedUser = null
                                });
                            }
                        break;
                    }
                }

                return BadRequest(new EmailValidation 
                { 
                    success = false,
                    message = "Cette adresse email n'existe pas dans notre base de données.",
                    error = null,
                    statusCode = 400,
                    connectedUser = null
                });
            }
            catch(Exception ex)
            {
                return BadRequest(new EmailValidation
                { 
                    success = false,
                    message = "Cette adresse email n'existe pas dans notre base de données.",
                    error = ex,
                    statusCode = 400,
                    connectedUser = null
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
                            .FirstOrDefaultAsync(x => x.USER_EMAIL_ID == userEmail.ID);

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
                                            success = true,
                                            message = "Code validé avec succès.",
                                            error = null,
                                            statusCode = 400,
                                            connectedUser = user
                                        });
                                    }
                                }

                                return BadRequest(new EmailValidation 
                                { 
                                    success = false,
                                    message = "Le code que vous avez saisi a expiré ou est invalide.",
                                    error = null,
                                    statusCode = 400,
                                    connectedUser = user
                                });
                            }
                        break;

                        case 2: // Élèves
                            var student = await _context.Students
                                .Include(x => x.USER_EMAIL)
                            .FirstOrDefaultAsync(x => x.USER_EMAIL_ID == userEmail.ID);

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
                                            success = true,
                                            message = "Code validé avec succès.",
                                            error = null,
                                            statusCode = 400,
                                            connectedUser = student
                                        });
                                    }
                                }

                                return BadRequest(new EmailValidation 
                                { 
                                    success = false,
                                    message = "Le code que vous avez saisi a expiré ou est invalide.",
                                    error = null,
                                    statusCode = 400,
                                    connectedUser = student
                                });
                            }
                        break;

                        case 3: // Parent d'élèves
                            var parent = await _context.Parents
                                .Include(x => x.USER_EMAIL)
                            .FirstOrDefaultAsync(x => x.USER_EMAIL_ID == userEmail.ID);

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
                                            success = true,
                                            message = "Code validé avec succès.",
                                            error = null,
                                            statusCode = 400,
                                            connectedUser = parent
                                        });
                                    }
                                }

                                return BadRequest(new EmailValidation 
                                { 
                                    success = false,
                                    message = "Le code que vous avez saisi a expiré ou est invalide.",
                                    error = null,
                                    statusCode = 400,
                                    connectedUser = parent
                                });
                            }
                        break;
                    }
                }

                return BadRequest(new EmailValidation 
                { 
                    success = false,
                    message = "Cette adresse email n'existe pas dans notre base de données.",
                    error = null,
                    statusCode = 400,
                    connectedUser = null
                });
            }
            catch(Exception ex)
            {
                return BadRequest(new EmailValidation
                { 
                    success = false,
                    message = "Cette adresse email n'existe pas dans notre base de données.",
                    error = ex,
                    statusCode = 400,
                    connectedUser = null
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
                        isChangePassword = false,
                        message = "Le nouveau mot de passe doit-être différent du mot de passe par defaut.",
                        error = null,
                        statusCode = 400
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
                                                userIsConnected = false,
                                                message = "Mot de passe modifié avec succès.",
                                                error = null,
                                                statusCode = 200,
                                                isChangePassword = true,
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
                                                userIsConnected = false,
                                                message = "Mot de passe modifié avec succès.",
                                                error = null,
                                                statusCode = 200,
                                                isChangePassword = true,
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
                                                userIsConnected = false,
                                                message = "Mot de passe modifié avec succès.",
                                                error = null,
                                                statusCode = 200,
                                                isChangePassword = true,
                                            }); 
                                        }
                                    break;
                                }

                                return BadRequest(new LoginResult 
                                { 
                                    isChangePassword = false,
                                    message = "Impossible de modifié le mot de passe. Veillez reessayer plutard.",
                                    error = null,
                                    statusCode = 400
                                });
                            }
                            else
                            {
                                return BadRequest(new LoginResult 
                                { 
                                    isChangePassword = false,
                                    message = "Le code que vous avez saisi a expiré ou est invalide.",
                                    error = null,
                                    statusCode = 400
                                });
                            }
                        }
                        else
                        {
                            return BadRequest(new LoginResult 
                            { 
                                isChangePassword = false,
                                message = "Cette adresse email est introuvable dans notre base de données.",
                                error = null,
                                statusCode = 400
                            });
                        }
                    }
                    else
                    {
                        return BadRequest(new LoginResult 
                        { 
                            isChangePassword = false,
                            message = "Les deux adresses email sont différentes.",
                            error = null,
                            statusCode = 400
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new LoginResult 
                { 
                    isChangePassword = false,
                    message = "Une erreur coté serveur s'est produite.",
                    error = ex,
                    statusCode = 500
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