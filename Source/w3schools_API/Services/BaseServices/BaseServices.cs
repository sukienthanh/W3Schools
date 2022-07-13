using Dapper;
using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using w3schools_API.Models;

namespace w3schools_API.Services
{
    public class BaseServices
    {
        public async Task<IEnumerable<T>> GetList<T>(string table, string s, string filter = "")
        {
            try
            {
                using (var sqlConnection = new SqlConnection(s))
                {
                    var db = new QueryFactory(sqlConnection, new SqlServerCompiler());

                    var result = db.Query(table);

                    if (!string.IsNullOrEmpty(filter))
                    {

                        result.WhereRaw(filter);
                    }

                    return await result.GetAsync<T>();
                }
            }catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        public async Task<T> GetById<T>(string table, string pKey, int id, string s)
        {
            using (var sqlConnection = new SqlConnection(s))
            {
                var db = new QueryFactory(sqlConnection, new SqlServerCompiler());

                var result = db.Query(table).Where(pKey, "=", id);

                return await result.FirstOrDefaultAsync<T>();
            }
        }
        public async Task<DataResults<T>> Insert<T>(string table, T data, string s)
        {
            DataResults<T> result = new DataResults<T>();

            int changed = 0;

            try
            {
                using (var sqlConnection = new SqlConnection(s))
                {
                    var db = new QueryFactory(sqlConnection, new SqlServerCompiler());

                    changed += await db.Query(table).InsertAsync(data);

                    if (changed > 0)
                    {
                        result.Message = "Successfully";
                        result.Status = 1;
                        result.Data = data;
                    }
                    else
                    {
                        result.Message = "failed";
                        result.Status = -1;
                        result.Data = data;
                    }

                    return result;
                }
            }
            catch (Exception e)
            {
                result.Message = e.Message;
                result.Status = -1;
                result.Data = data;

                return result;
            }
        }
        public async Task<DataResults<int>> Delete(string table, string constr, string pkey = null, int id = -1)
        {
            if (string.IsNullOrEmpty(pkey)) pkey = table + "Id";

            DataResults<int> result = new DataResults<int>();
            int changed = 0;

            try
            {
                using (var sqlConnection = new SqlConnection(constr))
                {
                    sqlConnection.Open();

                    //sqlConnection.Query("delete " + table + " where " + pkey + " in @ids", ids);
                    
                    var db = new QueryFactory(sqlConnection, new SqlServerCompiler());

                    if (id != -1)
                    {
                        changed += await db.Query(table).Where(pkey, id).DeleteAsync();
                        result.Message = "Successfully";
                        result.Status = 1;
                        result.Data = changed;
                    }
                    else
                    {

                        result.Message = "Failed";
                        result.Status = -1;                        
                    }

                    return result;
                }
            }
            catch (Exception ex)
            {
                result.Status = -1;
                result.Message = ex.Message;
                result.Data = 0;
                return result;
            }
        }
        public async Task<DataResults<T>> Update<T>(string table, T data, string s, string pkey = "Id", int id = -1)
        {
            DataResults<T> result = new DataResults<T>();

            int changed = 0;

            try
            {
                using (var sqlConnection = new SqlConnection(s))
                {
                    var db = new QueryFactory(sqlConnection, new SqlServerCompiler());

                    if (id != -1)
                    {
                        changed += await db.Query(table).Where(pkey, id).UpdateAsync(data);
                    }
                    else
                    {
                        changed += await db.Query(table).Where(pkey, data.GetType().GetProperties()[0].GetValue(data, null)).UpdateAsync(data);
                    }

                    if (changed > 0)
                    {
                        result.Message = "Successfully";
                        result.Status = 1;
                        result.Data = data;
                    }
                    else
                    {
                        result.Message = "Failed";
                        result.Status = -1;
                        result.Data = data;
                    }

                    return result;
                }
            }
            catch (Exception e)
            {
                result.Message = e.Message;
                result.Status = -1;
                result.Data = data;

                return result;
            }
        }

        public void CommonUpdate(object obj, string user, string type,int role =1)
        {
            try
            {
                if (type.Equals("create"))
                {
                    SetPropertyValue(obj, "DateCreated", DateTime.Now,true);
                    SetPropertyValue(obj, "CreatedBy", user,true);
                }
                else if(type.Equals("update"))
                {
                    SetPropertyValue(obj, "DateModified", DateTime.Now,true);
                    SetPropertyValue(obj, "ModifiedBy", user,true);
                }
                SetPropertyValue(obj, "RoleId", role, true);
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }
        public void SetPropertyValue(dynamic pData, string pPropertyName, dynamic pValue, bool pOverride = false)
        {
            // Get property info
            System.Reflection.PropertyInfo property = pData.GetType().GetProperty(pPropertyName);

            // Property existed
            if (property != null)
            {
                // Override
                if (pOverride)
                {
                    // Set value
                    property.SetValue(pData, pValue, null);
                }
                else // Not override
                {
                    // Get value of property
                    dynamic value = property.GetValue(pData, null);

                    // Value is null
                    if (value == null)
                    {
                        // Set value
                        property.SetValue(pData, pValue, null);
                    }
                }
            }
        }
    }
}
