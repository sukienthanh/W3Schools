using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using w3schools_API.Models;

namespace w3schools_API.Services.Interfaces
{
    public interface IExample
    {
        Task<IEnumerable<Example>> GetList(string constr,string filters="");
        Task<DataResults<IEnumerable<UpdateBatchData<Example>>>> UpdateBatchMode(string constr, IEnumerable<UpdateBatchData<Example>> data, string username = "");
    }
}
