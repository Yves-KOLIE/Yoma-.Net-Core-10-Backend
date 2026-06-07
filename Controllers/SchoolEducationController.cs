using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YOMA.Models;
using YOMA.Models.Tables;

namespace YOMA.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SchoolEducationController : ControllerBase
    {
        private readonly Context _context;
        private readonly string Message = "Liste des enseignements scolaire";

        public SchoolEducationController(Context context)
        {
            _context = context;
        }

        [HttpGet("GetSchoolEducations")]
        public async Task<ActionResult<ApiResult>> GetSchoolEducations()
        {
            try
            {
                var schoolEducationList = await _context.SchoolEducations.AsNoTracking().ToListAsync();
                var apiResult = new ApiResult(Message, false, schoolEducationList);
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