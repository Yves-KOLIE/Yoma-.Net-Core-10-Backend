using Microsoft.AspNetCore.Mvc;
using YOMA.Models;
using YOMA.Models.Tables;

namespace YOMA.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MonthlySalaryAssignmentController : ControllerBase
    {
        private readonly Context _context;
        private readonly MonthlySalaryAssignmentService _monthlySalaryAssignmentService;
        private readonly string Message = "Salaires mensuels";

        public MonthlySalaryAssignmentController(Context context, MonthlySalaryAssignmentService monthlySalaryAssignmentService)
        {
            _context = context;
            _monthlySalaryAssignmentService = monthlySalaryAssignmentService;
        }

        [HttpGet("GetMonthlySalaryAssignmentByYearId/{schoolYearId?}")]
        public async Task<ActionResult<ApiResult>> GetMonthlySalaryAssignmentByYearId(int? schoolYearId = null)
        {
            try
            {
                var monthlySalaryAssignments = await _monthlySalaryAssignmentService.GetMonthlySalaryAssignmentByYearIdAsync(schoolYearId);
                var apiResult = new ApiResult(Message, false, monthlySalaryAssignments);
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

        [HttpPost("CreateMonthlySalaryAssignment")]
        public async Task<ActionResult<ApiResult>> CreateMonthlySalaryAssignment([FromBody] MonthlySalaryAssignment monthlySalaryAssignment)
        {
            try
            {
                var createdMonthlySalaryAssignment = await _monthlySalaryAssignmentService.CreateMonthlySalaryAssignmentAsync(monthlySalaryAssignment);
                var apiResult = new ApiResult(Message, false, createdMonthlySalaryAssignment);
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

        [HttpPut("UpdateMonthlySalaryAssignment")]
        public async Task<ActionResult<ApiResult>> UpdateMonthlySalaryAssignment([FromBody] MonthlySalaryAssignment monthlySalaryAssignment)
        {
            try
            {
                var updatedMonthlySalaryAssignment = await _monthlySalaryAssignmentService.UpdateMonthlySalaryAssignmentAsync(monthlySalaryAssignment);
                var apiResult = new ApiResult(Message, false, updatedMonthlySalaryAssignment);
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

        [HttpDelete("DeleteMonthlySalaryAssignment")]
        public async Task<ActionResult<ApiResult>> DeleteMonthlySalaryAssignment(MonthlySalaryAssignment monthlySalaryAssignment)
        {
            try
            {
                await _monthlySalaryAssignmentService.DeleteMonthlySalaryAssignmentAsync(monthlySalaryAssignment);
                var apiResult = new ApiResult(Message, false, null);
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