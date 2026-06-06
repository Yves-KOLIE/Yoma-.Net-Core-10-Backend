using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
                
                var educationLevels = await _context.EducationLevels
                    .AsNoTracking()
                    .Include(x => x.HIGH_SCHOOL_OPTION)
                .ToListAsync();

                var updatedRows = new List<SubdivisionByYearViewModel>();

                foreach (var educationLevel in educationLevels)
                {
                    var subdivisionList = subdivisionByYears
                        .Where(sy => sy.EDUCATION_LEVEL_ID == educationLevel.ID && sy.SUBDIVISION.IS_ACTIVE == true)
                        .OrderBy(sy => sy.ID)
                    .ToList();

                    var subdivisionByYearsList = new List<SubdivisionByYear>();

                    foreach (var subdivision in subdivisionList)
                    {
                        subdivisionByYearsList.Add(subdivision);
                    }

                    updatedRows.Add(new SubdivisionByYearViewModel
                    {
                        SCHOOL_YEAR_ID = schoolYearId,
                        EDUCATION_LEVEL = (educationLevel.DESCRIPTION + " " + educationLevel?.HIGH_SCHOOL_OPTION?.ABBREVIATION).Trim(),
                        SUBDIVISION_BY_YEAR_LIST = subdivisionByYearsList
                    });
                }

                if(schoolYearId == null)
                {
                    var activeYear = await _schoolYearService.GetActivedSchoolYear();
                    if(activeYear != null) updatedRows.ForEach(f => f.SCHOOL_YEAR_ID = activeYear.ID);
                }

                var apiResult = new ApiResult(Message, false, updatedRows);
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
        public async Task<ActionResult<ApiResult>> BatchUpdateSubdivisionByYearAsync(List<SubdivisionByYearViewModel> subdivisionByYearViewModelList)
        {
            try
            {
                var updatedRows = await _subdivisionByYearsService.BatchUpdateSubdivisionByYearAsync(subdivisionByYearViewModelList);
                var apiResult = new ApiResult(Message, false, updatedRows);
                return Ok(new { 
                    Message = apiResult.Message,
                    IsError = apiResult.IsError,
                    Data = apiResult.Data 
                });
            }
            catch (Exception ex)
            {
                string errorMessage = "Une erreur s'est produite lors de la mise à jour des subdivisions par année.";
                var apiResult = new ApiResult(errorMessage, true, null);
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