using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using w3schools_WEB.ApiCaller;
using w3schools_WEB.Helpers;

namespace w3schools_WEB.Controllers
{
    public class AdminController : Controller
    {
        private readonly Session sess;
        public AdminController(IOptionsSnapshot<ApiUrl> app /*,IOptionsSnapshot<AuthenInfo> authen*/)
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
    }
}
