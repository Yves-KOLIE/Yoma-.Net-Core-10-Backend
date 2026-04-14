using Microsoft.AspNetCore.Mvc;
using YOMA.Models;
using YOMA.Models.Tables;

namespace YOMA.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GasStationController : ControllerBase
    {
        private readonly Context _context;
        private readonly GasStationService _gasStationService;
        private readonly string Message = "Station de carburant";

        public GasStationController(Context context, GasStationService gasStationService)
        {
            _context = context;
            _gasStationService = gasStationService;
        }

        [HttpPost("CreateGasStation")]
        public async Task<ActionResult<ApiResult>> CreateGasStation([FromBody] GasStation gasStation)
        {
            try
            {
                var createdGasStation = await _gasStationService.CreateGasStationAsync(gasStation);
                var customMessage = new ApiResult(Message, false, createdGasStation);
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

        [HttpGet("GetGasStation/{id}")]
        public async Task<ActionResult<ApiResult>> GetGasStation(int id)
        {
            var gasStation = await _gasStationService.GetGasStationAsync(id);
            var customMessage = new ApiResult(Message, false, gasStation);
            return Ok(new { 
                Message = customMessage.Message,
                IsError = customMessage.IsError,
                Data = customMessage.Data 
            });
        }

        [HttpGet("GetGasStations")]
        public async Task<ActionResult<ApiResult>> GetGasStations()
        {
            var gasStations = await _gasStationService.GetGasStationsAsync();
            var customMessage = new ApiResult(Message, false, gasStations);
            return Ok(new { 
                Message = customMessage.Message,
                IsError = customMessage.IsError,
                Data = customMessage.Data 
            });
        }

        [HttpPut("UpdateGasStation")]
        public async Task<ActionResult<ApiResult>> UpdateGasStation([FromBody] GasStation gasStation)
        {
            try
            {
                var updatedGasStation = await _gasStationService.UpdateGasStationAsync(gasStation);
                var customMessage = new ApiResult(Message, false, updatedGasStation);
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

        [HttpPut("BatchUpdateGasStations")]
        public async Task<ActionResult<ApiResult>> BatchUpdateGasStations([FromBody] List<GasStation> gasStations)
        {
            try
            {
                var updatedGasStations = await _gasStationService.BatchUpdateGasStationsAsync(gasStations);
                var customMessage = new ApiResult(Message, false, updatedGasStations);
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