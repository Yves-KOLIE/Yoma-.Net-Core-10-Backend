using Microsoft.AspNetCore.Mvc;
using YOMA.Models;
using YOMA.Models.Tables;

namespace YOMA.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubdivisionController : ControllerBase
    {
        private readonly Context _context;
        private readonly ISubdivision _subdivisionService;
        private readonly string Message = "Subdivisions";

        public SubdivisionController(Context context, ISubdivision subdivisionService)
        {
            _context = context;
            _subdivisionService = subdivisionService;
        }

        [HttpGet("GetSubdivisions")]
        public async Task<ActionResult<ApiResult>> GetSubdivisions()
        {
            var subdivisions = await _subdivisionService.GetBanksAsync();
            var customMessage = new ApiResult(Message, false, subdivisions);
            return Ok(new { 
                Message = customMessage.Message,
                IsError = customMessage.IsError,
                Data = customMessage.Data 
            });
        }
    }
}