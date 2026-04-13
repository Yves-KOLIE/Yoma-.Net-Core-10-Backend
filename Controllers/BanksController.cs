using Microsoft.AspNetCore.Mvc;
using YOMA.Models;
using YOMA.Models.Tables;

namespace YOMA.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BanksController : ControllerBase
    {
        private readonly Context _context;
        private readonly IBankService _bankService;
        private readonly string Message = "Banques";

        public BanksController(Context context, BankService bankService)
        {
            _context = context;
            _bankService = bankService;
        }

        [HttpPost("CreateBank")]
        public async Task<ActionResult<ApiResult>> CreateBank([FromBody] Bank bank)
        {
            try
            {
                var createdBank = await _bankService.CreateBankAsync(bank);
                var customMessage = new ApiResult(Message, false, createdBank);
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


        [HttpGet("GetBank/{id}")]
        public async Task<ActionResult<ApiResult>> GetBank(int id)
        {
            var bank = await _bankService.GetBankAsync(id);
            var customMessage = new ApiResult(Message, false, bank);
            return Ok(new { 
                Message = customMessage.Message,
                IsError = customMessage.IsError,
                Data = customMessage.Data 
            });
        }

        [HttpGet("GetBanks")]
        public async Task<ActionResult<ApiResult>> GetBanks()
        {
            var banks = await _bankService.GetBanksAsync();
            var customMessage = new ApiResult(Message, false, banks);
            return Ok(new { 
                Message = customMessage.Message,
                IsError = customMessage.IsError,
                Data = customMessage.Data 
            });
        }

        // Exemple : http://localhost:5079/api/Banks/GetBankBatch?ids=1&ids=5&ids=10
        [HttpGet("GetBankBatch")]
        public async Task<ActionResult<ApiResult>> GetBankBatch([FromQuery] int[] ids)
        {
            var banks = await _bankService.GetBankBatchAsync(ids);
            var customMessage = new ApiResult(Message, false, banks);
            return Ok(new { 
                Message = customMessage.Message,
                IsError = customMessage.IsError,
                Data = customMessage.Data 
            });
        }

        [HttpPut("UpdateBank")]
        public async Task<ActionResult<ApiResult>> UpdateBank([FromBody] Bank bank)
        {
            try
            {
                var updatedBank = await _bankService.UpdateBankAsync(bank);
                var customMessage = new ApiResult(Message, false, updatedBank);
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