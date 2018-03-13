using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMayBayHaThanh.Models
{
    public class mCountryOrPlace
    {
        public Int32 CountryID { get; set; }
        public bool IsForeign { get; set; }
        public bool IsCountry { get; set; }
        public string CountryName { get; set; }
        public string LOAI { get; set; }
    }
}