using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YOMA.Models;

namespace YOMA.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentBusStatusOfCareController : ControllerBase
    {
        private readonly Context _context;
        private readonly string Message = "Liste du type de prise en charge des bus";

        public StudentBusStatusOfCareController(Context context)
        {
            _context = context;
        }

        [HttpGet("GetStudentBusStatusOfCares")]
        public async Task<ActionResult<ApiResult>> GetStudentBusStatusOfCares()
        {
            try
            {
                var studentBusStatusOfCares = await _context.StudentBusStatusOfCares.ToListAsync();
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