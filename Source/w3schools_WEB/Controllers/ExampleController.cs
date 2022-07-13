using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using w3schools_API.Models;
using w3schools_WEB.ApiCaller;
using w3schools_WEB.Helpers;

namespace w3schools_WEB.Controllers
{
    public class ExampleController : Controller
    {
        private readonly Session sess;
        public ExampleController(IOptionsSnapshot<ApiUrl> app /*,IOptionsSnapshot<AuthenInfo> authen*/)
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
        
        public async Task<IActionResult> ExampleView(int id= -1)
        {
            if(id != -1)
            {
                var filters = "(LessonContentId =" + id + ")";
                var curUser = sess.GetUserInfo(HttpContext);

                curUser.Token = await ApiClientFactory.Instance.RefeshToken(curUser);

                sess.SetUserInfo(curUser, HttpContext);

                var returns = await ApiClientFactory.Instance.getListExample(filters,curUser.Token);
                if(returns.Count == 1)
                    return View(returns[0]);                
            }
            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> GetListExample()
        {
            var curUser = sess.GetUserInfo(HttpContext);

            if (curUser != null)
            {
                curUser.Token = await ApiClientFactory.Instance.RefeshToken(curUser);

                sess.SetUserInfo(curUser, HttpContext);
                var returns = await ApiClientFactory.Instance.getListExample("",curUser.Token);
                return Json(returns);
            }
            return BadRequest("Request error");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBatchExample([FromBody] IEnumerable<UpdateBatchData<Example>> data)
        {
            var curUser = sess.GetUserInfo(HttpContext);

            if (curUser != null)
            {
                curUser.Token = await ApiClientFactory.Instance.RefeshToken(curUser);

                sess.SetUserInfo(curUser, HttpContext);
                var result = await ApiClientFactory.Instance.updateBatchExample(data, curUser.UserName, curUser.Token);
                return Json(result);
            }
            return BadRequest("Request error");
        }

    }
}
