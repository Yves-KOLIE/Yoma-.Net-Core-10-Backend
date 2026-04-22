using Microsoft.AspNetCore.Mvc;
using YOMA.Models;
using YOMA.Models.Tables;

namespace YOMA.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoursController : ControllerBase
    {
        private readonly Context _context;
        private readonly CoursService _coursService;
        private readonly string Message = "Liste des matières";

        public CoursController(Context context, CoursService coursService)
        {
            _context = context;
            _coursService = coursService;
        }

        [HttpPost("CreateCours")]
        public async Task<ActionResult<ApiResult>> CreateCours([FromBody] Cours cours)
        {
            try
            {
                var createCours = await _coursService.CreateCoursAsync(cours);
                var apiResult = new ApiResult(Message, false, createCours);
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