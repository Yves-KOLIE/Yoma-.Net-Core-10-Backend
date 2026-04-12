using Microsoft.AspNetCore.Mvc;
using YOMA.Models;
using YOMA.Models.Tables;

namespace YOMA.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BirthPlaceController : ControllerBase
    {
        private readonly Context _context;
        private readonly IBirthPlaceService _birthPlaceService;

        public BirthPlaceController(Context context, BirthPlaceService birthPlaceService)
        {
            _context = context;
            _birthPlaceService = birthPlaceService;
        }

        [HttpPost("CreateBirthPlace")]
        public async Task<BirthPlace> CreateBirthPlace([FromBody] BirthPlace birthPlace)
        {
            return await _birthPlaceService.CreateBirthPlaceAsync(birthPlace);
        }

        [HttpGet("GetBirthPlace/{id}")]
        public async Task<BirthPlace?> GetBirthPlace(int id)
        {
            return await _birthPlaceService.GetBirthPlaceAsync(id);
        }

        [HttpGet("GetBirthPlaces")]
        public async Task<IEnumerable<BirthPlace>> GetBirthPlaces()
        {
            return await _birthPlaceService.GetBirthPlacesAsync();
        }

        // Exemple : http://localhost:5079/api/BirthPlaces/GetBirthPlaceBatch?ids=1&ids=5&ids=10
        [HttpGet("GetBirthPlaceBatch")]
        public async Task<IEnumerable<BirthPlace?>> GetBirthPlaceBatch([FromQuery] int[] ids)
        {
            return await _birthPlaceService.GetBirthPlaceBatchAsync(ids);
        }

        [HttpPut("UpdateBirthPlace")]
        public async Task<BirthPlace> UpdateBirthPlace([FromBody] BirthPlace birthPlace)
        {
            return await _birthPlaceService.UpdateBirthPlaceAsync(birthPlace);
        }
    }
}