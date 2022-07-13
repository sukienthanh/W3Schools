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
    public class LessonController : Controller
    {
        private readonly Session sess;
        public LessonController(IOptionsSnapshot<ApiUrl> app)
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
        public async Task<IActionResult> GetListLesson()
        {            
            var curUser= sess.GetUserInfo(HttpContext);
            if (curUser != null)
            {
                UserInfo info = new UserInfo("User", "", "");
                curUser = sess.SetUserInfo(info, HttpContext) ? sess.GetUserInfo(HttpContext) : curUser;
                curUser.Token = await ApiClientFactory.Instance.RefeshToken(curUser);

                sess.SetUserInfo(curUser, HttpContext);

                var returns = await ApiClientFactory.Instance.getListLesson(curUser.Token);
                return Json(returns);
            }
            return BadRequest();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBatchLesson([FromBody]IEnumerable<UpdateBatchData<Lessons>> data)
        {
            var curUser = sess.GetUserInfo(HttpContext);

            if (curUser != null)
            {               
                curUser.Token = await ApiClientFactory.Instance.RefeshToken(curUser);

                sess.SetUserInfo(curUser, HttpContext);
                var result = await ApiClientFactory.Instance.updateBatchLesson(data, curUser.UserName, curUser.Token);
                return Json(result);
            }
            return BadRequest("Request error");
        }
    }
}
