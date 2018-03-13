using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMayBayHaThanh.Models
{
    public class mUploadImage
    {
        public string Folder { get; set; }
        public HttpPostedFileWrapper ImageFile { get; set; }
    }
}