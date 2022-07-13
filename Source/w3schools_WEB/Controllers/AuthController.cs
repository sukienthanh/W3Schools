using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using w3schools_API.Models;
using w3schools_WEB.ApiCaller;
using w3schools_WEB.Helpers;

namespace w3schools_WEB.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginMethod(Users data)
        {
            if (data != null)
            {
                var rt = new DataResults<UserInfo>();                
                if (String.IsNullOrEmpty(data.Email))
                {
                    rt.Message += "Email is required!";
                }
                else
                {
                    data.Email = data.Email.ToLower().Trim();
                    string emailRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                        @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                        @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
                    Regex re = new Regex(emailRegex);
                    if (!re.IsMatch(data.Email))                    
                        rt.Message += "Email is not valid!";                    
                }
                if (String.IsNullOrEmpty(data.PassWord))
                {
                    rt.Message += "Password is required!";
                }               
                if (!String.IsNullOrEmpty(rt.Message))
                    return Ok(rt);
            }

            var rs = await ApiClientFactory.Instance.checkLogin(data);

            if (rs.Status == 1)
            {
                var session = HttpContext.Session;

                var obj = new UserInfo();
                obj = rs.Data;

                var memoryCache = new Session();
                memoryCache.AddSection(session, obj);
            }
            return Ok(rs);
        }        
        public  IActionResult Signout()
        {
            var sess = new Session();
            var curUser = sess.GetUserInfo(HttpContext);

            if (curUser != null)
            {                
                var session = HttpContext.Session;
                sess.ClearSection(session);                
            }
            return View("Login");
        }

        [HttpGet]
        public IActionResult SignoutWithAjax()
        {
            var rt = new DataResults<int>();
            var sess = new Session();
            var curUser = sess.GetUserInfo(HttpContext);

            if (curUser != null)
            {
                var session = HttpContext.Session;
                sess.ClearSection(session);
                rt.Message = "Successfuly";
                rt.Status = 1;
            }
            else
            {
                rt.Message = "Failed";
                rt.Status = -1;
            }
            return Ok(rt);
        }

        [HttpPost]
        public async Task<IActionResult> SignupMethod(SingupModel data)
        {
            if (data != null)
            {
                var rt = new DataResults<UserInfo>();
                if (String.IsNullOrEmpty(data.UserName))
                {
                    rt.Message = "Username is required!";
                }
                if (String.IsNullOrEmpty(data.Email))
                {
                    rt.Message += "Email is required!";
                }
                else
                {
                    data.Email = data.Email.ToLower().Trim();
                    string emailRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                        @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                        @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
                    Regex re = new Regex(emailRegex);
                    if (!re.IsMatch(data.Email))
                    {
                        rt.Message += "Email is not valid!";
                    }
                }
                if(String.IsNullOrEmpty(data.PassWord) || String.IsNullOrEmpty(data.RePassWord))
                {
                    rt.Message += "Password and Re-enter Password is required!";
                }
                else if(data.PassWord != data.RePassWord) {
                    rt.Message += "Re-enter password is not match!";
                }
                else
                {
                    data.PassWord = data.PassWord.Trim();
                    var hasNumber = new Regex(@"[0-9]+");
                    var hasUpperChar = new Regex(@"[A-Z]+");
                    var hasMinimum8Chars = new Regex(@".{8,}");

                    var isValidated = hasNumber.IsMatch(data.PassWord) && hasUpperChar.IsMatch(data.PassWord) && hasMinimum8Chars.IsMatch(data.PassWord);
                    if (!isValidated)
                    {
                        rt.Message += "Password must contain numbers, uppercase letters and be at least 8 characters long!";
                    }
                }
                if (!String.IsNullOrEmpty(rt.Message))
                    return Ok(rt);
            }
            data.RoleId = 2;
            var rs = await ApiClientFactory.Instance.signup(data);

            if (rs.Status == 1)
            {
                var session = HttpContext.Session;

                var obj = new UserInfo();
                obj = rs.Data;

                var memoryCache = new Session();
                memoryCache.AddSection(session, obj);
            }
            return Ok(rs);
        }
    }
}
