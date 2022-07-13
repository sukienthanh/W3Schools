using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using w3schools_API.Models;

namespace w3schools_API.Services.Interfaces
{
    public interface ILessonContents
    {
        Task<IEnumerable<LessonContents>> GetList(string constr, string filters);
        Task<LessonContents> GetById(string constr, int id);
        Task<DataResults<object>> Insert(LessonContents data, string constr);
        Task<DataResults<int>> Delete(string constr, int id);
        Task<DataResults<object>> Update(LessonContents data, string constr);
    }
}
