using System.Collections.Immutable;
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

        public SubdivisionByYearController(Context context, ISubdivisionByYears subdivisionByYearsService, ISchoolYearService schoolYearService)
        {
            _context = context;
            _subdivisionByYearsService = subdivisionByYearsService;
            _schoolYearService = schoolYearService;
        }

        [HttpGet("GetSubdivisionByYears/{schoolYearId?}")]
        public async Task<IEnumerable<SubdivisionByYearViewModel>> GetSubdivisionByYearsAsync(int? schoolYearId = null)
        {
            var subdivisionByYears = await _subdivisionByYearsService.GetSubdivisionByYearsAsync(schoolYearId);
            var educationLevels = await _context.EducationLevels.AsNoTracking().ToListAsync();

            var formattedList = new List<SubdivisionByYearViewModel>();

            foreach (var educationLevel in educationLevels)
            {
                var subdivisionList = subdivisionByYears
                    .Where(sy => sy.EDUCATION_LEVEL_ID == educationLevel.ID && sy.SUBDIVISION.IS_ACTIVE == true)
                    .Select(sy => new {
                        sy.ID,
                        sy.SUBDIVISION.DESCRIPTION,
                        sy.IS_CHECK,
                    })
                    .OrderBy(sy => sy.DESCRIPTION)
                .ToList();

                var subdivisionByYearsViewList = new List<SubdivisionByYearsView>();

                foreach (var subdivision in subdivisionList)
                {
                    var subdivisionByYearView = new SubdivisionByYearsView
                    {
                        SUBDIVISION_BY_YEAR_ID = subdivision.ID,
                        SUBDIVISION = subdivision.DESCRIPTION,
                        IS_CHECK = subdivision.IS_CHECK
                    };

                    subdivisionByYearsViewList.Add(subdivisionByYearView);
                }

                formattedList.Add(new SubdivisionByYearViewModel
                {
                    SCHOOL_YEAR_ID = schoolYearId,
                    EDUCATION_LEVEL = educationLevel.DESCRIPTION,
                    SUBDIVISION_BY_YEAR_LIST = subdivisionByYearsViewList
                });
            }

            if(schoolYearId == null)
            {
                var activeYear = await _schoolYearService.GetActivedSchoolYear();
                if(activeYear != null) formattedList.ForEach(f => f.SCHOOL_YEAR_ID = activeYear.ID);
            }

            return formattedList;
        }

        [HttpPut("BatchUpdateSubdivisionByYear")]
        public async Task<List<SubdivisionByYear>> BatchUpdateSubdivisionByYearAsync(List<SubdivisionByYear> subdivisionByYears)
        {
            return await _subdivisionByYearsService.BatchUpdateSubdivisionByYearAsync(subdivisionByYears);
        }
    }
}