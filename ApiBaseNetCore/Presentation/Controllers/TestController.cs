using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ApiBaseNetCore.Infrastructure.Interfaces;
using ApiBaseNetCore.Infrastructure.Plugins;
using ApiBaseNetCore.Infrastructure.Interfaces.plugins;

namespace ApiBaseNetCore.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        IEncrypt _encrypt;
        public TestController(IEncrypt encrypt)
        {
            _encrypt = encrypt;
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
                IEnvs _envs = new Envs();
                IJwt _jwt = new JWTPlugin();
                string result = _jwt.GenerateToken(new Domain.Dtos.JWTOptionsDto
                {
                    UserId = 1,
                    NTUser = "NTUser",
                    RoleId = 1,
                    ExpireDate = DateTime.Now.AddHours(1),
                    SecretKey = _envs.GetEnv("SecretKey")
                });
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }


}