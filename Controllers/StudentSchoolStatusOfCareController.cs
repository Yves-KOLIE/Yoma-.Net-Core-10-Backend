using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YOMA.Models;

namespace YOMA.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentSchoolStatusOfCareController : ControllerBase
    {
        private readonly Context _context;
        private readonly string Message = "Liste du type de prise en charge des frais de scolarité";

        public StudentSchoolStatusOfCareController(Context context)
        {
            _context = context;
        }

        [HttpGet("GetStudentSchoolStatusOfCares")]
        public async Task<ActionResult<ApiResult>> GetStudentSchoolStatusOfCares()
        {
            try
            {
                var studentBusStatusOfCares = await _context.StudentSchoolStatusOfCares.ToListAsync();
                var apiResult = new ApiResult(Message, false, studentBusStatusOfCares);
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