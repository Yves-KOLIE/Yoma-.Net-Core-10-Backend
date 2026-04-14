using Microsoft.AspNetCore.Mvc;
using YOMA.Models;
using YOMA.Models.Tables;

namespace YOMA.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SchoolYearController : ControllerBase
    {
        private readonly Context _context;
        private readonly SchoolYearService _schoolYearService;
        private readonly string Message = "Année scolaire";

        public SchoolYearController(Context context, SchoolYearService schoolYearService)
        {
            _context = context;
            _schoolYearService = schoolYearService;
        }

        [HttpPost("CreateSchoolYear")]
        public async Task<ActionResult<ApiResult>> CreateSchoolYear([FromBody] SchoolYear schoolYear)
        {
            try
            {
                var createdSchoolYear = await _schoolYearService.CreateSchoolYearAsync(schoolYear);
                var customMessage = new ApiResult(Message, false, createdSchoolYear);
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

        [HttpGet("GetSchoolYear/{id}")]
        public async Task<ActionResult<ApiResult>> GetSchoolYear(int id)
        {
            var schoolYear = await _schoolYearService.GetSchoolYearAsync(id);
            var customMessage = new ApiResult(Message, false, schoolYear);
            return Ok(new { 
                Message = customMessage.Message,
                IsError = customMessage.IsError,
                Data = customMessage.Data 
            });
        }

        [HttpGet("GetSchoolYears")]
        public async Task<ActionResult<ApiResult>> GetSchoolYears()
        {
            var schoolYears = await _schoolYearService.GetSchoolYearsAsync();
            var customMessage = new ApiResult(Message, false, schoolYears);
            return Ok(new { 
                Message = customMessage.Message,
                IsError = customMessage.IsError,
                Data = customMessage.Data 
            });
        }

        // Exemple : http://localhost:5079/api/SchoolYears/GetSchoolYearBatch?ids=1&ids=5&ids=10
        [HttpGet("GetSchoolYearBatch")]
        public async Task<ActionResult<ApiResult>> GetSchoolYearBatch([FromQuery] int[] ids)
        {
            var schoolYears = await _schoolYearService.GetSchoolYearBatchAsync(ids);
            var customMessage = new ApiResult(Message, false, schoolYears);
            return Ok(new { 
                Message = customMessage.Message,
                IsError = customMessage.IsError,
                Data = customMessage.Data 
            });
        }

        [HttpPut("UpdateSchoolYear")]
        public async Task<ActionResult<ApiResult>> UpdateSchoolYear([FromBody] SchoolYear schoolYear)
        {
            try
            {
                var updatedSchoolYear = await _schoolYearService.UpdateSchoolYearAsync(schoolYear);
                var customMessage = new ApiResult(Message, false, updatedSchoolYear);
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

        [HttpPut("BatchUpdateSchoolYears")]
        public async Task<ActionResult<ApiResult>> BatchUpdateSchoolYears([FromBody] List<SchoolYear> schoolYears)
        {
            try
            {
                var updatedSchoolYears = await _schoolYearService.BatchUpdateSchoolYearsAsync(schoolYears);
                var customMessage = new ApiResult(Message, false, updatedSchoolYears);
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