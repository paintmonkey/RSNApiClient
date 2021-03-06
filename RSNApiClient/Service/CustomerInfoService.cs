﻿using System;
using System.Collections.Generic;
using System.Net;
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

        public CustomerInfoService() : base("https://rsn-staging.bettyblocks.com", "hajo.koerts@bettyblocks.com", "")

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

        public async Task<List<HttpStatusCode>> Post(IList<CustomerInfo> input)
        {
            var path = BBRequest.POSTUrl(BaseUrl, ModelName);
            var responses = new List<HttpStatusCode>();
            foreach (var info in input)
            {
                var response = await Client.PostFormAsync(path, info);
                responses.Add(response);
            }

            return responses;
        }

        public IList<HttpStatusCode> PostSync(IList<CustomerInfo> input)
        {
            return this.Post(input).Result;
        }
    }
}
