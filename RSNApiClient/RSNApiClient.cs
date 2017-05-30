using RSNApiClient.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace RSNApiClient
{
    class RSNApiClient
    {
        static HttpClient httpClient = new HttpClient();

        public RSNApiClient(string baseurl, string username, string password)
        {
            Initialize(baseurl, username, password);
        }

        private void Initialize(string baseurl, string username, string password)
        {
            httpClient.BaseAddress = new Uri(baseurl);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(
                System.Text.ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", username, password))));
        }

        // Price updates
        public HttpStatusCode UpdatePrice(PriceUpdate update)
        {
            return PutPriceUpdateAsync(update).Result;
        }

        private async Task<HttpStatusCode> PutPriceUpdateAsync(PriceUpdate update)
        {
            HttpResponseMessage response = await httpClient.PutAsJsonAsync("$api/importPrice/", update);
            return response.StatusCode;
        }

        // CustomerInfo
        public HttpStatusCode PushCustomerInfo(CustomerInfo info)
        {
            return PostCustomerInfoAsync(info).Result;
        }

        private async Task<HttpStatusCode> PostCustomerInfoAsync(CustomerInfo info)
        {
            HttpResponseMessage response = await httpClient.PostAsJsonAsync("$/api/models/customermutations/records/new", info);
        }

    }
}
