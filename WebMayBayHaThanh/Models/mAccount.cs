using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMayBayHaThanh.Models
{
    public class mAccount
    {
        public Int32 UserID { get; set; }
        public string UserName { get; set; }
        public string SALT { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public bool Gender { get; set; }
        public string UserAddress { get; set; }
        public string DeskphoneNo { get; set; }
        public string PhoneNo { get; set; }
        public string EmailAddress { get; set; }
        public string SkypeAccount { get; set; }
        public bool IsConsultant { get; set; }
        public string UserImage { get; set; }
        public string LOAI { get; set; }
        public HttpPostedFileWrapper ImageFile { get; set; }
    }
}