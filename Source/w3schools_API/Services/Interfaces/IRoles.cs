using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using w3schools_API.Models;

namespace w3schools_API.Services.Interfaces
{
    public interface IRoles
    {
        Task<IEnumerable<Roles>> GetList(string constr);
        Task<DataResults<IEnumerable<UpdateBatchData<Roles>>>> UpdateBatchMode(string constr, IEnumerable<UpdateBatchData<Roles>> data, string username = "");
    }
}
