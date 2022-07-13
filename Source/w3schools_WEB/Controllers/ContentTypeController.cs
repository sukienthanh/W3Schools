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
    public class ContentTypeController : Controller
    {
        private readonly Session sess;
        public ContentTypeController(IOptionsSnapshot<ApiUrl> app)
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
        public async Task<IActionResult> GetListContentType()
        {
            var curUser = sess.GetUserInfo(HttpContext);

            if (curUser != null)
            {
                curUser.Token = await ApiClientFactory.Instance.RefeshToken(curUser);

                sess.SetUserInfo(curUser, HttpContext);
                var returns = await ApiClientFactory.Instance.getListContentType(curUser.Token);
                return Json(returns);
            }
            return BadRequest("Request error");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBatchContentType([FromBody] IEnumerable<UpdateBatchData<ContentTypes>> data)
        {
            var curUser = sess.GetUserInfo(HttpContext);

            if (curUser != null)
            {
                curUser.Token = await ApiClientFactory.Instance.RefeshToken(curUser);

                sess.SetUserInfo(curUser, HttpContext);
                var result = await ApiClientFactory.Instance.updateBatchContentType(data, curUser.UserName, curUser.Token);
                return Json(result);
            }
            return BadRequest("Request error");  
        }
    }
}
