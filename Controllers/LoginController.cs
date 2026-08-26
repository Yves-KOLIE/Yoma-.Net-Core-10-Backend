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
        private readonly LoginService _loginService;
        private readonly ForgotUserPasswordService _forgotUserPasswordService;
        private readonly JwtTokenService _jwtTokenService;

        public LoginController(Context context, LoginService loginService, ForgotUserPasswordService forgotUserPasswordService, JwtTokenService jwtTokenService)
        {
            _context = context;
            _loginService = loginService;
            _forgotUserPasswordService = forgotUserPasswordService;
            _jwtTokenService = jwtTokenService;
        }

        [HttpPost("auth")]
        public async Task<ActionResult<LoginResult>> Auth([FromBody] LoginCredentials loginCredentials)
        {
            try
            {
                var userEmail = await _context.UserEmails.FirstOrDefaultAsync(x => x.EMAIL == loginCredentials.email);
                if(userEmail != null)
                {
                    switch(userEmail.USER_TYPE_ID)
                    {
                        case 1: // Encadreur
                            var user = await _context.Users
                                .Include(x => x.PROFESSIONAL_QUALIFICATION)
                                .Include(x => x.USER_ROLE)
                                .Include(x => x.USER_EMAIL)
                            .FirstOrDefaultAsync(x => x.USER_EMAIL_ID == userEmail.ID);

                            if(user != null)
                            {
                                bool isValidPassword = PasswordHelper.IsValidPassword(loginCredentials.password, user.PASSWORD);
                                if(isValidPassword)
                                {
                                    if(loginCredentials.password.Equals(ConstantHelper.DEFAULT_PASSWORD))
                                    {
                                        return Ok(new LoginResult 
                                        { 
                                            userIsConnected = false,
                                            message = $"{_loginService.GetDayPeriod()} {_loginService.getSplitedUserName(user.SURNAME)}, vous devez obligatoirement changer votre mot de passe avant de continuer.",
                                            error = null,
                                            statusCode = 200,
                                            isChangePassword = true,
                                            user = user
                                        }); 
                                    }
                                    else
                                    {
                                        return Ok(new LoginResult 
                                        { 
                                            userIsConnected = isValidPassword,
                                            message = $"{_loginService.GetDayPeriod()} {_loginService.getSplitedUserName(user.SURNAME)} 🖐️",
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
                                .Include(x => x.USER_ROLE)
                                .Include(x => x.PARENT_1)
                                .Include(x => x.PARENT_2)
                                .Include(x => x.USER_EMAIL)
                            .FirstOrDefaultAsync(x => x.USER_EMAIL_ID == userEmail.ID);

                            if(student != null)
                            {
                                bool isValidPassword = PasswordHelper.IsValidPassword(loginCredentials.password, student.PASSWORD);
                                if(isValidPassword)
                                {
                                    if(loginCredentials.password.Equals(ConstantHelper.DEFAULT_PASSWORD))
                                    {
                                        return Ok(new LoginResult 
                                        { 
                                            userIsConnected = false,
                                            message = $"{_loginService.GetDayPeriod()} {_loginService.getSplitedUserName(student.SURNAME)}, vous devez obligatoirement changer votre mot de passe avant de continuer.",
                                            error = null,
                                            statusCode = 200,
                                            isChangePassword = true,
                                            user = student
                                        }); 
                                    }
                                    else
                                    {
                                        return Ok(new LoginResult 
                                        { 
                                            userIsConnected = isValidPassword,
                                            message = $"{_loginService.GetDayPeriod()} {_loginService.getSplitedUserName(student.SURNAME)} 🖐️",
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
                                .Include(x => x.PROFESSIONAL_QUALIFICATION)
                                .Include(x => x.USER_ROLE)
                                .Include(x => x.USER_EMAIL)
                            .FirstOrDefaultAsync(x => x.USER_EMAIL_ID == userEmail.ID);

                            if(parent != null)
                            {
                                bool isValidPassword = PasswordHelper.IsValidPassword(loginCredentials.password, parent.PASSWORD);
                                if(isValidPassword)
                                {
                                    if(loginCredentials.password.Equals(ConstantHelper.DEFAULT_PASSWORD))
                                    {
                                        return Ok(new LoginResult 
                                        { 
                                            userIsConnected = false,
                                            message = $"{_loginService.GetDayPeriod()} {_loginService.getSplitedUserName(parent.SURNAME)}, vous devez obligatoirement changer votre mot de passe avant de continuer.",
                                            error = null,
                                            statusCode = 200,
                                            isChangePassword = true,
                                            user = parent
                                        }); 
                                    }
                                    else
                                    {
                                        return Ok(new LoginResult 
                                        { 
                                            userIsConnected = isValidPassword,
                                            message = $"{_loginService.GetDayPeriod()} {_loginService.getSplitedUserName(parent.SURNAME)} 🖐️",
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

        [HttpPost("generateEmailValidationCode")]
        public async Task<ActionResult> GenerateEmailValidationCode([FromBody] ForgotPasswordCredentials forgotPasswordCredentials)
        {
            try
            {
                var userEmail = await _context.UserEmails.FirstOrDefaultAsync(x => x.EMAIL == forgotPasswordCredentials.email && forgotPasswordCredentials.email != null);
                if(userEmail != null)
                {
                    switch(userEmail.USER_TYPE_ID)
                    {
                        case 1: // Encadreur
                            var user = await _context.Users
                                .Include(x => x.USER_EMAIL)
                            .FirstOrDefaultAsync(x => x.USER_EMAIL_ID == userEmail.ID);

                            if(user != null)
                            {
                                var isValidForgotUserPassword = await EmailHelper.IsValidForgotUserPassword(forgotPasswordCredentials.email!, _context);
                                if(isValidForgotUserPassword != null)
                                {
                                    return BadRequest(_loginService.CodeAlreadySent());
                                }
                                else
                                {
                                    var forgotUserPassword = await _forgotUserPasswordService.CreateForgotPasswordAsync(forgotPasswordCredentials.email!);
                                    if(forgotUserPassword != null)
                                    {
                                        return Ok(_loginService.CodeIsGenerated(forgotPasswordCredentials.email!)); 
                                    }
                                }

                                return BadRequest(_loginService.EmptyCodeGenerated());
                            }
                        break;

                        case 2: // Élèves
                            var student = await _context.Students
                                .Include(x => x.USER_EMAIL)
                            .FirstOrDefaultAsync(x => x.USER_EMAIL_ID == userEmail.ID);

                            if(student != null)
                            {
                                var isValidForgotUserPassword = await EmailHelper.IsValidForgotUserPassword(forgotPasswordCredentials.email!, _context);
                                if(isValidForgotUserPassword != null)
                                {
                                    return BadRequest(_loginService.CodeAlreadySent());
                                }
                                else
                                {
                                    var forgotUserPassword = await _forgotUserPasswordService.CreateForgotPasswordAsync(forgotPasswordCredentials.email!);
                                    if(forgotUserPassword != null)
                                    {
                                        return Ok(_loginService.CodeIsGenerated(forgotPasswordCredentials.email!)); 
                                    }
                                }

                                return BadRequest(_loginService.EmptyCodeGenerated());
                            }
                        break;

                        case 3: // Parent d'élèves
                            var parent = await _context.Parents
                                .Include(x => x.USER_EMAIL)
                            .FirstOrDefaultAsync(x => x.USER_EMAIL_ID == userEmail.ID);

                            if(parent != null)
                            {
                                var isValidForgotUserPassword = await EmailHelper.IsValidForgotUserPassword(forgotPasswordCredentials.email!, _context);
                                if(isValidForgotUserPassword != null)
                                {
                                    return BadRequest(_loginService.CodeAlreadySent());
                                }
                                else
                                {
                                    var forgotUserPassword = await _forgotUserPasswordService.CreateForgotPasswordAsync(forgotPasswordCredentials.email!);
                                    if(forgotUserPassword != null)
                                    {
                                        return Ok(_loginService.CodeIsGenerated(forgotPasswordCredentials.email!)); 
                                    }
                                }

                                return BadRequest(_loginService.EmptyCodeGenerated());
                            }
                        break;
                    }
                }

                return BadRequest(new EmailValidation 
                { 
                    message = "Cette adresse email n'existe pas dans notre base de données.",
                });
            }
            catch(Exception ex)
            {
                return BadRequest(new EmailValidation
                { 
                    message = "Cette adresse email n'existe pas dans notre base de données.",
                    error = ex,
                });
            }
        }

        [HttpPost("validateEmailCode")]
        public async Task<ActionResult> ValidateEmailCode([FromBody] ForgotPasswordCredentials forgotPasswordCredentials)
        {
            try
            {
                var userEmail = await _context.UserEmails.FirstOrDefaultAsync(x => x.EMAIL == forgotPasswordCredentials.email && forgotPasswordCredentials.email != null);
                if(userEmail != null)
                {
                    switch(userEmail.USER_TYPE_ID)
                    {
                        case 1: // Encadreur
                            var user = await _context.Users
                                .Include(x => x.USER_EMAIL)
                            .FirstOrDefaultAsync(x => x.USER_EMAIL_ID == userEmail.ID);

                            if(user != null)
                            {
                                return await VerifyCode(forgotPasswordCredentials);
                            }
                        break;

                        case 2: // Élèves
                            var student = await _context.Students
                                .Include(x => x.USER_EMAIL)
                            .FirstOrDefaultAsync(x => x.USER_EMAIL_ID == userEmail.ID);

                            if(student != null)
                            {
                                return await VerifyCode(forgotPasswordCredentials);
                            }
                        break;

                        case 3: // Parent d'élèves
                            var parent = await _context.Parents
                                .Include(x => x.USER_EMAIL)
                            .FirstOrDefaultAsync(x => x.USER_EMAIL_ID == userEmail.ID);

                            if(parent != null)
                            {
                                return await VerifyCode(forgotPasswordCredentials);
                            }
                        break;
                    }
                }

                return BadRequest(new EmailValidation 
                { 
                    message = "Cette adresse email n'existe pas dans notre base de données.",
                });
            }
            catch(Exception ex)
            {
                return BadRequest(new EmailValidation
                { 
                    message = "Cette adresse email n'existe pas dans notre base de données.",
                    error = ex,
                });
            }
        }

        [HttpPost("resetPassword")]
        public async Task<ActionResult<LoginResult>> ChangePassword([FromBody] ResetPasswordCredentials resetPasswordCredentials)
        {
            try
            {
                if(resetPasswordCredentials.newPassword == ConstantHelper.DEFAULT_PASSWORD)
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
                    if(resetPasswordCredentials.newPassword == resetPasswordCredentials.confirmPassword)
                    {
                        var userEmail = await _context.UserEmails.FirstOrDefaultAsync(x => x.EMAIL == resetPasswordCredentials.email);
                        if(userEmail != null)
                        {
                            var forgotUserPassword = await EmailHelper.IsValidForgotUserPassword(resetPasswordCredentials.email, _context);
                            if(forgotUserPassword != null)
                            {
                                switch(userEmail.USER_TYPE_ID)
                                {
                                    case 1: // Encadreur
                                        int updateUser = await _context.Users
                                            .Where(x => x.USER_EMAIL_ID == userEmail.ID)
                                        .ExecuteUpdateAsync(u => u.SetProperty(x => x.PASSWORD, PasswordHelper.HashPassword(resetPasswordCredentials.newPassword)));

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
                                        .ExecuteUpdateAsync(u => u.SetProperty(x => x.PASSWORD, PasswordHelper.HashPassword(resetPasswordCredentials.newPassword)));

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
                                        .ExecuteUpdateAsync(u => u.SetProperty(x => x.PASSWORD, PasswordHelper.HashPassword(resetPasswordCredentials.newPassword)));

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
                                    message = "Le code précédemment saisi a expiré ou est invalide.",
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
                            message = "Les mots de passe sont différentes.",
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

        private async Task<ActionResult> VerifyCode(ForgotPasswordCredentials forgotPasswordCredentials)
        {
            var forgotUserPassword = await EmailHelper.IsValidForgotUserPassword(forgotPasswordCredentials.email!, _context);
            if(forgotUserPassword != null)
            {
                bool isValidCode = PasswordHelper.IsValidCode(forgotPasswordCredentials.code!, forgotUserPassword.CODE_GENERETED);
                if(isValidCode)
                {
                    // Désactiver le code validé
                    await _context.ForgotUserPasswords
                        .Where(x => x.ID == forgotUserPassword.ID)
                    .ExecuteUpdateAsync(u => u.SetProperty(x => x.IS_VALIDED, true));

                    return Ok(new EmailValidation 
                    { 
                        codeIsValided = true,
                        message = "Code validé avec succès.",
                    });
                }
            }

            return BadRequest(new EmailValidation 
            { 
                message = "Le code que vous avez saisi a expiré ou est invalide.",
            });
        }
    }
}