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
        private readonly string Message = "Lieux de naissance";

        public BirthPlaceController(Context context, BirthPlaceService birthPlaceService)
        {
            _context = context;
            _birthPlaceService = birthPlaceService;
        }

        [HttpPost("CreateBirthPlace")]
        public async Task<ActionResult<CustomMessage>> CreateBirthPlace([FromBody] BirthPlace birthPlace)
        {
            try
            {
                var createdBirthPlace = await _birthPlaceService.CreateBirthPlaceAsync(birthPlace);
                var customMessage = new CustomMessage(Message, false, createdBirthPlace);
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

        [HttpGet("GetBirthPlace/{id}")]
        public async Task<ActionResult<CustomMessage>> GetBirthPlace(int id)
        {
            var birthPlace = await _birthPlaceService.GetBirthPlaceAsync(id);
            var customMessage = new CustomMessage(Message, false, birthPlace);
            return Ok(new { 
                Message = customMessage.Message,
                IsError = customMessage.Error,
                Data = customMessage.Data 
            });
        }

        [HttpGet("GetBirthPlaces")]
        public async Task<ActionResult<CustomMessage>> GetBirthPlaces()
        {
            var birthPlaces = await _birthPlaceService.GetBirthPlacesAsync();
            var customMessage = new CustomMessage(Message, false, birthPlaces);
            return Ok(new { 
                Message = customMessage.Message,
                IsError = customMessage.Error,
                Data = customMessage.Data 
            });
        }

        // Exemple : http://localhost:5079/api/BirthPlaces/GetBirthPlaceBatch?ids=1&ids=5&ids=10
        [HttpGet("GetBirthPlaceBatch")]
        public async Task<ActionResult<CustomMessage>> GetBirthPlaceBatch([FromQuery] int[] ids)
        {
            var birthPlaces = await _birthPlaceService.GetBirthPlaceBatchAsync(ids);
            var customMessage = new CustomMessage(Message, false, birthPlaces);
            return Ok(new { 
                Message = customMessage.Message,
                IsError = customMessage.Error,
                Data = customMessage.Data 
            });
        }

        [HttpPut("UpdateBirthPlace")]
        public async Task<ActionResult<CustomMessage>> UpdateBirthPlace([FromBody] BirthPlace birthPlace)
        {
            try
            {
                var updatedBirthPlace = await _birthPlaceService.UpdateBirthPlaceAsync(birthPlace);
                var customMessage = new CustomMessage(Message, false, updatedBirthPlace);
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