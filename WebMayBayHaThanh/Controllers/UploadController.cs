using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.IO;
using System.Web.Hosting;

namespace WebMayBayHaThanh.Controllers
{
    public class UploadController : ApiController
    {
        [Route("api/Upload/UploadImage")]
        [HttpPost, AcceptVerbs("GET", "POST")]
        public IHttpActionResult UploadImage()
        {
            string path = "";
            string savePath = "";
            string fileName = "";
            string LOAI = "Banner";
            if (HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var httpPostedFile = HttpContext.Current.Request.Files["imgImageUpload"];
                fileName = String.Format("{0:ddMMyyyyHHmmss}", DateTime.Now) + Path.GetFileName(httpPostedFile.FileName);

                if (LOAI == "Banner")
                {
                    path = Path.Combine(HostingEnvironment.MapPath("~/Images/Banner/") + fileName);
                    savePath = "Images/Banner/" + fileName;
                }
                else if (LOAI == "Logo")
                {
                    path = Path.Combine(HostingEnvironment.MapPath("~/Images/Logo/") + fileName);
                    savePath = "Images/Logo/" + fileName;
                }
                else if (LOAI == "NewsImages")
                {
                    path = Path.Combine(HostingEnvironment.MapPath("~/Images/NewsImages/") + fileName);
                    savePath = "Images/NewsImages/" + fileName;
                }
                else if (LOAI == "ProductImages")
                {
                    path = Path.Combine(HostingEnvironment.MapPath("~/Images/ProductImages/") + fileName);
                    savePath = "Images/ProductImages/" + fileName;
                }
                else if (LOAI == "UserImages")
                {
                    path = Path.Combine(HostingEnvironment.MapPath("~/Images/UserImages/") + fileName);
                    savePath = "Images/UserImages/" + fileName;
                }
                else if (LOAI == "VisaImages")
                {
                    path = Path.Combine(HostingEnvironment.MapPath("~/Images/VisaImages/") + fileName);
                    savePath = "Images/VisaImages/" + fileName;
                }

                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                
                httpPostedFile.SaveAs(path);
            }
            return Ok(savePath);
        }
    }
}