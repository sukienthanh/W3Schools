using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using w3schools_API.Models;

namespace w3schools_API.Services.Interfaces
{
    public interface IAuth
    {
        Task<DataResults<UserInfo>> CheckLogin(string email, string password,string constr);
        Task<DataResults<UserInfo>> Signup(Users data,string constr);
    }
}
