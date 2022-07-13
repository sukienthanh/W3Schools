using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using w3schools_API.Models;

namespace w3schools_WEB.ApiCaller
{
    public partial class ApiClient
    {
        public async Task<List<Users>> getListUser(string token = "")
        {
            Uri toApi = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, "Users/GetList"));
            var results = await GetAsync<List<Users>>(toApi,token);
            return results;
        }

        public async Task<DataResults<Users>> insertUser(Users data, string user = "Administrator", string token = "")
        {
            Uri toApi = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, "Users/Insert?username=" + user));
            var results = await NewPostAsync<Users>(toApi, data,token);
            return results;
        
        }public async Task<DataResults<int>> deleteUser(int id, string user = "Administrator",string token ="")
        {
            Uri toApi = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, "Users/Delete?id="+id));
            var results = await GetAsync<DataResults<int>>(toApi,token);
            return results;
        }
    }
}
