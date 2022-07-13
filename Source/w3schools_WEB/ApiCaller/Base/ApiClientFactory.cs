using System;
using System.Threading;


namespace w3schools_WEB.ApiCaller
{
    public static class ApiClientFactory
    {
        private static Uri apiUri;

        private static Lazy<ApiClient> restClient = new Lazy<ApiClient>(
            ()=> new ApiClient(apiUri),LazyThreadSafetyMode.ExecutionAndPublication
            );

        static ApiClientFactory()
        {
            apiUri = new Uri(ApplicationSettings.WebApiUrl);
        }

        public static ApiClient Instance
        {
            get { return restClient.Value; }
        }

    }
}