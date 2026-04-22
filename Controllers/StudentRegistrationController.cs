using Microsoft.AspNetCore.Mvc;
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

        [HttpPost("CreateStudentRegistration")]
        public async Task<ActionResult<ApiResult>> CreateStudentRegistration([FromBody] StudentRegistration studentRegistration)
        {
            try
            {
                var createdGasStation = await _studentRegistrationService.CreateStudentRegistrationAsync(studentRegistration);
                var apiResult = new ApiResult(Message, false, createdGasStation);
                return Ok(new { 
                    Message = apiResult.Message,
                    IsError = apiResult.IsError,
                    Data = apiResult.Data 
                });
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