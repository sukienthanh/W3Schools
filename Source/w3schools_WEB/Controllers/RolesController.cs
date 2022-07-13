using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using w3schools_API.Models;
using w3schools_WEB.ApiCaller;
using w3schools_WEB.Helpers;
using w3schools_WEB.Models;

namespace w3schools_WEB.Controllers
{
    public class RolesController : Controller
    {
        private readonly Session sess;
        public RolesController(IOptionsSnapshot<ApiUrl> app)
        {
            ApplicationSettings.WebApiUrl = app.Value.WebApiBaseUrl;
            sess = new Session();
        }
        public IActionResult Index()
        {
            var curUser = sess.GetUserInfo(HttpContext);
            if (curUser.Role == "Administrator")
                return View();
            else if (!String.IsNullOrEmpty(curUser.Email))
                return RedirectToAction("Index", "Home");
            else
                return RedirectToAction("Login", "Auth");
        }        
        [HttpGet]
        public async Task<IActionResult> GetListRoles()
        {
            var curUser = sess.GetUserInfo(HttpContext);

            curUser.Token = await ApiClientFactory.Instance.RefeshToken(curUser);

            sess.SetUserInfo(curUser, HttpContext);

            var returns = await ApiClientFactory.Instance.getListRole(curUser.Token);
            return Json(returns);           
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBatchRoles([FromBody] IEnumerable<UpdateBatchData<Roles>> data)
        {
            var curUser = sess.GetUserInfo(HttpContext);

            if (curUser != null)
            {
                curUser.Token = await ApiClientFactory.Instance.RefeshToken(curUser);

                sess.SetUserInfo(curUser, HttpContext);
                var result = await ApiClientFactory.Instance.updateBatchRole(data, curUser.UserName,curUser.Token);
                return Json(result);
            }
            return null;            
        }
    }
}
