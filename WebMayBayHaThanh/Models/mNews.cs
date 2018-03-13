using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMayBayHaThanh.Models
{
    public class mNews
    {
        public int NewsID { get; set; }
        public string NewsTitle { get; set; }
        public string NewsImage { get; set; }
        public string NewsContent { get; set; }
        public string LOAI { get; set; }
        public string CreatedDate { get; set; }
        public HttpPostedFileWrapper ImageFile { get; set; }
    }
}