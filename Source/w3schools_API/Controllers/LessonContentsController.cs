using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    public class LessonContentsController : ControllerBase
    {
        private ILessonContents services;
        private string constr;
        public LessonContentsController(IConfiguration config, ILessonContents services)
        {
            this.services = services;
            constr = config.GetConnectionString("CN");
        }
        
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetList(string filters)
        {
            var results = await services.GetList(constr,filters);
            return Ok(results);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var results = await services.GetById(constr,id);
            return Ok(results);
        }
        
        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var results = await services.Delete(constr, id);
            return Ok(results);
        }
        
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Update(LessonContents data)
        {
            
            var results = await services.Update(data,constr);
            return Ok(results);
        }
        
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Insert(LessonContents data)
        {
            var results = await services.Insert(data,constr);
            return Ok(results);
        }
    }
}
