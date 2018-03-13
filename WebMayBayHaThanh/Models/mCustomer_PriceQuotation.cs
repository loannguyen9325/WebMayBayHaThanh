using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMayBayHaThanh.Models
{
    public class mCustomer_PriceQuotation
    {
        public int Customer_PriceQuotation_ID { get; set; }
        public string Customer_PriceQuotation_Name { get; set; }
        public string Customer_PriceQuotation_Phone { get; set; }
        public string Customer_PriceQuotation_Email { get; set; }
        public string Customer_PriceQuotation_Content { get; set; }
        public string LOAI { get; set; }
        public string Customer_PriceQuotation_DateFlight { get; set; }
        public string CreatedDate { get; set; }
    }
}