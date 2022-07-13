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
    public class AuthServices:IAuth
    {
        private readonly IUsers userSv;
        public AuthServices(IUsers userSv)
        {
            this.userSv = userSv;
        }
        public async Task<DataResults<UserInfo>> CheckLogin(string email, string password, string constr)
        {
            var dataReturn = new DataResults<UserInfo>();
            try
            {
                using (var con = new SqlConnection(constr))
                {


                    var db = new QueryFactory(con, new SqlServerCompiler());

                    //var rs = (await db.Query("Users").Where("Email", email).GetAsync<Users>()).FirstOrDefault();
                    var enumData = await
                        db.Query("Users")
                        .Select(
                            "UserName",
                            "Email",
                            "PassWord",
                            "Roles.RoleName as Role"
                        )
                        .Join("Roles", "Users.RoleId", "Roles.RoleId")
                        .Where("Users.Email", email)
                        .GetAsync<UserInfo>();
                    var rs = enumData.Count() > 0 ? enumData.ElementAt(0) : null;

                    if (rs is not null)
                    {
                        bool validPassword = BCrypt.Net.BCrypt.Verify(password, rs.PassWord);
                        //bool validPassword = rs.PassWord == password;
                        if (validPassword)
                        {
                            dataReturn.Data = rs;
                            dataReturn.Status = 1;
                            dataReturn.Message = "Successfully";
                        }
                        else
                        {
                            dataReturn.Data = rs;
                            dataReturn.Status = 0;
                            dataReturn.Message = "Wrong password";
                        }
                    }
                    else 
                    {
                        dataReturn.Status = 0;
                        dataReturn.Message = "Your account does not exist";
                    }
                }
            }
            catch (Exception ex)
            {
                dataReturn.Status = -1;
                dataReturn.Message = ex.ToString();
            }
            return dataReturn;
        }
        public async Task<DataResults<UserInfo>> Signup(Users data, string constr)
        {
            var dataReturn = new DataResults<UserInfo>();
            try
            {
                using (var con = new SqlConnection(constr))
                {
                    var db = new QueryFactory(con, new SqlServerCompiler());
                    var enumData = await
                        db.Query("Users")
                        .Select(
                            "Users.UserName",
                            "Users.Email",
                            "Roles.RoleName as Role"
                        )
                        .Join("Roles", "Users.RoleId", "Roles.RoleId")
                        .Where("Users.Email", data.Email)
                        .GetAsync<UserInfo>();
                    var checkExisted = enumData.Count() > 0 ? enumData.ElementAt(0) : null;     
                        
                    //var checkExisted = await db.Query("Users").Where("Email", data.Email).GetAsync<UserInfo>();
                    
                    if (checkExisted == null)
                    {
                        //data.PassWord = BCrypt.Net.BCrypt.HashPassword(data.PassWord);
                        var rs = await userSv.Insert(data, constr);
                        if (rs.Status == 1) {
                            enumData = await
                            db.Query("Users")
                            .Select(
                                "Users.UserName",
                                "Users.Email",
                                "Roles.RoleName as Role"
                            )
                            .Join("Roles", "Users.RoleId", "Roles.RoleId")
                            .Where("Users.Email", data.Email)
                            .GetAsync<UserInfo>();
                            checkExisted = enumData.Count() > 0 ? enumData.ElementAt(0) : null;
                            dataReturn.Data = checkExisted;
                            dataReturn.Status = 1;
                            dataReturn.Message = "Successfully";
                        }
                    }
                    else
                    {
                        dataReturn.Status = 0;
                        dataReturn.Message = "Your account already exist";
                    }
                }
            }
            catch (Exception ex)
            {
                dataReturn.Status = -1;
                dataReturn.Message = ex.ToString();
            }
            return dataReturn;
        }
    }
}
