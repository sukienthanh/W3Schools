using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using w3schools_API.Models;

namespace w3schools_API.Services.Interfaces
{
    public interface IUsers
    {
        Task<IEnumerable<Users>> GetList(string constr);
        Task<DataResults<object>> Insert(Users data, string constr);
        Task<DataResults<object>> Update(Users data, string constr);
        Task<DataResults<int>> Delete(string constr, int id);
    }
}
