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
    public class ContentTypesServices: IContentTypes
    {
        private BaseServices basesvc;
        private readonly String table = "ContentTypes";
        public ContentTypesServices()
        {
            basesvc = new BaseServices();
        }

        public async Task<IEnumerable<ContentTypes>> GetList(string constr)
        {
            var result = await basesvc.GetList<ContentTypes>(table, constr);
            return result;
        }
        public async Task<DataResults<IEnumerable<UpdateBatchData<ContentTypes>>>> UpdateBatchMode(string constr, IEnumerable<UpdateBatchData<ContentTypes>> data, string username)
        {

            var result = new DataResults<IEnumerable<UpdateBatchData<ContentTypes>>>();

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
                                item.data.ContentTypeId = item.data.ContentTypeId is not null ? item.data.ContentTypeId : item.key.ContentTypeId;
                                item.data.ContentTypeName = item.data.ContentTypeName is not null ? item.data.ContentTypeName : item.key.ContentTypeName;                               
                                if (item.key.ContentTypeId != item.data.ContentTypeId)
                                {
                                    var isExisted = await db.Query(table).Where("ContentTypeId", item.data.ContentTypeId).GetAsync(transaction);
                                    if (isExisted.Count() > 0)
                                    {
                                        result.Message = "Existed duplicate key: " + item.data.ContentTypeId;
                                        result.Status = 0;
                                        return result;
                                    }
                                }
                                basesvc.CommonUpdate(item.data, username, "update");
                                object obj = new
                                {
                                    item.data.ModifiedBy,
                                    item.data.DateModified,
                                    item.data.ContentTypeId,
                                    item.data.ContentTypeName,                                    
                                };
                                returns += await db.Query(table).Where("ContentTypeId", item.key.ContentTypeId).UpdateAsync(obj, transaction);

                            }
                            else if (item.type == "insert")
                            {
                                basesvc.CommonUpdate(item.data, username, "create");
                                var isExisted = await db.Query(table).Where("ContentTypeId", item.data.ContentTypeId).GetAsync(transaction);
                                if (isExisted.Count() > 0)
                                {
                                    result.Message = "Existed duplicate key: " + item.data.ContentTypeId;
                                    result.Status = 0;
                                    return result;
                                }
                                else
                                {
                                    object obj = new
                                    {
                                        item.data.CreatedBy,
                                        item.data.DateCreated,
                                        item.data.ContentTypeId,
                                        item.data.ContentTypeName                                        
                                    };
                                    returns += await db.Query(table).InsertAsync(obj, transaction);
                                }

                            }
                            else if (item.type == "remove")
                            {
                                returns += await db.Query(table).Where("ContentTypeId", item.key.ContentTypeId).DeleteAsync(transaction);
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
