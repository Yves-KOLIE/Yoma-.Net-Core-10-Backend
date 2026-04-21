using Microsoft.AspNetCore.Mvc;
using YOMA.Models;
using YOMA.Models.Tables;

namespace YOMA.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NoteMonthController : ControllerBase
    {
        private readonly Context _context;
        private readonly NoteMonthService _noteMonthService;
        private readonly string Message = "Mois des notes de cours";

        public NoteMonthController(Context context, NoteMonthService noteMonthService)
        {
            _context = context;
            _noteMonthService = noteMonthService;
        }

        [HttpGet("GetNoteMonthsByYear/{schoolYearId?}")]
        public async Task<ActionResult<ApiResult>> GetNoteMonthsByYear(int? schoolYearId = null)
        {
            try
            {
                var noteMonths = await _noteMonthService.GetNoteMonthsByYearAsync(schoolYearId);
                var apiResult = new ApiResult(Message, false, noteMonths);
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

        [HttpPut("BatchUpdateNoteMonths")]
        public async Task<ActionResult<ApiResult>> BatchUpdateNoteMonths([FromBody] List<NoteMonth> noteMonths)
        {
            try
            {
                var updatedNoteMonths = await _noteMonthService.BatchUpdateNoteMonthsAsync(noteMonths);
                var apiResult = new ApiResult(Message, false, updatedNoteMonths);
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