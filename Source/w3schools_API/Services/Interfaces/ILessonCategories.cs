using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using w3schools_API.Models;

namespace w3schools_API.Services.Interfaces
{
    public interface ILessonCategories
    {
        Task<IEnumerable<LessonCategories>> GetList(string constr);
        Task<DataResults<IEnumerable<UpdateBatchData<LessonCategories>>>> UpdateBatchMode(string constr, IEnumerable<UpdateBatchData<LessonCategories>> data, string username = "");
    }
}
