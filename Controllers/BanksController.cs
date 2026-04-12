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

        public BanksController(Context context, BankService bankService)
        {
            _context = context;
            _bankService = bankService;
        }

        [HttpPost("CreateBank")]
        public async Task<Bank> CreateBank([FromBody] Bank bank)
        {
            return await _bankService.CreateBankAsync(bank);
        }


        [HttpGet("GetBank/{id}")]
        public async Task<Bank?> GetBank(int id)
        {
            return await _bankService.GetBankAsync(id);
        }

        [HttpGet("GetBanks")]
        public async Task<IEnumerable<Bank?>> GetBanks()
        {
            return await _bankService.GetBanksAsync();
        }

        // Exemple : http://localhost:5079/api/Banks/GetBankBatch?ids=1&ids=5&ids=10
        [HttpGet("GetBankBatch")]
        public async Task<IEnumerable<Bank?>> GetBankBatch([FromQuery] int[] ids)
        {
            return await _bankService.GetBankBatchAsync(ids);
        }

        [HttpPut("UpdateBank")]
        public async Task<Bank> UpdateBank([FromBody] Bank bank)
        {
            return await _bankService.UpdateBankAsync(bank);
        }
    }
}