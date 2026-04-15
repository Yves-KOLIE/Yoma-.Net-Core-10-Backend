using Microsoft.AspNetCore.Mvc;
using YOMA.Models;
using YOMA.Models.Tables;

namespace YOMA.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MonthOfSalaryController : ControllerBase
    {
        private readonly Context _context;
        private readonly MonthOfSalaryService _salaryOfMonthService;
        private readonly string Message = "Mois des salaires";

        public MonthOfSalaryController(Context context, MonthOfSalaryService salaryOfMonthService)
        {
            _context = context;
            _salaryOfMonthService = salaryOfMonthService;
        }

        [HttpGet("GetMonthsOfSalariesByYear/{schoolYearId?}")]
        public async Task<ActionResult<ApiResult>> GetMonthsOfSalariesByYear(int? schoolYearId = null)
        {
            var months = await _salaryOfMonthService.GetMonthsOfSalariesByYearAsync(schoolYearId);
            var apiResult = new ApiResult(Message, false, months);
            return Ok(new { 
                Message = apiResult.Message,
                IsError = apiResult.IsError,
                Data = apiResult.Data 
            });
        }

        [HttpPut("BatchUpdateMonthOfSalaries")]
        public async Task<ActionResult<ApiResult>> BatchUpdateMonthOfSalaries([FromBody] List<MonthOfSalary> monthsOfSalaries)
        {
            try
            {
                var updatedMonths = await _salaryOfMonthService.BatchUpdateMonthOfSalariesAsync(monthsOfSalaries);
                var apiResult = new ApiResult(Message, false, updatedMonths);
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