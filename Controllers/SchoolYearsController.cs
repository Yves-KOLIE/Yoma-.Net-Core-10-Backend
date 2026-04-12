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

        [HttpPost("CreateSchoolYear")]
        public async Task<SchoolYear> CreateSchoolYear([FromBody] SchoolYear schoolYear)
        {
            return await _schoolYearService.CreateSchoolYearAsync(schoolYear);
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

        // Exemple : http://localhost:5079/api/SchoolYears/GetSchoolYearBatch?ids=1&ids=5&ids=10
        [HttpGet("GetSchoolYearBatch")]
        public async Task<IEnumerable<SchoolYear?>> GetSchoolYearBatch([FromQuery] int[] ids)
        {
            return await _schoolYearService.GetSchoolYearBatchAsync(ids);
        }

        [HttpPut("UpdateSchoolYear")]
        public async Task<SchoolYear> UpdateSchoolYear([FromBody] SchoolYear schoolYear)
        {
            return await _schoolYearService.UpdateSchoolYearAsync(schoolYear);
        }
    }
}