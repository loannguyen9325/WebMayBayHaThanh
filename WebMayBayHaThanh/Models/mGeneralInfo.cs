using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMayBayHaThanh.Models
{
    public class mGeneralInfo
    {
        public string About { get; set; }
        public string BookingAndPayment { get; set; }
        public string HotelBooking { get; set; }
        public string TravelInsurance { get; set; }
        public string AgencyPolicy { get; set; }
        public string CompanyName { get; set; }
        public string TaxNumber { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyMail { get; set; }
        public string Hotline { get; set; }
        public string CompanyPhone { get; set; }
        public string CompanyFax { get; set; }
        public string Logo { get; set; }
        public HttpPostedFileWrapper ImageFile { get; set; }
    }
}