using Microsoft.AspNetCore.Mvc;
using YOMA.Models;
using YOMA.Models.Tables;

namespace YOMA.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SchoolYearsController : ControllerBase
    {
        private readonly Context _context;
        private readonly ISchoolYearService _schoolYearService;

        public SchoolYearsController(Context context, ISchoolYearService schoolYearService)
        {
            _context = context;
            _schoolYearService = schoolYearService;
        }

        [HttpGet("GetSchoolYear/{id}")]
        public async Task<SchoolYear?> GetSchoolYear(int id)
        {
            return await _schoolYearService.GetSchoolYearAsync(id);
        }

        [HttpGet("GetSchoolYears")]
        public async Task<IEnumerable<SchoolYear?>> GetSchoolYears()
        {
            return await _schoolYearService.GetSchoolYearsAsync();
        }

        [HttpGet("GetSchoolYearBatch")]
        public async Task<IEnumerable<SchoolYear?>> GetSchoolYearBatch([FromQuery] int[] ids)
        {
            return await _schoolYearService.GetSchoolYearBatchAsync(ids);
        }

        [HttpPut("UpdateSchoolYear")]
        public async Task<SchoolYear> UpdateSchoolYear(SchoolYear schoolYear)
        {
            return await _schoolYearService.UpdateSchoolYearAsync(schoolYear);
        }
    }
}