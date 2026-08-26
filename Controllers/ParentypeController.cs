using Microsoft.AspNetCore.Mvc;
using YOMA.Helpers;
using YOMA.Models;
using YOMA.Models.Tables;

namespace YOMA.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParentTypeController : ControllerBase
    {
        private readonly Context _context;
        private readonly ParentTypeService _parentTypeService;
        private readonly string Message = "Types de parents";

        public ParentTypeController(Context context, ParentTypeService parentTypeService)
        {
            _context = context;
            _parentTypeService = parentTypeService;
        }


        [HttpGet("GetParentTypes")]
        public async Task<ActionResult<ApiResult>> GetParentTypes()
        {
            try
            {
                var schoolYears = await _parentTypeService.GetParentTypesAsync();
                var apiResult = new ApiResult(Message, false, schoolYears);
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