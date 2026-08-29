using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YOMA.Models;
using YOMA.Models.Tables;

namespace YOMA.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentRegistrationController : ControllerBase
    {
        private readonly Context _context;
        private readonly StudentRegistrationService _studentRegistrationService;
        private readonly string Message = "Inscription des élèves";

        public StudentRegistrationController(Context context, StudentRegistrationService studentRegistrationService)
        {
            _context = context;
            _studentRegistrationService = studentRegistrationService;
        }

        [HttpPost("registerStudent")]
        public async Task<ActionResult<ApiResult>> registerStudent([FromBody] StudentRegistration studentRegistration)
        {
            try
            {
                var saveResult = await _studentRegistrationService.registerStudentAsync(studentRegistration);
                if(saveResult.success)
                {
                    var apiResult = new ApiResult(Message, false, studentRegistration);
                    return Ok(new { 
                        Message = "Inscription effectuée avec succès",
                        IsError = false,
                        Data = apiResult.Data 
                    });
                }

                throw new InvalidOperationException("Condition non remplie : passage forcé dans le catch.");
            }
            catch (Exception ex)
            {
                var apiResult = new ApiResult(Message, true, null);
                return BadRequest(new { 
                    Message = apiResult.Message,
                    IsError = apiResult.IsError,
                    Data = apiResult.Data,
                    ErrorDetails = ex.Message
                });
            }
        }
    }
}