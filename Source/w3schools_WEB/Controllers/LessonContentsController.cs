using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using w3schools.Models;
using w3schools_API.Models;
using w3schools_WEB.ApiCaller;
using w3schools_WEB.Helpers;
using w3schools_WEB.Models;

namespace w3schools.Controllers
{
    public class LessonContentsController : Controller
    {
        private readonly Session sess;
        public LessonContentsController(IOptionsSnapshot<ApiUrl> app /*,IOptionsSnapshot<AuthenInfo> authen*/)
        {
            ApplicationSettings.WebApiUrl = app.Value.WebApiBaseUrl;
            sess = new Session();
        }

        public IActionResult Index(string contentType)
        {
            var curUser = sess.GetUserInfo(HttpContext);
            if (curUser.Role == "Administrator")
                return View();
            else if (!String.IsNullOrEmpty(curUser.Email))
                return RedirectToAction("Index", "Home");
            else 
                return RedirectToAction("Login", "Auth");
        }

        public async Task<IActionResult> AddEditLessonContentsView(string method,int id = -1,int order=-1)
        {
            if (ModelState.IsValid)
            {
                var curUser = sess.GetUserInfo(HttpContext);

                if (curUser != null)
                {
                    curUser.Token = await ApiClientFactory.Instance.RefeshToken(curUser);

                    sess.SetUserInfo(curUser, HttpContext);
                    var model = new LessonContents();
                    if (id != -1)
                    {
                        model = await ApiClientFactory.Instance.GetLessonContentById(id, curUser.Token);                        
                    }
                    ViewBag.Method = method;
                    ViewBag.RowOrder = order;
                    return View(model);
                }                               
            }
            return BadRequest("Request error");
        }

        [HttpGet]
        public async Task<IActionResult> GetListLessContent(bool filt= false)
        {
            var curUser = sess.GetUserInfo(HttpContext);
            if (curUser != null)
            {
                UserInfo info = new UserInfo("DefaultSessionForNotLoginUsers", "", "");
                curUser = sess.SetUserInfo(info, HttpContext) ? sess.GetUserInfo(HttpContext) : curUser;
                var filters = filt ? "(ContentTypeId =" + (int)ContentTypeEnum.Example + ")" : "";
                curUser.Token = await ApiClientFactory.Instance.RefeshToken(curUser);

                sess.SetUserInfo(curUser, HttpContext);

                var returns = await ApiClientFactory.Instance.GetListLessonContents(filters, curUser.Token);
                return Json(returns);
            }
            return BadRequest("Request error");
        }

        [HttpPost]
        public async Task<IActionResult> AddEditLessonContentsMethod([FromQuery]string method, [FromBody] LessonContents obj)
        {
            if (ModelState.IsValid)
            {
                var curUser = sess.GetUserInfo(HttpContext);

                if (curUser != null)
                {
                    curUser.Token = await ApiClientFactory.Instance.RefeshToken(curUser);

                    sess.SetUserInfo(curUser, HttpContext);
                    var result = new Message<DataResults<LessonContents>>();
                    if (method == "edit")
                        result = await ApiClientFactory.Instance.UpdateLessonContent(obj, curUser.Token);
                    else if (method == "insert")
                        result = await ApiClientFactory.Instance.InsertLessonContent(obj, curUser.Token);

                    return Json(result);
                }                
            }
            return BadRequest("Request error");
        } 
        public async Task<IActionResult> DeleteLessonContent(int id =-1)
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
                        result = await ApiClientFactory.Instance.DeleteLessonContent(id, curUser.Token);
                        return Json(result);
                    }
                }                           
            }
            return BadRequest("Request error");
        }
    }    
}
