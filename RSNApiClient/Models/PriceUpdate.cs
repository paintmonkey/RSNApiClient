using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSNApiClient
{
    class PriceUpdate
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime valid_to { get; set; }
        public DateTime valid_from { get; set; }
        public Money price { get; set; }
    }
}
