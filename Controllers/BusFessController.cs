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
            try
            {
                var busFess = await _busFessService.GetBusFessAsync(id);
                var apiResult = new ApiResult(Message, false, busFess);
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

        [HttpGet("GetBusFesses")]
        public async Task<ActionResult<ApiResult>> GetBusFesses()
        {
            try
            {
                var busFesses = await _busFessService.GetBusFessesAsync();
                var apiResult = new ApiResult(Message, false, busFesses);
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

        [HttpPut("UpdateBusFess")]
        public async Task<ActionResult<ApiResult>> UpdateBusFess([FromBody] BusFess busFess)
        {
            try
            {
                var updatedBusFess = await _busFessService.UpdateBusFessAsync(busFess);
                var apiResult = new ApiResult(Message, false, updatedBusFess);
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