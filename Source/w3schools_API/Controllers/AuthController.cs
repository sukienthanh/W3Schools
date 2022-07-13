using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using w3schools_API.Models;
using w3schools_API.Services.Interfaces;

namespace w3schools_API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public IAuth ser;
        private readonly string constr;
        public AuthController(IAuth ser, IConfiguration config)
        {
            this.ser = ser;
            constr = config.GetConnectionString("CN");
        }
        [HttpPost]
        public async Task<IActionResult> CheckLogin(Users u)
        {
            if (string.IsNullOrEmpty(u.Email))
            {
                ModelState.AddModelError("Email", "Email is required");
            }

            if (string.IsNullOrEmpty(u.PassWord))
            {
                ModelState.AddModelError("PassWord", "PassWord is required");
            }

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var rs = await ser.CheckLogin(u.Email, u.PassWord,constr);

            return Ok(rs);
        }
        [HttpPost]
        public async Task<IActionResult> Signup(Users data)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);                      
            var rs = await ser.Signup(data, constr);          
            return Ok(rs);
        }
    }
}
