using RSNApiClient.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;

namespace RSNApiClient
{
    public class RSNApiClient
    {
        static HttpClient httpClient = new HttpClient();
        private string username;
        private string password;
        private string baseurl;

        public RSNApiClient(string baseurl, string username, string password)
        {
            Initialize(baseurl, username, password);
        }

        private void Initialize(string baseurl, string username, string password)
        {
            this.baseurl = baseurl;
            this.username = username;
            this.password = password;

            httpClient.BaseAddress = new Uri(baseurl);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(
                System.Text.ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", username, password))));
        }

        public Task<HttpResponseMessage> GetAsync(string path)
        {
            Console.WriteLine(String.Format("--- GET/{0} ---", path));
            return httpClient.GetAsync(path);
        }

        public Task GetStreamAsync(string path)
        {
            return httpClient.GetStreamAsync(path);
        }

        public async Task<HttpStatusCode> PostFormAsync<T>(string path, T payload)
        {
            var response = await path.WithBasicAuth(username, password).PostUrlEncodedAsync(payload);
            return response.StatusCode; 
        }

        public async Task<HttpStatusCode> PostAsync<T>(string path, T payload)
        {
            Console.WriteLine(String.Format("--- POST/{0} ---", path));
            HttpResponseMessage response = await httpClient.PostAsJsonAsync(path, payload);
            Console.WriteLine(String.Format("--- Response:{0}", response.StatusCode));
            return response.StatusCode;
        }

    }
}
