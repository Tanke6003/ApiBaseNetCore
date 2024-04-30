
using Microsoft.AspNetCore.Mvc;
using ApiBaseNetCore.Infrastructure.Interfaces;
using ApiBaseNetCore.Infrastructure.Plugins;
using ApiBaseNetCore.Infrastructure.Interfaces.plugins;
using ApiBaseNetCore.Domain.Interfaces.Services;
using ApiBaseNetCore.Domain.Dtos;

namespace ApiBaseNetCore.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        IEncrypt _encrypt;
        IAuthService _authService;
        public TestController(IEncrypt encrypt, IAuthService authService)
        {
            _encrypt = encrypt;
            _authService = authService;
        }

        [HttpGet("Encrypt")]
        public ActionResult Encrypt(string data)
        {
            try
            {
                string result = _encrypt.Encrypt(data);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("Decrypt")]
        public ActionResult Decrypt(string data)
        {
            try
            {
                string result = _encrypt.Decrypt(data);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("CreateToken")]
        public ActionResult CreateToken()
        {
            try
            {
                string result = "";
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("Login")]
        public ActionResult Login(string username, string password)
        {
            try
            {
               
                string result = _authService.Login(username, password, out string exceptionMessage);
                if(exceptionMessage != "")
                    return BadRequest(exceptionMessage);
                if (result == null)
                    return BadRequest(exceptionMessage);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }


}