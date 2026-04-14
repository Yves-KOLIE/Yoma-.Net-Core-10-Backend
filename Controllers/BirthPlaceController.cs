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
        private readonly BirthPlaceService _birthPlaceService;
        private readonly string Message = "Lieux de naissance";

        public BirthPlaceController(Context context, BirthPlaceService birthPlaceService)
        {
            _context = context;
            _birthPlaceService = birthPlaceService;
        }

        [HttpPost("CreateBirthPlace")]
        public async Task<ActionResult<ApiResult>> CreateBirthPlace([FromBody] BirthPlace birthPlace)
        {
            try
            {
                var createdBirthPlace = await _birthPlaceService.CreateBirthPlaceAsync(birthPlace);
                var apiResult = new ApiResult(Message, false, createdBirthPlace);
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

        [HttpGet("GetBirthPlace/{id}")]
        public async Task<ActionResult<ApiResult>> GetBirthPlace(int id)
        {
            var birthPlace = await _birthPlaceService.GetBirthPlaceAsync(id);
            var apiResult = new ApiResult(Message, false, birthPlace);
            return Ok(new { 
                Message = apiResult.Message,
                IsError = apiResult.IsError,
                Data = apiResult.Data 
            });
        }

        [HttpGet("GetBirthPlaces")]
        public async Task<ActionResult<ApiResult>> GetBirthPlaces()
        {
            var birthPlaces = await _birthPlaceService.GetBirthPlacesAsync();
            var apiResult = new ApiResult(Message, false, birthPlaces);
            return Ok(new { 
                Message = apiResult.Message,
                IsError = apiResult.IsError,
                Data = apiResult.Data 
            });
        }

        // Exemple : http://localhost:5079/api/BirthPlaces/GetBirthPlaceBatch?ids=1&ids=5&ids=10
        [HttpGet("GetBirthPlaceBatch")]
        public async Task<ActionResult<ApiResult>> GetBirthPlaceBatch([FromQuery] int[] ids)
        {
            var birthPlaces = await _birthPlaceService.GetBirthPlaceBatchAsync(ids);
            var apiResult = new ApiResult(Message, false, birthPlaces);
            return Ok(new { 
                Message = apiResult.Message,
                IsError = apiResult.IsError,
                Data = apiResult.Data 
            });
        }

        [HttpPut("UpdateBirthPlace")]
        public async Task<ActionResult<ApiResult>> UpdateBirthPlace([FromBody] BirthPlace birthPlace)
        {
            try
            {
                var updatedBirthPlace = await _birthPlaceService.UpdateBirthPlaceAsync(birthPlace);
                var apiResult = new ApiResult(Message, false, updatedBirthPlace);
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

        [HttpPut("BatchUpdateBirthPlaces")]
        public async Task<ActionResult<ApiResult>> BatchUpdateBirthPlaces([FromBody] List<BirthPlace> birthPlaces)
        {
            try
            {
                var updatedBirthPlaces = await _birthPlaceService.BatchUpdateBirthPlacesAsync(birthPlaces);
                var apiResult = new ApiResult(Message, false, updatedBirthPlaces);
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