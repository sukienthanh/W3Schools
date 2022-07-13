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
    public class UsersController : Controller
    {
        private readonly Session sess;
        public UsersController(IOptionsSnapshot<ApiUrl> app)
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
        public async Task<IActionResult> GetListUsers()
        {
            var curUser = sess.GetUserInfo(HttpContext);

            if (curUser != null)
            {
                curUser.Token = await ApiClientFactory.Instance.RefeshToken(curUser);

                sess.SetUserInfo(curUser, HttpContext);
               var returns = await ApiClientFactory.Instance.getListUser(curUser.Token);
                return Json(returns);
            }
            return null;
        }
        [HttpGet]
        public async Task<IActionResult> DeleteUsers(int id = -1)
        {
            if (ModelState.IsValid)
            {
                var curUser = sess.GetUserInfo(HttpContext);

                if (curUser != null)
                {
                    curUser.Token = await ApiClientFactory.Instance.RefeshToken(curUser);

                    sess.SetUserInfo(curUser, HttpContext);
                    var result = new DataResults<int>();
                    if (id != -1)
                    {
                        result = await ApiClientFactory.Instance.deleteUser(id, curUser.Token);
                        return Json(result);
                    }
                }
                return null;
            }
            return BadRequest("Request error");
        }
        [HttpPost]
        public async Task<IActionResult> InsertUsers([FromBody]Users data)
        {

            if (ModelState.IsValid)
            {
                var curUser = sess.GetUserInfo(HttpContext);

                if (curUser != null)
                {
                    curUser.Token = await ApiClientFactory.Instance.RefeshToken(curUser);

                    sess.SetUserInfo(curUser, HttpContext);
                    var result = new DataResults<Users>();
                    result = await ApiClientFactory.Instance.insertUser(data, curUser.UserName, curUser.Token);
                    return Json(result);
                }
                return null;  
            }
            return BadRequest("Request error");
        }
    }
}
