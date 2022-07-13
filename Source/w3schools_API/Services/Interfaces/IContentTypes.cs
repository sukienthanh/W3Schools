using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using w3schools_API.Models;

namespace w3schools_API.Services.Interfaces
{
    public interface IContentTypes
    {
        Task<IEnumerable<ContentTypes>> GetList(string constr);
        Task<DataResults<IEnumerable<UpdateBatchData<ContentTypes>>>> UpdateBatchMode(string constr, IEnumerable<UpdateBatchData<ContentTypes>> data, string username);
    }
}
