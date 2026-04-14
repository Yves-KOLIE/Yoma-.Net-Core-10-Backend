using Microsoft.AspNetCore.Mvc;
using YOMA.Models;
using YOMA.Models.Tables;

namespace YOMA.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TypePrimeController : ControllerBase
    {
        private readonly Context _context;
        private readonly TypePrimeService _typePrimeService;
        private readonly string Message = "Types de primes";

        public TypePrimeController(Context context, TypePrimeService typePrimeService)
        {
            _context = context;
            _typePrimeService = typePrimeService;
        }

        [HttpPost("CreateTypePrime")]
        public async Task<ActionResult<ApiResult>> CreateTypePrime([FromBody] TypePrime typePrime)
        {
            try
            {
                var createdTypePrime = await _typePrimeService.CreateTypePrimeAsync(typePrime);
                var customMessage = new ApiResult(Message, false, createdTypePrime);
                return Ok(new { 
                    Message = customMessage.Message,
                    IsError = customMessage.IsError,
                    Data = customMessage.Data 
                });
            }
            catch (Exception ex)
            {
                var customMessage = new ApiResult(Message, true, null);
                return BadRequest(new { 
                    Message = customMessage.Message,
                    IsError = customMessage.IsError,
                    Data = customMessage.Data,
                    ErrorDetails = ex.Message
                });
            }
        }


        [HttpGet("GetTypePrime/{id}")]
        public async Task<ActionResult<ApiResult>> GetTypePrime(int id)
        {
            var typePrime = await _typePrimeService.GetTypePrimeAsync(id);
            var customMessage = new ApiResult(Message, false, typePrime);
            return Ok(new { 
                Message = customMessage.Message,
                IsError = customMessage.IsError,
                Data = customMessage.Data 
            });
        }

        [HttpGet("GetTypePrimes")]
        public async Task<ActionResult<ApiResult>> GetTypePrimes()
        {
            var typePrimes = await _typePrimeService.GetTypePrimesAsync();
            var customMessage = new ApiResult(Message, false, typePrimes);
            return Ok(new { 
                Message = customMessage.Message,
                IsError = customMessage.IsError,
                Data = customMessage.Data 
            });
        }


        [HttpPut("UpdateTypePrime")]
        public async Task<ActionResult<ApiResult>> UpdateTypePrime([FromBody] TypePrime typePrime)
        {
            try
            {
                var updatedTypePrime = await _typePrimeService.UpdateTypePrimeAsync(typePrime);
                var customMessage = new ApiResult(Message, false, updatedTypePrime);
                return Ok(new { 
                    Message = customMessage.Message,
                    IsError = customMessage.IsError,
                    Data = customMessage.Data 
                });
            }
            catch (Exception ex)
            {
                var customMessage = new ApiResult(Message, true, null);
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