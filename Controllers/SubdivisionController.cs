using Microsoft.AspNetCore.Mvc;
using YOMA.Models;
using YOMA.Models.Tables;

namespace YOMA.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubdivisionController : ControllerBase
    {
        private readonly Context _context;
        private readonly ISubdivision _subdivisionService;

        public SubdivisionController(Context context, ISubdivision subdivisionService)
        {
            _context = context;
            _subdivisionService = subdivisionService;
        }

        [HttpGet("GetSubdivisions")]
        public async Task<IEnumerable<Subdivision?>> GetSubdivisions()
        {
            return await _subdivisionService.GetBanksAsync();
        }
    }
}