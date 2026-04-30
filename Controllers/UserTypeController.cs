using Microsoft.AspNetCore.Mvc;
using YOMA.Models;
using YOMA.Models.Tables;

namespace YOMA.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserTypeController : ControllerBase
    {
        private readonly Context _context;
        private readonly UserTypeService _userTypeService;
        private readonly string Message = "Type d'utilisateur";

        public UserTypeController(Context context, UserTypeService userTypeService)
        {
            _context = context;
            _userTypeService = userTypeService;
        }

        [HttpGet("GetUserTypes")]
        public async Task<ActionResult<ApiResult>> GetUserTypes()
        {
            try
            {
                var userTypes = await _userTypeService.GetUserTypesAsync();
                var apiResult = new ApiResult(Message, false, userTypes);
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