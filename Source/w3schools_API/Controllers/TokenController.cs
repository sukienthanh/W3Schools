using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using w3schools_API.Helpers;
using w3schools_API.Models;
using w3schools_API.Services.Interfaces;

namespace w3schools_API.Controllers
{
    [Produces("application/json")]
    [Route("[controller]/[action]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IAuth auth;

        public TokenController(IConfiguration config, IAuth auth)
        {
            _config = config;
            this.auth = auth;
        }

        [HttpGet]
        public IActionResult GetToken( string u,string p )
        {
            string accessToken = "Bearer ";
            //string accessToken="";

            int expiresTime = _config.GetValue<int>("AuthorizeSettings:expires");

            if (CheckLogin(u,p))
            {
                var token = new Token();                
                accessToken += token.GenerateJsonWebToken(u,_config, expiresTime);

            }

            return Ok(accessToken);
        }
        [Authorize]
        [HttpGet]        
        public IActionResult CheckToken()
        {
            return Ok();
        }

        [NonAction]
        public bool CheckLogin(string name, string pw)
        {
            var accessName = _config.GetValue<string>("AuthorizeSettings:username");
            var accessPass = _config.GetValue<string>("AuthorizeSettings:password");

            if (name == accessName && pw == accessPass)
                return true;
            return false;
        }

    }
}
