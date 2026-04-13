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
        private readonly IBusFessService _busFessService;
        private readonly string Message = "Frais de bus";

        public BusFessController(Context context, IBusFessService busFessService)
        {
            _context = context;
            _busFessService = busFessService;
        }

        [HttpGet("GetBusFess/{id}")]
        public async Task<ActionResult<CustomMessage>> GetBusFess(int id)
        {
            var busFess = await _busFessService.GetBusFessAsync(id);
            var customMessage = new CustomMessage(Message, false, busFess);
            return Ok(new { 
                Message = customMessage.Message,
                IsError = customMessage.Error,
                Data = customMessage.Data 
            });
        }

        [HttpGet("GetBusFesses")]
        public async Task<ActionResult<CustomMessage>> GetBusFesses()
        {
            var busFesses = await _busFessService.GetBusFessesAsync();
            var customMessage = new CustomMessage(Message, false, busFesses);
            return Ok(new { 
                Message = customMessage.Message,
                IsError = customMessage.Error,
                Data = customMessage.Data 
            });
        }

        [HttpPut("UpdateBusFess")]
        public async Task<ActionResult<CustomMessage>> UpdateBusFess([FromBody] BusFess busFess)
        {
            try
            {
                var updatedBusFess = await _busFessService.UpdateBusFessAsync(busFess);
                var customMessage = new CustomMessage(Message, false, updatedBusFess);
                return Ok(new { 
                    Message = customMessage.Message,
                    IsError = customMessage.Error,
                    Data = customMessage.Data 
                });
            }
            catch (Exception ex)
            {
                var customMessage = new CustomMessage(Message, true, null);
                return BadRequest(new { 
                    Message = customMessage.Message,
                    IsError = customMessage.Error,
                    Data = customMessage.Data,
                    ErrorDetails = ex.Message
                });
            }
        }
    }
}