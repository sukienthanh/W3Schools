using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using w3schools_API.Models;
using w3schools_API.Services.Interfaces;

namespace w3schools_API.Services.DataServices
{
    public class UsersServices : IUsers
    {
        private BaseServices basesvc;
        private readonly String table = "Users";
        public UsersServices()
        {
            basesvc = new BaseServices();
        }

        public async Task<IEnumerable<Users>> GetList(string constr)
        {
            var result = await basesvc.GetList<Users>(table, constr);
            return result;
        }
        public async Task<DataResults<object>> Insert(Users data, string constr)
        {
            basesvc.CommonUpdate(data, "admin", "create", (int)data.RoleId);
            data.PassWord = BCrypt.Net.BCrypt.HashPassword(data.PassWord);
            object obj = new
            {
                data.UserName,
                data.Email,
                data.PassWord,
                data.RoleId,                                
                data.DateCreated,
                data.CreatedBy,
            };
            var result = await basesvc.Insert<object>(table, obj, constr);
            return result;
        }        
        public async Task<DataResults<int>> Delete(string constr, int id)
        {
            var result = await basesvc.Delete(table, constr, "UserId", id);
            return result;
        }
        public async Task<DataResults<object>> Update(Users data, string constr)
        {
            basesvc.CommonUpdate(data, "admin", "update",(int)data.RoleId);
            object obj = new
            {
                data.UserName,
                data.PassWord,
                data.RoleId,
                data.Email,                
                data.DateModified,
                data.ModifiedBy,
            };
            var result = await basesvc.Update(table, obj, constr, "UserId",(int)data.UserId);
            return result;
        }

    }
}
