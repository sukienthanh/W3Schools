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
    public class HomeController : Controller
    {
        private readonly Session sess;
        public HomeController(IOptionsSnapshot<ApiUrl> app)
        {
            ApplicationSettings.WebApiUrl = app.Value.WebApiBaseUrl;
            sess = new Session();
        }
        public IActionResult Index()
        {
            var curUser = sess.GetUserInfo(HttpContext);
            ViewBag.Username = curUser.UserName;
            return View();                   
        }
        public async Task<IActionResult> RenderContents(int id = -1)
        {
            var curUser = sess.GetUserInfo(HttpContext);

            curUser.Token = await ApiClientFactory.Instance.RefeshToken(curUser);

            sess.SetUserInfo(curUser, HttpContext);

            string filters = null;
            if (id != -1)
            {
                //( ContentType = N'Video' ) 
                filters = "(LessonId =" + id + ")";
            }
            if (ModelState.IsValid)
            {
                var model = new List<LessonContents>();
                if (id != -1)
                {
                    model = await ApiClientFactory.Instance.GetListLessonContents(filters, "");
                }

                return Json(model);
            }
            return BadRequest("Request Error");
        }    
    }
}
