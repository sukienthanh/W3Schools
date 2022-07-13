using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
    public class UsersController : Controller
    {
        private IUsers services;
        private string constr;
        public UsersController(IConfiguration config, IUsers services)
        {
            this.services = services;
            constr = config.GetConnectionString("CN");
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var results = await services.GetList(constr);
            return Ok(results);
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var results = await services.Delete(constr, id);
            return Ok(results);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Update(Users data, string username = "")
        {

            var results = await services.Update(data, constr);
            return Ok(results);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Insert(Users data, string username = "")
        {
            var results = await services.Insert(data, constr);
            return Ok(results);
        }
    }
}
