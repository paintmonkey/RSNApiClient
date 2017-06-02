using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSNApiClient.Models
{
    public class CustomerInfo
    {
        public Action Action { get; set; }
        public string CompanyCode { get; set; }
        public string CustomerNumber { get; set; }
        public string Name { get; set; }
        public string SearchName { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PaymentTerm { get; set; }
        public string Department { get; set; }
        public string PriceGroup { get; set; }
        public string RowDiscount { get; set; }
        public string VatGroup { get; set; }
        public bool Blocked { get; set; }
    }
}
