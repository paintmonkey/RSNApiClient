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

        public RSNApiClient(string baseurl)
        {
            Initialize(baseurl);
        }

        private void Initialize(string baseurl)
        {
            httpClient.BaseAddress = new Uri(baseurl);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
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
            HttpResponseMessage response = await httpClient.PostAsJsonAsync("")
        }

    }
}
