using Microsoft.AspNetCore.Mvc;
using YOMA.Models;
using YOMA.Models.Tables;

namespace YOMA.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BusFessController : ControllerBase
    {
        private readonly Context _context;
        private readonly BusFessService _busFessService;
        private readonly string Message = "Frais de bus";

        public BusFessController(Context context, BusFessService busFessService)
        {
            _context = context;
            _busFessService = busFessService;
        }

        [HttpGet("GetBusFess/{id}")]
        public async Task<ActionResult<ApiResult>> GetBusFess(int id)
        {
            var busFess = await _busFessService.GetBusFessAsync(id);
            var customMessage = new ApiResult(Message, false, busFess);
            return Ok(new { 
                Message = customMessage.Message,
                IsError = customMessage.IsError,
                Data = customMessage.Data 
            });
        }

        [HttpGet("GetBusFesses")]
        public async Task<ActionResult<ApiResult>> GetBusFesses()
        {
            var busFesses = await _busFessService.GetBusFessesAsync();
            var customMessage = new ApiResult(Message, false, busFesses);
            return Ok(new { 
                Message = customMessage.Message,
                IsError = customMessage.IsError,
                Data = customMessage.Data 
            });
        }

        [HttpPut("UpdateBusFess")]
        public async Task<ActionResult<ApiResult>> UpdateBusFess([FromBody] BusFess busFess)
        {
            try
            {
                var updatedBusFess = await _busFessService.UpdateBusFessAsync(busFess);
                var customMessage = new ApiResult(Message, false, updatedBusFess);
                return Ok(new { 
                    Message = customMessage.Message,
                    IsError = customMessage.IsError,
                    Data = customMessage.Data 
                });
            }
            catch (Exception ex)
            {
                var customMessage = new ApiResult(Message, true, null);
                return BadRequest(new { 
                    Message = customMessage.Message,
                    IsError = customMessage.IsError,
                    Data = customMessage.Data,
                    ErrorDetails = ex.Message
                });
            }
        }
    }
}