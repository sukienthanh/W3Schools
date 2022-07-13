using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using w3schools_API.Models;

namespace w3schools_WEB.ApiCaller
{
    public partial class ApiClient
    {
        public async Task<DataResults<UserInfo>> checkLogin(Users data)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Auth/CheckLogin"));

            var x = await NewPostAsync2Para<UserInfo,Users>(requestUrl,data);

            return x;
        }
        public async Task<DataResults<UserInfo>> signup(Users data)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Auth/Signup"));

            var x = await PostAsyncForToken<DataResults<UserInfo>,Users>(requestUrl,data);

            return x;
        }
    }
}

