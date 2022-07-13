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
    public class ExampleServices : IExample
    {
        private BaseServices basesvc;
        private readonly String table = "Example";
        public ExampleServices()
        {
            basesvc = new BaseServices();
        }

        public async Task<IEnumerable<Example>> GetList(string constr,string filters="")
        {
            var result = await basesvc.GetList<Example>(table, constr,filters);
            return result;
        }

        public async Task<DataResults<IEnumerable<UpdateBatchData<Example>>>> UpdateBatchMode(string constr, IEnumerable<UpdateBatchData<Example>> data, string username = "")
        {

            var result = new DataResults<IEnumerable<UpdateBatchData<Example>>>();

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
                                item.data.Content = item.data.Content is not null ? item.data.Content : item.key.Content;
                                item.data.LessonContentId = item.data.LessonContentId is not null ? item.data.LessonContentId : item.key.LessonContentId;


                                basesvc.CommonUpdate(item.data, username, "update");
                                object obj = new
                                {
                                    item.data.ModifiedBy,
                                    item.data.DateModified,
                                    item.data.Content,
                                    item.data.LessonContentId,
                                };
                                returns += await db.Query(table).Where("ExampleId", item.key.ExampleId).UpdateAsync(obj, transaction);

                            }
                            else if (item.type == "insert")
                            {
                                basesvc.CommonUpdate(item.data, username, "create");

                                object obj = new
                                {
                                    item.data.CreatedBy,
                                    item.data.DateCreated,
                                    item.data.Content,
                                    item.data.LessonContentId,
                                };
                                returns += await db.Query(table).InsertAsync(obj, transaction);


                            }
                            else if (item.type == "remove")
                            {
                                returns += await db.Query(table).Where("ExampleId", item.key.ExampleId).DeleteAsync(transaction);
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
