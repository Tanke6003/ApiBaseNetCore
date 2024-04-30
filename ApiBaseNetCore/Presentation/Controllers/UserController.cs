using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
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
        public ActionResult<List<Domain.Dtos.UserDto>> GetAllUsers(){
            try
            {
                List<Domain.Dtos.UserDto> users = _userService.GetUsers();
                return Ok(users);


            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
        }
    }
}