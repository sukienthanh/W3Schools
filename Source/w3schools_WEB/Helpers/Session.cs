using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using w3schools_API.Models;

namespace w3schools_WEB.Helpers
{
    public class Session
    {
        const string key = "get_session";

        public void AddSection(ISession session, UserInfo data)
        {
            session.SetString(key, JsonSerializer.Serialize(data, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            }));
        }

        public  object GetSection<T>(ISession session)
        {
            string json = session.GetString(key);
            return JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
        }
        public void ClearSection(ISession session)
        {
            session.Remove(key);
        }
        public bool SetUserInfo(object obj, HttpContext context)
        {
            if (obj != null)
            {
                try
                {
                    var session = context.Session;                    
                    session.SetString(key,JsonSerializer.Serialize(obj , new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    }));
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return false;
        }

        public UserInfo GetUserInfo(HttpContext context)
        {
            var curUser = new UserInfo();
            if (context != null)
            {
                var session = context.Session;                

                string json = session.GetString(key);
                
                if (json != null)
                {
                    curUser = JsonSerializer.Deserialize<UserInfo>(json, new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    });                    
                }                
            }
            return curUser;
        }
    }
}
