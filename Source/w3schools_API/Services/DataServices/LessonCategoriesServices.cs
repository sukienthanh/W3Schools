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
    public class LessonCategoriesServices:ILessonCategories
    {
        private BaseServices basesvc;
        private readonly String table = "LessonCategories";
        public LessonCategoriesServices()
        {
            basesvc = new BaseServices();
        }

        public async Task<IEnumerable<LessonCategories>> GetList(string constr)
        {
            var result = await basesvc.GetList<LessonCategories>(table, constr);
            return result;
        }

        public async Task<DataResults<IEnumerable<UpdateBatchData<LessonCategories>>>> UpdateBatchMode(string constr, IEnumerable<UpdateBatchData<LessonCategories>> data, string username = "")
        {

            var result = new DataResults<IEnumerable<UpdateBatchData<LessonCategories>>>();

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
                                item.data.LessonCateName = item.data.LessonCateName is not null ? item.data.LessonCateName : item.key.LessonCateName;
                                

                                basesvc.CommonUpdate(item.data, username, "update");
                                object obj = new
                                {
                                    item.data.ModifiedBy,
                                    item.data.DateModified,
                                    item.data.LessonCateName,                                    
                                };
                                returns += await db.Query(table).Where("LessonCateId", item.key.LessonCateId).UpdateAsync(obj, transaction);

                            }
                            else if (item.type == "insert")
                            {
                                basesvc.CommonUpdate(item.data, username, "create");

                                object obj = new
                                {
                                    item.data.CreatedBy,
                                    item.data.DateCreated,
                                    item.data.LessonCateName                                    
                                };
                                returns += await db.Query(table).InsertAsync(obj, transaction);


                            }
                            else if (item.type == "remove")
                            {
                                returns += await db.Query(table).Where("LessonCateID", item.key.LessonCateId).DeleteAsync(transaction);
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
