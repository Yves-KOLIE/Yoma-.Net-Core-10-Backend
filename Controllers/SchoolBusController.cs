using Microsoft.AspNetCore.Mvc;
using YOMA.Models;
using YOMA.Models.Tables;

namespace YOMA.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SchoolBusController : ControllerBase
    {
        private readonly Context _context;
        private readonly SchoolBusService _schoolBusService;
        private readonly string Message = "Station de carburant";

        public SchoolBusController(Context context, SchoolBusService schoolBusService)
        {
            _context = context;
            _schoolBusService = schoolBusService;
        }

        [HttpPost("CreateSchoolBus")]
        public async Task<ActionResult<ApiResult>> CreateSchoolBus([FromBody] SchoolBus schoolBus)
        {
            try
            {
                var createdGasStation = await _schoolBusService.CreateSchoolBusAsync(schoolBus);
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


        [HttpGet("GetSchoolBus")]
        public async Task<ActionResult<ApiResult>> GetGasStations()
        {
            try
            {
                var gasStations = await _schoolBusService.GetSchoolBusAsync();
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

        [HttpPut("UpdateSchoolBus")]
        public async Task<ActionResult<ApiResult>> UpdateGasStation([FromBody] SchoolBus schoolBus)
        {
            try
            {
                var updatedGasStation = await _schoolBusService.UpdateSchoolBusAsync(schoolBus);
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