using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using w3schools_API.Models;
using w3schools_WEB.Models;

namespace w3schools_WEB.ApiCaller
{
    public partial class ApiClient
    {
        public async Task<LessonContents> GetLessonContentById(int id,string token = "")
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "LessonContents/GetById?id= " + id));

            var x = await GetAsync<LessonContents>(requestUrl,token);

            return x;
        }

        public async Task<List<LessonContents>> GetListLessonContents(string filters="",string token ="")
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "LessonContents/GetList?filters="+filters));

            var x = await GetAsync<List<LessonContents>>(requestUrl,token);

            return x;
        }

        public async Task<Message<DataResults<LessonContents>>> UpdateLessonContent(LessonContents requests,string user= "Administrator",string token="")
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "LessonContents/Update"));

            var x = await PostAsync<DataResults<LessonContents>, LessonContents>(requestUrl, requests,token);

            return x;
        }
        public async Task<Message<DataResults<LessonContents>>> InsertLessonContent(LessonContents requests,string user,string token="")
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "LessonContents/Insert"));

            var x = await PostAsync<DataResults<LessonContents>, LessonContents>(requestUrl, requests,token);

            return x;
        }

        public async Task<DataResults<int>> DeleteLessonContent(int id,string token ="")
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "LessonContents/Delete?id=" + id));

            var x = await DeleteAsync<DataResults<int>>(requestUrl,token);

            return x;
        }
    }
}
