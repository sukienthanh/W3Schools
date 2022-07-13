using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using w3schools_API.Models;

namespace w3schools_API.Services.Interfaces
{
    public interface ILessons
    {
        Task<IEnumerable<Lessons>> GetList(string constr);
        Task<DataResults<IEnumerable<UpdateBatchData<Lessons>>>> UpdateBatchMode(string constr, IEnumerable<UpdateBatchData<Lessons>> data, string username="");
    }
}
