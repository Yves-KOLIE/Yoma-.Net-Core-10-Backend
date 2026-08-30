using Microsoft.AspNetCore.Mvc;
using YOMA.Helpers;
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


        [HttpGet("GetSchoolYears")]
        public async Task<ActionResult<ApiResult>> GetSchoolYears()
        {
            try
            {
                var schoolYears = await _schoolYearService.GetSchoolYearsAsync();
                var apiResult = new ApiResult(Message, false, schoolYears);
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

        [HttpPost("CreateSchoolYear")]
        public async Task<ActionResult<ApiResult>> CreateSchoolYear([FromBody] SchoolYear schoolYear)
        {
            try
            {
                await _schoolYearService.CreateSchoolYearAsync(schoolYear);
                var schoolYearList = await _schoolYearService.GetSchoolYearsAsync();
                var apiResult = new ApiResult(ConstantHelper.SAVE_SUCCESS_MSG, false, schoolYearList);
                return Ok(new { 
                    Message = apiResult.Message,
                    IsError = apiResult.IsError,
                    Data = apiResult.Data 
                });
            }
            catch (Exception ex)
            {
                var apiResult = new ApiResult(ConstantHelper.SAVE_ERROR_MSG, true, null);
                return BadRequest(new { 
                    Message = apiResult.Message,
                    IsError = apiResult.IsError,
                    Data = apiResult.Data,
                    ErrorDetails = ex.Message
                });
            }
        }

        [HttpPut("UpdateSchoolYear")]
        public async Task<ActionResult<ApiResult>> UpdateSchoolYear([FromBody] SchoolYear schoolYear)
        {
            try
            {
                await _schoolYearService.UpdateSchoolYearAsync(schoolYear);
                var schoolYearList = await _schoolYearService.GetSchoolYearsAsync();
                var apiResult = new ApiResult(ConstantHelper.SAVE_SUCCESS_MSG, false, schoolYearList);
                return Ok(new { 
                    Message = apiResult.Message,
                    IsError = apiResult.IsError,
                    Data = apiResult.Data 
                });
            }
            catch (Exception ex)
            {
                var apiResult = new ApiResult(ConstantHelper.SAVE_ERROR_MSG, true, null);
                return BadRequest(new { 
                    Message = apiResult.Message,
                    IsError = apiResult.IsError,
                    Data = apiResult.Data,
                    ErrorDetails = ex.Message
                });
            }
        }

        [HttpDelete("DeleteSchoolYear")]
        public async Task<ActionResult<ApiResult>> DeleteSchoolYear([FromBody] SchoolYear schoolYear)
        {
            try
            {
                await _schoolYearService.DeleteSchoolYearAsync(schoolYear);
                var schoolYearList = await _schoolYearService.GetSchoolYearsAsync();
                var apiResult = new ApiResult(ConstantHelper.SAVE_SUCCESS_MSG, false, schoolYearList);
                return Ok(new { 
                    Message = apiResult.Message,
                    IsError = apiResult.IsError,
                    Data = apiResult.Data 
                });
            }
            catch (Exception ex)
            {
                var apiResult = new ApiResult(ConstantHelper.SAVE_ERROR_MSG, true, null);
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