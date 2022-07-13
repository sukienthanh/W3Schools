using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
/*using  Newtonsoft.Json;*/
using Newtonsoft.Json.Linq;
using w3schools_API.Models;
using w3schools_WEB.Models;
using System.Text.Json;
using System.Net;

namespace w3schools_WEB.ApiCaller
{
    public partial class ApiClient
    {
        #region Variable

        private HttpClient _httpClient;        

        private Uri BaseEndPoint { get; set; }
        
        #endregion

        #region Constructor

        public ApiClient(Uri baseEndPoint)
        {
            if (baseEndPoint == null)
            {
                throw new ArgumentException("BaseEndPoint NULL");
            }

            BaseEndPoint = baseEndPoint;

            _httpClient = new HttpClient();            
        }

        #endregion

        #region Method

        private void AddHeaders(string accessToken)
        {
            if (!string.IsNullOrEmpty(accessToken))
            {
                _httpClient.DefaultRequestHeaders.Remove("Authorization");
                _httpClient.DefaultRequestHeaders.Add("Authorization", accessToken);
            }
        }

        private HttpContent CreateHttpContent<T>(T content)
        {
            var json = JsonSerializer.Serialize(content);
             var a= new StringContent(json, Encoding.UTF8, "application/json");
            return a;
        }        

        private async Task<T> GetAsync<T>(Uri requestUrl, JObject obj, string token)
        {
            AddHeaders(token);

            var request = new HttpRequestMessage
            {
                RequestUri = requestUrl,
                Method = HttpMethod.Get
            };

            request.Content = new StringContent(obj.ToString(), Encoding.UTF8, "application/json");
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await _httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadAsStringAsync();

            return /*JsonConvert.DeserializeObject<T>(data);*/ JsonSerializer.Deserialize<T>(data, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
        }


        private async Task<T> GetAsync<T>(Uri requestUrl, string token = "")
        {
            AddHeaders(token);           
            var response = await _httpClient.GetAsync(requestUrl, HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();
            //if (response.StatusCode == HttpStatusCode.Unauthorized)
            //{
            //    // Authorization header has been set, but the server reports that it is missing.
            //    // It was probably stripped out due to a redirect.

            //    var finalRequestUri = response.RequestMessage.RequestUri; // contains the final location after following the redirect.

            //    if (finalRequestUri != requestUrl) // detect that a redirect actually did occur.
            //    {
            //        // If this is public facing, add tests here to determine if Url should be trusted
            //        response = await _httpClient.GetAsync(finalRequestUri);
            //    }
            //}
            var data = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(data, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

        }
        private async Task<DataResults<T>> NewPostAsync<T>(Uri requestUrl, T content, string token="")
        {
            AddHeaders(token);
            var response = await _httpClient.PostAsync(requestUrl.ToString(), CreateHttpContent<T>(content));
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            var returns = JsonSerializer.Deserialize<DataResults<T>>(data, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return returns;
        }
        private async Task<DataResults<T1>> NewPostAsync2Para<T1,T2>(Uri requestUrl, T2 content, string token = "")
        {
            AddHeaders(token);
            var response = await _httpClient.PostAsync(requestUrl.ToString(), CreateHttpContent<T2>(content));
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            var returns = JsonSerializer.Deserialize<DataResults<T1>>(data, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return returns;
        }
        private async Task<Message<T>> PostAsync<T>(Uri requestUrl, T content, string token="")
        {
            AddHeaders(token);
            var response = await _httpClient.PostAsync(requestUrl.ToString(), CreateHttpContent<T>(content));
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            var returns = new Message<T>
            {
                Data = JsonSerializer.Deserialize<T>(data, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                }),
                IsSuccess = response.IsSuccessStatusCode,
                ReturnMessage = response.ReasonPhrase
            };
            return returns;
        }

        private async Task<T1> PostAsyncForToken<T1, T2>(Uri requestUrl, T2 content, string token="")
        {
            AddHeaders(token);
            var response = await _httpClient.PostAsync(requestUrl.ToString(), CreateHttpContent<T2>(content));
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            var returns = new Message<T1>
            {
                Data = JsonSerializer.Deserialize<T1>(data, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                }),
                IsSuccess = response.IsSuccessStatusCode,
                ReturnMessage = response.ReasonPhrase
            };
            return returns.Data;
        }
        private async Task<Message<T1>> PostAsync<T1, T2>(Uri requestUrl, T2 content, string token = "")
        {
            AddHeaders(token);
            var response = await _httpClient.PostAsync(requestUrl.ToString(), CreateHttpContent<T2>(content));
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            var returns = new Message<T1>
            {
                Data = JsonSerializer.Deserialize<T1>(data, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                }),
                IsSuccess = response.IsSuccessStatusCode,
                ReturnMessage = response.ReasonPhrase
            };
            return returns;
        }

        private async Task<T> PutAsync<T>(Uri requestUrl, T content, string token)
        {
            AddHeaders(token);
            var response = await _httpClient.PutAsync(requestUrl.ToString(), CreateHttpContent<T>(content));
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(data, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
        }
        private async Task<T> DeleteAsync<T>(Uri requestUrl, string token="")
        {
            AddHeaders(token);
            var response = await _httpClient.DeleteAsync(requestUrl);
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(data, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

        }
        private Uri CreateRequestUri(string relativePath, string queryString = "")
        {
            var endpoint = new Uri(BaseEndPoint, relativePath);
            var uriBuilder = new UriBuilder(endpoint);

            if (!string.IsNullOrEmpty(queryString))
            {
                uriBuilder.Query = queryString;
            }

            return uriBuilder.Uri;
        }

        public async Task<int> CheckToken(string token)
        {
            try
            {
                var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, "Token/CheckToken"));

                var data = await GetAsync<int>(requestUrl, token);

                return data;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public async Task<string> GetTokenAsync()
        {
            
           
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, "Token/GetToken?u=admin&p=123"));

            var data = await GetAsync<string>(requestUrl);

            return data;
        }

        public async Task<string> RefeshToken(UserInfo userInfo)
        {


            if (userInfo != null)
            {
                var ck = await CheckToken(userInfo.Token);

                if (ck != 0)
                {
                    return userInfo.Token;
                }
                else
                {
                    string tokenNew = await GetTokenAsync();
                    return tokenNew;
                }
            }

            return string.Empty;
        }        

        #endregion
    }
}
