using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ThomasGreg.Entidade;
using System.Net.Http.Headers;

namespace ThomasGreg.Site.Services
{
    public class WebApiService<T>
    {
        private static HttpClient client = new HttpClient();

        #region Private Methods
        private static JsonSerializerSettings MicrosoftDateFormatSettings
        {
            get
            {
                return new JsonSerializerSettings
                {
                    DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
                };
            }
        }

        private StringContent CreateHttpContent<X>(T content)
        {
            //var json = JsonConvert.SerializeObject(content, MicrosoftDateFormatSettings);
            var json = JsonConvert.SerializeObject(content);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }
        #endregion

        #region Internal Methods
        internal async Task<T> GetTAsync(string url)
        {
            try
            {
                using (client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(100);

                    var responseData = default(T);
                    var response = await client.GetAsync(url, HttpCompletionOption.ResponseContentRead);

                    if (response.IsSuccessStatusCode)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        responseData = JsonConvert.DeserializeObject<T>(data);
                    }

                    return responseData;
                }
            }
            catch (HttpRequestException ex)
            {
                return default;
            }
            catch (Exception ex)
            {
                return default;
            }
        }
              
        internal async Task<HttpResponseMessage> PostTAsync(string url, T data)
        {
            try
            {
                using (client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(100);
                    var response = await client.PostAsync(url, CreateHttpContent<T>(data));
                    response.EnsureSuccessStatusCode();

                    return response;
                }
            }
            catch (HttpRequestException)
            {
                return default;
            }
            catch (Exception)
            {
                return default;
            }
        }

        internal async Task<HttpResponseMessage> PutTAsync(string url, T data)
        {
            try
            {
                using (client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(100);
                    var response = await client.PutAsync(url, CreateHttpContent<T>(data));
                    response.EnsureSuccessStatusCode();

                    return response;
                }
            }
            catch (HttpRequestException)
            {
                return default;
            }
            catch (Exception)
            {
                return default;
            }
        }

        internal async Task<HttpStatusCode> DeleteTAsync(string url)
        {
            try
            {
                using (client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(100);
                    var response = await client.DeleteAsync(url);
                    return response.StatusCode;
                }
            }
            catch (HttpRequestException)
            {
                return default;
            }
            catch (Exception)
            {
                return default;
            }
        }
        #endregion
    }
}
