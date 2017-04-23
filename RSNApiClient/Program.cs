using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace RSNApiClient
{
    class Program
    {
        static HttpClient httpClient = new HttpClient();

        static void Main(string[] args)
        {
            RunAsync().Wait();
        }

        static async Task RunAsync()
        {
            Console.ReadLine();
        }
    }
}
