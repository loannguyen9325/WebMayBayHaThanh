using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMayBayHaThanh.Models
{
    public class mBanner
    {
        public Int32 BannerID { get; set; }
        public string BannerName { get; set; }
        public bool IsActive { get; set; }
        public string BannerUrl { get; set; }
        public string LOAI { get; set; }
        public HttpPostedFileWrapper ImageFile { get; set; }
    }
}