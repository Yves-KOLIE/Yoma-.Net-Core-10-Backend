using Microsoft.AspNetCore.Mvc;
using YOMA.Models;
using YOMA.Models.Tables;

namespace YOMA.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BankController : ControllerBase
    {
        private readonly Context _context;
        private readonly BankService _bankService;
        private readonly string Message = "Banques";

        public BankController(Context context, BankService bankService)
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
                var apiResult = new ApiResult(Message, false, createdBank);
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


        [HttpGet("GetBank/{id}")]
        public async Task<ActionResult<ApiResult>> GetBank(int id)
        {
            try
            {
                var bank = await _bankService.GetBankAsync(id);
                var apiResult = new ApiResult(Message, false, bank);
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

        [HttpGet("GetBanks")]
        public async Task<ActionResult<ApiResult>> GetBanks()
        {
            try
            {
                var banks = await _bankService.GetBanksAsync();
                var apiResult = new ApiResult(Message, false, banks);
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

        // Exemple : http://localhost:5079/api/Banks/GetBankBatch?ids=1&ids=5&ids=10
        [HttpGet("GetBankBatch")]
        public async Task<ActionResult<ApiResult>> GetBankBatch([FromQuery] int[] ids)
        {
            try
            {
                var banks = await _bankService.GetBankByIdsAsync(ids);
                var apiResult = new ApiResult(Message, false, banks);
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

        [HttpPut("UpdateBank")]
        public async Task<ActionResult<ApiResult>> UpdateBank([FromBody] Bank bank)
        {
            try
            {
                var updatedBank = await _bankService.UpdateBankAsync(bank);
                var apiResult = new ApiResult(Message, false, updatedBank);
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

        [HttpPut("BatchUpdateBanks")]
        public async Task<ActionResult<ApiResult>> BatchUpdateBanks([FromBody] List<Bank> banks)
        {
            try
            {
                var updatedBanks = await _bankService.BatchUpdateBanksAsync(banks);
                var apiResult = new ApiResult(Message, false, updatedBanks);
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