using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSNApiClient.Requests
{
    static class BBRequest
    {     
        public static string GETUrl(string baseUrl, string model)
        {
            return string.Format("{0}/api/models/{1}/records", baseUrl, model);
        }

        public static string POSTUrl(string baseUrl, string model)
        {
            // e.g. api/models/customermutations/records/new
            return string.Format("{0}/api/models/{1}/records/new", baseUrl, model);
        }
    }
}
