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
    public class LessonsServices:ILessons
    {
        private BaseServices basesvc;
        private readonly String table = "Lessons";
        public LessonsServices()
        {
            basesvc = new BaseServices();
        }

        public async Task<IEnumerable<Lessons>> GetList(string constr)
        {
            var result = await basesvc.GetList<Lessons>(table, constr);
            return result;
        }        

        public async Task<DataResults<IEnumerable<UpdateBatchData<Lessons>>>> UpdateBatchMode(string constr, IEnumerable<UpdateBatchData<Lessons>> data, string username="")
        {

            var result = new DataResults<IEnumerable<UpdateBatchData<Lessons>>>();

            var returns = 0;

            try
            {
                using (var con = new SqlConnection(constr))
                {
                    var db = new QueryFactory(con, new SqlServerCompiler());
                    con.Open();

                    using (var transaction = con.BeginTransaction())
                    {
                        foreach (var item in data)
                        {
                            if (item.type == "update")
                            {
                                item.data.LessonName = item.data.LessonName is not null ? item.data.LessonName : item.key.LessonName;
                                item.data.LessonCateId = item.data.LessonCateId is not null ? item.data.LessonCateId : item.key.LessonCateId;                               
                                
                                basesvc.CommonUpdate(item.data, username, "update");
                                object obj = new
                                {
                                    item.data.ModifiedBy,
                                    item.data.DateModified,
                                    item.data.LessonName,
                                    item.data.LessonCateId,                                                                     
                                };
                                returns += await db.Query(table).Where("LessonId", item.key.LessonId).UpdateAsync(obj, transaction);

                            }
                            else if (item.type == "insert")
                            {
                                basesvc.CommonUpdate(item.data, username, "create");
                                
                                object obj = new
                                {
                                    item.data.CreatedBy,
                                    item.data.DateCreated,
                                    item.data.LessonName,
                                    item.data.LessonCateId,
                                };
                                returns += await db.Query(table).InsertAsync(obj, transaction);
                                

                            }
                            else if (item.type == "remove")
                            {
                                returns += await db.Query(table).Where("LessonId", item.key.LessonId).DeleteAsync(transaction);
                            }
                        }

                        if (returns == data.Count())
                        {
                            transaction.Commit();
                            result.Message = "Successful";
                            result.Status = 1;
                        }
                        else
                        {
                            result.Message = "Update data failed";
                            result.Status = -1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Data = data;
                result.Message = ex.ToString();
                result.Status = -1;
            }

            return result;
        }
    }
}
