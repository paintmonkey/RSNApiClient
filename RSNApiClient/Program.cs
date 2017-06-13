using RSNApiClient.Services;
using RSNApiClient.Models;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace RSNApiClient
{
    class Program
    {
       
        static void Main(string[] args)
        {
            RunAsync().Wait();
        }

        static async Task RunAsync()
        {
            var service = new CustomerInfoService();
           
            var info = new CustomerInfo();
            info.CustomerNumber = "New customer number";

            var list = new List<CustomerInfo>() { info };
            var responses = await service.Post(list);
            var response = await service.Get();
            Console.Write(response);
            Console.ReadLine();
        }
    }
}
