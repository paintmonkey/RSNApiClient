using System;
using System.Collections.Generic;
using RSNApiClient.Models;
using RSNApiClient.Requests;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace RSNApiClient.Services
{
    /// <summary>
    /// Summary description for CustomerInfoService
    /// </summary>
    public class CustomerInfoService : Service, IWebService<CustomerInfo>
    {
        private static string ModelName = "customermutations";

        public CustomerInfoService() : base("https://rsn-staging.bettyblocks.com", "rob@pixelcloud.nl", "")
        {
            
        }

        public async Task<List<CustomerInfo>> Get()
        {
            var path = BBRequest.GETUrl(BaseUrl, ModelName);
            var task = await Client.GetAsync(path);
            var response = await task.Content.ReadAsStringAsync();

            Console.WriteLine(response);
            
            return JsonConvert.DeserializeObject<List<CustomerInfo>>(response);
        }

        public void Post(List<CustomerInfo> input)
        {
            throw new NotImplementedException();
        }
    }
}
