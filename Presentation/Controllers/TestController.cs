using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Infractructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
    }   
}