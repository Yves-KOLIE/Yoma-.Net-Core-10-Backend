using Microsoft.AspNetCore.Mvc;
using YOMA.Helpers;
using YOMA.Models;
using YOMA.Models.Tables;

namespace YOMA.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParentController : ControllerBase
    {
        private readonly Context _context;
        private readonly ParentService _parentService;
        private readonly string Message = "Liste des Parents";

        public ParentController(Context context, ParentService parentService)
        {
            _context = context;
            _parentService = parentService;
        }

        [HttpPost("CreateParent")]
        public async Task<ActionResult<ApiResult>> CreateParent(Parent parent)
        {
            try
            {
                var newParentarent = await _parentService.addNewParent(parent);
                var apiResult = new ApiResult(Message, false, newParentarent);
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

        [HttpGet("SearchParentsByPhone")]
        public async Task<ActionResult<ApiResult>> SearchParentsByPhone([FromQuery] string telephone, [FromQuery] char sexe)
        {
            try
            {
                var parents = await _parentService.searchParentsByPhone(telephone, sexe);
                var apiResult = new ApiResult(Message, false, parents);
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