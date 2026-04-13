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
        private readonly ISchoolYearService _schoolYearService;
        private readonly string Message = "Année scolaire";

        public SchoolYearController(Context context, ISchoolYearService schoolYearService)
        {
            _context = context;
            _schoolYearService = schoolYearService;
        }

        [HttpPost("CreateSchoolYear")]
        public async Task<ActionResult<CustomMessage>> CreateSchoolYear([FromBody] SchoolYear schoolYear)
        {
            try
            {
                var createdSchoolYear = await _schoolYearService.CreateSchoolYearAsync(schoolYear);
                var customMessage = new CustomMessage(Message, false, createdSchoolYear);
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

        [HttpGet("GetSchoolYear/{id}")]
        public async Task<ActionResult<CustomMessage>> GetSchoolYear(int id)
        {
            var schoolYear = await _schoolYearService.GetSchoolYearAsync(id);
            var customMessage = new CustomMessage(Message, false, schoolYear);
            return Ok(new { 
                Message = customMessage.Message,
                IsError = customMessage.Error,
                Data = customMessage.Data 
            });
        }

        [HttpGet("GetSchoolYears")]
        public async Task<ActionResult<CustomMessage>> GetSchoolYears()
        {
            var schoolYears = await _schoolYearService.GetSchoolYearsAsync();
            var customMessage = new CustomMessage(Message, false, schoolYears);
            return Ok(new { 
                Message = customMessage.Message,
                IsError = customMessage.Error,
                Data = customMessage.Data 
            });
        }

        // Exemple : http://localhost:5079/api/SchoolYears/GetSchoolYearBatch?ids=1&ids=5&ids=10
        [HttpGet("GetSchoolYearBatch")]
        public async Task<ActionResult<CustomMessage>> GetSchoolYearBatch([FromQuery] int[] ids)
        {
            var schoolYears = await _schoolYearService.GetSchoolYearBatchAsync(ids);
            var customMessage = new CustomMessage(Message, false, schoolYears);
            return Ok(new { 
                Message = customMessage.Message,
                IsError = customMessage.Error,
                Data = customMessage.Data 
            });
        }

        [HttpPut("UpdateSchoolYear")]
        public async Task<ActionResult<CustomMessage>> UpdateSchoolYear([FromBody] SchoolYear schoolYear)
        {
            try
            {
                var updatedSchoolYear = await _schoolYearService.UpdateSchoolYearAsync(schoolYear);
                var customMessage = new CustomMessage(Message, false, updatedSchoolYear);
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