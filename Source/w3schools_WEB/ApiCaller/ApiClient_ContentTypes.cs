﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using w3schools_API.Models;

namespace w3schools_WEB.ApiCaller
{
    public partial class ApiClient
    {
        public async Task<List<ContentTypes>> getListContentType(string token="")
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "ContentTypes/GetList"));

            var x = await GetAsync<List<ContentTypes>>(requestUrl,token);

            return x;
        }
        public async Task<DataResults<IEnumerable<UpdateBatchData<ContentTypes>>>> updateBatchContentType(IEnumerable<UpdateBatchData<ContentTypes>> data, string user = "Administrator", string token ="")
        {
            Uri toApi = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, "ContentTypes/Update?username=" + user));
            var results = await NewPostAsync<IEnumerable<UpdateBatchData<ContentTypes>>>(toApi, data,token);
            return results;
        }
    }
}
