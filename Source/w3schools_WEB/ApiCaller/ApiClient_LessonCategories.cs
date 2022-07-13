using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using w3schools_API.Models;

namespace w3schools_WEB.ApiCaller
{
    public partial class ApiClient
    {
        public async Task<List<LessonCategories>> getListLessonCate(string token="")
        {
            Uri toApi = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, "LessonCategories/GetList"));
            var results = await GetAsync<List<LessonCategories>>(toApi,token);
            return results;
        }

        public async Task<DataResults<IEnumerable<UpdateBatchData<LessonCategories>>>> updateBatchLessonCate( IEnumerable<UpdateBatchData<LessonCategories>> data, string user= "Administrator", string token ="")
        {
            Uri toApi = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, "LessonCategories/Update?username=" + user));
            var results = await NewPostAsync<IEnumerable<UpdateBatchData<LessonCategories>>>(toApi, data,token);
            return results;
        }
    }
}
