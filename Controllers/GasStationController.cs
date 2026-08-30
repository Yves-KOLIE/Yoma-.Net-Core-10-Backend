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
                var apiResult = new ApiResult(Message, false, createdGasStation);
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


        [HttpGet("GetGasStations")]
        public async Task<ActionResult<ApiResult>> GetGasStations()
        {
            try
            {
                var gasStations = await _gasStationService.GetGasStationsAsync();
                var apiResult = new ApiResult(Message, false, gasStations);
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

        [HttpPut("UpdateGasStation")]
        public async Task<ActionResult<ApiResult>> UpdateGasStation([FromBody] GasStation gasStation)
        {
            try
            {
                var updatedGasStation = await _gasStationService.UpdateGasStationAsync(gasStation);
                var apiResult = new ApiResult(Message, false, updatedGasStation);
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