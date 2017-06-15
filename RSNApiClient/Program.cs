using RSNApiClient.Services;
using RSNApiClient.Models;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net;

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
            // Create a new service, which points to the customer info table in Betty Blocks.
            var service = new CustomerInfoService();
           
            // Create a row with usable data.
            var info = new CustomerInfo();

            // Set the action to determine what BB will do when the record is processed.
            // Available actions: "Created, Modified, Deleted"
            info.Action = Models.Action.Created;

            // Add some more infor - @see CustomerInfo models to learn what is available.
            info.CustomerNumber = "New customer number";
            info.VatGroup = "New VAT Group";
            
            // Put the rows in a ICollection e.g. a List
            var list = new List<CustomerInfo>() { info, info };

            // Finally post the data to BB.
            // There is also an asynch method available, but this works better with AX, i assume.
            var responses = service.PostSync(list);

            // Responses will be a List, which you can enumerate;
            // In the same order as the rows you inserted, you will get the result of posting the row.
            // If all is well, you'll get a 201 - Created. Otherwise it will be a different HTTPStatusCode.
            foreach(HttpStatusCode status in responses)
            {
                // Should be Created - 201!
                Console.WriteLine("{0}", status.ToString());
            }
            
            // Done .. wait for more work.
            Console.ReadLine();
        }
    }
}
