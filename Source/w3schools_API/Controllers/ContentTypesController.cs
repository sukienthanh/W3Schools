﻿using Microsoft.AspNetCore.Authorization;
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
    
    public class ContentTypesController : ControllerBase
    {
        private IContentTypes services;
        private string constr;
        public ContentTypesController(IConfiguration config, IContentTypes services)
        {
            this.services = services;
            constr = config.GetConnectionString("CN");
        }        
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetList()
        {
            var results = await services.GetList(constr);
            return Ok(results);
        }
        
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Update(IEnumerable<UpdateBatchData<ContentTypes>> data, string username = "admin")
        {
            var result = await services.UpdateBatchMode(constr, data, username);
            return Ok(result);
        }
    }
}
