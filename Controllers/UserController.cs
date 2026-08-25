using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YOMA.Helpers;
using YOMA.Models;
using YOMA.Models.Tables;

namespace YOMA.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly Context _context;
        private readonly string Message = "Les modifications ont été enregistrées";

        public UserController(Context context)
        {
            _context = context;
        }

        [HttpPost("updateFramer")]
        public async Task<ActionResult<ApiResult>> UpdateFramer([FromBody] User user)
        {
            try
            {
                var selectedUser = await _context.Users.FirstOrDefaultAsync(x => x.ID == user.ID);
                if(selectedUser != null)
                {
                    user.PASSWORD = selectedUser.PASSWORD;
                    _context.Entry(selectedUser).CurrentValues.SetValues(user);
                    await _context.SaveChangesAsync();

                    var apiResult = new ApiResult(Message, false, user);
                    return Ok(new {
                        Message = apiResult.Message,
                        IsError = apiResult.IsError,
                        Data = apiResult.Data
                    });
                }

                var emptyResult = new ApiResult("Aucun utilisateur trouvé dans notre base de donnée", true, null);
                return BadRequest(new {
                    Message = emptyResult.Message,
                    IsError = emptyResult.IsError,
                    Data = emptyResult.Data,
                });
            }
            catch (Exception ex)
            {
                var apiResult = new ApiResult("Une erreur s'est produite au niveau du serveur", true, null);
                return BadRequest(new {
                    Message = apiResult.Message,
                    IsError = apiResult.IsError,
                    Data = apiResult.Data,
                    ErrorDetails = ex.Message
                });
            }
        }
        
        [HttpPost("updateStudent")]
        public async Task<ActionResult<ApiResult>> UpdateStudent([FromBody] Student student)
        {
            try
            {
                var selectedUser = await _context.Students.FirstOrDefaultAsync(x => x.ID == student.ID);
                if(selectedUser != null)
                {
                    student.PASSWORD = selectedUser.PASSWORD;
                    _context.Entry(selectedUser).CurrentValues.SetValues(student);
                    await _context.SaveChangesAsync();

                    var apiResult = new ApiResult(Message, false, student);
                    return Ok(new {
                        Message = apiResult.Message,
                        IsError = apiResult.IsError,
                        Data = apiResult.Data
                    });
                }

                var emptyResult = new ApiResult("Aucun utilisateur trouvé dans notre base de donnée", true, null);
                return BadRequest(new {
                    Message = emptyResult.Message,
                    IsError = emptyResult.IsError,
                    Data = emptyResult.Data,
                });
            }
            catch (Exception ex)
            {
                var apiResult = new ApiResult("Une erreur s'est produite au niveau du serveur", true, null);
                return BadRequest(new {
                    Message = apiResult.Message,
                    IsError = apiResult.IsError,
                    Data = apiResult.Data,
                    ErrorDetails = ex.Message
                });
            }
        }
        
        [HttpPost("updateParent")]
        public async Task<ActionResult<ApiResult>> UpdateParent([FromBody] Parent parent)
        {
            try
            {
                var selectedUser = await _context.Parents.FirstOrDefaultAsync(x => x.ID == parent.ID);
                if(selectedUser != null)
                {
                    parent.PASSWORD = selectedUser.PASSWORD;
                    _context.Entry(selectedUser).CurrentValues.SetValues(parent);
                    await _context.SaveChangesAsync();

                    var apiResult = new ApiResult(Message, false, parent);
                    return Ok(new {
                        Message = apiResult.Message,
                        IsError = apiResult.IsError,
                        Data = apiResult.Data
                    });
                }

                var emptyResult = new ApiResult("Aucun utilisateur trouvé dans notre base de donnée", true, null);
                return BadRequest(new {
                    Message = emptyResult.Message,
                    IsError = emptyResult.IsError,
                    Data = emptyResult.Data,
                });
            }
            catch (Exception ex)
            {
                var apiResult = new ApiResult("Une erreur s'est produite au niveau du serveur", true, null);
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