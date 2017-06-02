using RSNApiClient.Services;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

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
            var response = await service.Get();
            Console.Write(response);
        }
    }
}
