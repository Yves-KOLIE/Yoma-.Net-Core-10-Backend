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
        private readonly ISubdivisionByYears _subdivisionByYearsService;
        private readonly ISchoolYearService _schoolYearService;
        private readonly string Message = "Subdivisions par année";

        public SubdivisionByYearController(Context context, ISubdivisionByYears subdivisionByYearsService, ISchoolYearService schoolYearService)
        {
            _context = context;
            _subdivisionByYearsService = subdivisionByYearsService;
            _schoolYearService = schoolYearService;
        }

        [HttpGet("GetSubdivisionByYears/{schoolYearId?}")]
        public async Task<ActionResult<CustomMessage>> GetSubdivisionByYearsAsync(int? schoolYearId = null)
        {
            var subdivisionByYears = await _subdivisionByYearsService.GetSubdivisionByYearsAsync(schoolYearId);
            var educationLevels = await _context.EducationLevels.AsNoTracking().ToListAsync();

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
                    EDUCATION_LEVEL = educationLevel.DESCRIPTION,
                    SUBDIVISION_BY_YEAR_LIST = subdivisionByYearsList
                });
            }

            if(schoolYearId == null)
            {
                var activeYear = await _schoolYearService.GetActivedSchoolYear();
                if(activeYear != null) updatedRows.ForEach(f => f.SCHOOL_YEAR_ID = activeYear.ID);
            }

            var customMessage = new CustomMessage(Message, false, updatedRows);
            return Ok(new { 
                Message = customMessage.Message,
                IsError = customMessage.IsError,
                Data = customMessage.Data 
            });
        }

        [HttpPut("BatchUpdateSubdivisionByYear")]
        public async Task<ActionResult<CustomMessage>> BatchUpdateSubdivisionByYearAsync(List<SubdivisionByYearViewModel> subdivisionByYearViewModelList)
        {
            try
            {
                var updatedRows = await _subdivisionByYearsService.BatchUpdateSubdivisionByYearAsync(subdivisionByYearViewModelList);
                var customMessage = new CustomMessage(Message, false, updatedRows);
                return Ok(new { 
                    Message = customMessage.Message,
                    IsError = customMessage.IsError,
                    Data = customMessage.Data 
                });
            }
            catch (Exception ex)
            {
                string errorMessage = "Une erreur s'est produite lors de la mise à jour des subdivisions par année.";
                var customMessage = new CustomMessage(errorMessage, true, null);
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