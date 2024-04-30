
using ApiBaseNetCore.Domain.Dtos;
using ApiBaseNetCore.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiBaseNetCore.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
      
        [Authorize]
        [HttpGet("GetAllUsers")]
        public ActionResult<List<UserDto>> GetAllUsers(){
            try
            {
                List<UserDto> users = _userService.GetUsers();
                return Ok(users);


            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
        }
    }
}