using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using w3schools_API.Models;

namespace w3schools_WEB.ApiCaller
{
    public partial class ApiClient
    {
        public async Task<List<Roles>> getListRole(string token="")
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Roles/GetList"));

            var x = await GetAsync<List<Roles>>(requestUrl,token);

            return x;
        }
        public async Task<DataResults<IEnumerable<UpdateBatchData<Roles>>>> updateBatchRole(IEnumerable<UpdateBatchData<Roles>> data, string user = "Administrator",string token="")
        {
            Uri toApi = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, "Roles/Update?username=" + user));
            var results = await NewPostAsync<IEnumerable<UpdateBatchData<Roles>>>(toApi, data,token);
            return results;
        }
    }
}
