using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMayBayHaThanh.Models
{
    public class mProduct
    {
        public Int32 ProductID { get; set; }
        public Int32 ProductTypeID { get; set; }
        public Int32 ProductCategoryID { get; set; }
        public Int32 ProductGroupID { get; set; }
        public string ProductName { get; set; }
        public string BrandName { get; set; }
        public Int32 LeavingFrom { get; set; }
        public Int32 GoingTo { get; set; }
        public Int32 BrandID { get; set; }
        public string ProductEffectedDate { get; set; }
        public float ProductPrice { get; set; }
        public string ProductContent { get; set; }
        public string ProductImage { get; set; }
        public Int32 ProductStatus { get; set; }
        public string LOAI { get; set; }
        public string CreatedDate { get; set; }
        public HttpPostedFileWrapper ImageFile { get; set; }
    }
}