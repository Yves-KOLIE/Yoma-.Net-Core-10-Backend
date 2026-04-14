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
                var apiResult = new ApiResult(Message, false, createdTypePrime);
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

        [HttpGet("GetTypePrime/{id}")]
        public async Task<ActionResult<ApiResult>> GetTypePrime(int id)
        {
            var typePrime = await _typePrimeService.GetTypePrimeAsync(id);
            var apiResult = new ApiResult(Message, false, typePrime);
            return Ok(new { 
                Message = apiResult.Message,
                IsError = apiResult.IsError,
                Data = apiResult.Data 
            });
        }

        [HttpGet("GetTypePrimes")]
        public async Task<ActionResult<ApiResult>> GetTypePrimes()
        {
            var typePrimes = await _typePrimeService.GetTypePrimesAsync();
            var apiResult = new ApiResult(Message, false, typePrimes);
            return Ok(new { 
                Message = apiResult.Message,
                IsError = apiResult.IsError,
                Data = apiResult.Data 
            });
        }

        [HttpPut("UpdateTypePrime")]
        public async Task<ActionResult<ApiResult>> UpdateTypePrime([FromBody] TypePrime typePrime)
        {
            try
            {
                var updatedTypePrime = await _typePrimeService.UpdateTypePrimeAsync(typePrime);
                var apiResult = new ApiResult(Message, false, updatedTypePrime);
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

        [HttpPut("BatchUpdateTypePrimes")]
        public async Task<ActionResult<ApiResult>> BatchUpdateTypePrimes([FromBody] List<TypePrime> typePrimes)
        {
            try
            {
                var updatedTypePrimes = await _typePrimeService.BatchUpdateTypePrimesAsync(typePrimes);
                var apiResult = new ApiResult(Message, false, updatedTypePrimes);
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