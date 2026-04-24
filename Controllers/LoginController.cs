using Microsoft.AspNetCore.Mvc;
using YOMA.Models;
using YOMA.Models.Tables;

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
        public async Task<ActionResult> Auth([FromBody] LoginModel loginModel)
        {
            try
            {
                // userIsConnected: boolean;
                // error?: any;
                // message: string;

                var tutu = 55;

                return Ok(new { 
                    userIsConnected = true,
                    error = "",
                    message = ""
                });
            }
            catch (Exception ex)
            {
                return Ok(new { 
                    userIsConnected = true,
                    error = ex,
                    message = ""
                });
            }
        }

    }
}