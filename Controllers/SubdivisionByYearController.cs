using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YOMA.Helpers;
using YOMA.Models;
using YOMA.Models.Tables;
using YOMA.Models.Views;

namespace YOMA.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubdivisionByYearController : ControllerBase
    {
        private readonly Context _context;
        private readonly SubdivisionByYearService _subdivisionByYearsService;
        private readonly SchoolYearService _schoolYearService;
        private readonly string Message = "Subdivisions par année";

        public SubdivisionByYearController(Context context, SubdivisionByYearService subdivisionByYearsService, SchoolYearService schoolYearService)
        {
            _context = context;
            _subdivisionByYearsService = subdivisionByYearsService;
            _schoolYearService = schoolYearService;
        }

        [HttpGet("GetSubdivisionByYears/{schoolYearId?}")]
        public async Task<ActionResult<ApiResult>> GetSubdivisionByYearsAsync([FromQuery] int? schoolYearId = null)
        {
            try
            {
                var subdivisionByYears = await _subdivisionByYearsService.GetSubdivisionByYearsAsync(schoolYearId);
                var subdivisionByYearsViewModelList = await _subdivisionByYearsService.GetSubdivisionByYearsViewModelAsync(subdivisionByYears, schoolYearId);

                var apiResult = new ApiResult(Message, false, subdivisionByYearsViewModelList);
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

        [HttpPut("BatchUpdateSubdivisionByYear")]
        public async Task<ActionResult<ApiResult>> BatchUpdateSubdivisionByYearAsync([FromBody] List<SubdivisionByYear> subdivisionByYearList)
        {
            try
            {
                var isUpdated = await _subdivisionByYearsService.BatchUpdateSubdivisionByYearAsync(subdivisionByYearList);
                var apiResult = new ApiResult(ConstantHelper.SAVE_SUCCESS_MSG, false, isUpdated);
                return Ok(new { 
                    Message = apiResult.Message,
                    IsError = apiResult.IsError,
                    Data = apiResult.Data 
                });
            }
            catch (Exception ex)
            {
                var apiResult = new ApiResult(ConstantHelper.SAVE_ERROR_MSG, true, false);
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