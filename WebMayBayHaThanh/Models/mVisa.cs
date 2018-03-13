using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMayBayHaThanh.Models
{
    public class mVisa
    {
        public int VisaID { get; set; }
        public int VisaCountryID { get; set; }
        public string VisaTitle { get; set; }
        public string VisaImage { get; set; }
        public string VisaContent { get; set; }
        public string LOAI { get; set; }
        public string CreatedDate { get; set; }
        public HttpPostedFileWrapper ImageFile { get; set; }
    }
}