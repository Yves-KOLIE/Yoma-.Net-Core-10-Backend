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

        public BusFessController(Context context, IBusFessService busFessService)
        {
            _context = context;
            _busFessService = busFessService;
        }

        [HttpGet("GetBusFess/{id}")]
        public async Task<BusFess?> GetBusFess(int id)
        {
            return await _busFessService.GetBusFessAsync(id);
        }

        [HttpGet("GetBusFesses")]
        public async Task<IEnumerable<BusFess>> GetBusFesses()
        {
            return await _busFessService.GetBusFessesAsync();
        }

        [HttpPut("UpdateBusFess")]
        public async Task<BusFess> UpdateBusFess([FromBody] BusFess busFess)
        {
            return await _busFessService.UpdateBusFessAsync(busFess);
        }
    }
}