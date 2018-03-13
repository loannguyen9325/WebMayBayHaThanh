using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMayBayHaThanh.Models
{
    public class mCustomer_EmailRegister
    {
        public int Customer_EmailRegister_ID { get; set; }
        public string Customer_EmailRegister_Name { get; set; }
        public string Customer_EmailRegister_Email { get; set; }
        public string Customer_EmailRegister_Content { get; set; }
        public string LOAI { get; set; }
        public string CreatedDate { get; set; }
    }
}