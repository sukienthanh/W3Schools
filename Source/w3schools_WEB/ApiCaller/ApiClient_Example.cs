using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using w3schools_API.Models;

namespace w3schools_WEB.ApiCaller
{
    public partial class ApiClient
    {
        public async Task<List<Example>> getListExample(string filters ="",string token = "")
        {
            Uri toApi = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, "Example/GetList?filters="+filters));
            var results = await GetAsync<List<Example>>(toApi, token);
            return results;
        }

        public async Task<DataResults<IEnumerable<UpdateBatchData<Example>>>> updateBatchExample(IEnumerable<UpdateBatchData<Example>> data, string user = "Administrator", string token = "")
        {
            Uri toApi = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, "Example/Update?username=" + user));
            var results = await NewPostAsync<IEnumerable<UpdateBatchData<Example>>>(toApi, data, token);
            return results;
        }
    }
}
