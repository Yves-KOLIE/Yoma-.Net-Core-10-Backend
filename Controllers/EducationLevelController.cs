using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YOMA.Models;
using YOMA.Models.Tables;

namespace YOMA.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EducationLevelController : ControllerBase
    {
        private readonly Context _context;
        private readonly string Message = "Liste des niveau d'études";

        public EducationLevelController(Context context)
        {
            _context = context;
        }

        [HttpGet("GetSchoolEducationLevels")]
        public async Task<ActionResult<ApiResult>> GetSchoolEducationLevels()
        {
            try
            {
                var schoolEducationLevelList = await _context.EducationLevels
                    .AsNoTracking()
                    .Include(x => x.HIGH_SCHOOL_OPTION)
                    .OrderBy(x => x.ID)
                .ToListAsync();

                var apiResult = new ApiResult(Message, false, schoolEducationLevelList);
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