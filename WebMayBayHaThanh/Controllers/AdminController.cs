using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Data;
using System.IdentityModel;
using System.ServiceModel.Security;
using System.Web.Script.Serialization;

using Newtonsoft.Json;

using MayBayHaThanh.Entities;
using MayBayHaThanh.DAL;
using MayBayHaThanh.Utilities;

using WebMayBayHaThanh.Models;
using System.IO;
using System.Globalization;

namespace WebMayBayHaThanh.Controllers
{
    [NoCache]
    public class AdminController : BaseController
    {
        #region Variables

        clsList_Account clsAccount = new clsList_Account();
        clsList_Banner clsBanner = new clsList_Banner();
        clsList_Brand clsBrand = new clsList_Brand();
        clsList_CountryOrPlace clsCountryOrPlace = new clsList_CountryOrPlace();
        clsList_DomesticPlace clsDomesticPlace = new clsList_DomesticPlace();
        clsList_GeneralInfo clsGeneralInfo = new clsList_GeneralInfo();
        clsList_News clsNews = new clsList_News();
        clsList_Product clsProduct = new clsList_Product();
        clsList_ProductCategory clsProductCategory = new clsList_ProductCategory();
        clsList_ProductStatus clsProductStatus = new clsList_ProductStatus();
        clsList_Visa clsVisa = new clsList_Visa();
        clsList_Customer_PriceQuotation clsPriceQuotation = new clsList_Customer_PriceQuotation();
        clsList_Customer_EmailRegister clsEmailRegister = new clsList_Customer_EmailRegister();

        #endregion

        #region LoadUser

        public JsonResult LoadUser()
        {
            DataTable tblListAccount = clsAccount.SelectByKey(int.Parse(Session["UserID"].ToString()));
            var sql = (from row in tblListAccount.AsEnumerable()
                       select new
                       {
                           UserName = row.Field<string>("UserName"),
                           FullName = row.Field<string>("FullName"),
                           UserImage = row.Field<string>("UserImage")
                       }).AsQueryable();
            return Json(sql.ToList(), JsonRequestBehavior.AllowGet);
        }

        #endregion LoadUser

        #region Index

        public ActionResult Index()
        {
            return View();
        }

        #endregion Index

        #region Banner

        public ActionResult Banner()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Select_List_Banner(int? skip, int? take, int? page, int? pageSize, List<Sort> sort = null, FilterContainer filter = null)
        {
            DataTable tblListBanner = clsBanner.SelectAll();

            int total = tblListBanner.Rows.Count;

            if (filter != null && filter.filters != null)
            {
                tblListBanner = FilterHelper.FilterDatatable(tblListBanner, filter);
                total = tblListBanner.Rows.Count;
            }

            var sql = (from row in tblListBanner.AsEnumerable()
                       select new
                       {
                           BannerID = row.Field<int>("BannerID"),
                           BannerName = row.Field<string>("BannerName"),
                           BannerUrl = row.Field<string>("BannerUrl"),
                           IsActive = row.Field<bool>("IsActive"),
                           CreatedBy = row.Field<string>("CreatedBy"),
                           CreatedDate = (row.Field<DateTime?>("CreatedDate")).HasValue ? row.Field<DateTime>("CreatedDate").ToString("dd/MM/yyyy HH:mm:ss") : "",
                           LastUpdatedBy = row.Field<string>("LastUpdatedBy"),
                           LastUpdatedDate = (row.Field<DateTime?>("LastUpdatedDate")).HasValue ? row.Field<DateTime>("LastUpdatedDate").ToString("dd/MM/yyyy HH:mm:ss") : ""
                       }).AsQueryable();

            if (sort != null && sort.Count >= 0)
            {
                foreach (var s in sort)
                {
                    if (s.dir.ToLower() == "asc")
                    {
                        sql = SortHelper.OrderBy(sql, s.field);
                    }
                    else
                    {
                        sql = SortHelper.OrderByDescending(sql, s.field);
                    }
                }
            }

            if (page.HasValue && pageSize.HasValue)
            {
                int start = (page.Value - 1) * pageSize.Value;
                sql = sql.Skip(start).Take(pageSize.Value);
            }

            var records = sql.ToList();

            return Json(new { records, total }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult CapNhatBanner(mBanner obj)
        {
            bool IsSuccess;
            DataAccess m_Dal = new DataAccess();
            clsList_Banner clsBanner = new clsList_Banner(m_Dal);
            if (obj.LOAI == "INSERT")
            {
                mUploadImage mUpload = new mUploadImage();
                mUpload.Folder = "Banner";
                mUpload.ImageFile = obj.ImageFile;
                string path = UploadImage(mUpload).ToString();
                m_Dal.BeginTrans(IsolationLevel.ReadCommitted);
                string[] a = path.Split('|');
                clsBanner.BannerName = a[0];
                clsBanner.BannerUrl = a[1];
                clsBanner.CreatedBy = int.Parse(Session["UserID"].ToString());
                IsSuccess = clsBanner.Insert();
                if (IsSuccess)
                {
                    m_Dal.CommitTrans(true);
                    return Json("...", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    m_Dal.AbortTrans();
                    return Json("Cập nhật thất bại!", JsonRequestBehavior.AllowGet);
                }
            }
            else if (obj.LOAI == "UPDATE")
            {
                m_Dal.BeginTrans(IsolationLevel.ReadCommitted);
                clsBanner.BannerID = obj.BannerID;
                if (obj.IsActive == true)
                {
                    clsBanner.IsActive = false;
                }
                else if (obj.IsActive == false)
                {
                    clsBanner.IsActive = true;
                }
                clsBanner.LastUpdatedBy = int.Parse(Session["UserID"].ToString());
                IsSuccess = clsBanner.Update();
                if (IsSuccess)
                {
                    m_Dal.CommitTrans(true);
                    return Json("...", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    m_Dal.AbortTrans();
                    return Json("Cập nhật thất bại!", JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                int BannerID = obj.BannerID;
                m_Dal.BeginTrans(IsolationLevel.ReadCommitted);
                IsSuccess = clsBanner.Delete(BannerID);
                if (IsSuccess)
                {
                    m_Dal.CommitTrans(true);
                    return Json("...", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    m_Dal.AbortTrans();
                    return Json("Cập nhật thất bại!", JsonRequestBehavior.AllowGet);
                }
            }
        }

        #endregion Banner

        #region About

        public ActionResult About()
        {
            return View();
        }

        public JsonResult Select_About()
        {
            DataTable tblListGeneralInfo = clsGeneralInfo.Select_GeneralInfo_By_Code("About");
            var sql = (from row in tblListGeneralInfo.AsEnumerable()
                       select new
                       {
                           AboutDecode = HttpUtility.HtmlDecode(row.Field<string>("About")),
                       }).AsQueryable();
            return Json(sql.ToList(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult CapNhatGioiThieu(mGeneralInfo obj)
        {
            bool IsSuccess;
            DataAccess m_Dal = new DataAccess();
            clsList_GeneralInfo clsGeneralInfo = new clsList_GeneralInfo(m_Dal);
            m_Dal.BeginTrans(IsolationLevel.ReadCommitted);
            clsGeneralInfo.About = obj.About;
            clsGeneralInfo.LastUpdatedBy = int.Parse(Session["UserID"].ToString());
            IsSuccess = clsGeneralInfo.Update("About");
            if (IsSuccess)
            {
                m_Dal.CommitTrans(true);
                return Json("...", JsonRequestBehavior.AllowGet);
            }
            else
            {
                m_Dal.AbortTrans();
                return Json("Cập nhật thất bại!", JsonRequestBehavior.AllowGet);
            }
        }

        #endregion About

        #region HotelService

        public ActionResult HotelService()
        {
            return View();
        }

        public JsonResult Select_HotelBooking()
        {
            DataTable tblListGeneralInfo = clsGeneralInfo.Select_GeneralInfo_By_Code("HotelBooking");
            var sql = (from row in tblListGeneralInfo.AsEnumerable()
                       select new
                       {
                           HotelBookingDecode = HttpUtility.HtmlDecode(row.Field<string>("HotelBooking")),
                       }).AsQueryable();
            return Json(sql.ToList(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult CapNhatDichVuKhachSan(mGeneralInfo obj)
        {
            bool IsSuccess;
            DataAccess m_Dal = new DataAccess();
            clsList_GeneralInfo clsGeneralInfo = new clsList_GeneralInfo(m_Dal);
            m_Dal.BeginTrans(IsolationLevel.ReadCommitted);
            clsGeneralInfo.HotelBooking = obj.HotelBooking;
            clsGeneralInfo.LastUpdatedBy = int.Parse(Session["UserID"].ToString());
            IsSuccess = clsGeneralInfo.Update("HotelBooking");
            if (IsSuccess)
            {
                m_Dal.CommitTrans(true);
                return Json("...", JsonRequestBehavior.AllowGet);
            }
            else
            {
                m_Dal.AbortTrans();
                return Json("Cập nhật thất bại!", JsonRequestBehavior.AllowGet);
            }
        }

        #endregion HotelService

        #region BookingAndPayment

        public ActionResult BookingAndPayment()
        {
            return View();
        }

        public JsonResult Select_BookingAndPayment()
        {
            DataTable tblListGeneralInfo = clsGeneralInfo.Select_GeneralInfo_By_Code("BookingAndPayment");
            var sql = (from row in tblListGeneralInfo.AsEnumerable()
                       select new
                       {
                           BookingAndPaymentDecode = HttpUtility.HtmlDecode(row.Field<string>("BookingAndPayment")),
                       }).AsQueryable();
            return Json(sql.ToList(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult CapNhatHuongDanDatVeThanhToan(mGeneralInfo obj)
        {
            bool IsSuccess;
            DataAccess m_Dal = new DataAccess();
            clsList_GeneralInfo clsGeneralInfo = new clsList_GeneralInfo(m_Dal);
            m_Dal.BeginTrans(IsolationLevel.ReadCommitted);
            clsGeneralInfo.BookingAndPayment = obj.BookingAndPayment;
            clsGeneralInfo.LastUpdatedBy = int.Parse(Session["UserID"].ToString());
            IsSuccess = clsGeneralInfo.Update("BookingAndPayment");
            if (IsSuccess)
            {
                m_Dal.CommitTrans(true);
                return Json("...", JsonRequestBehavior.AllowGet);
            }
            else
            {
                m_Dal.AbortTrans();
                return Json("Cập nhật thất bại!", JsonRequestBehavior.AllowGet);
            }
        }

        #endregion BookingAndPayment

        #region TravelInsurance

        public ActionResult TravelInsurance()
        {
            return View();
        }

        public JsonResult Select_TravelInsurance()
        {
            DataTable tblListGeneralInfo = clsGeneralInfo.Select_GeneralInfo_By_Code("TravelInsurance");
            var sql = (from row in tblListGeneralInfo.AsEnumerable()
                       select new
                       {
                           TravelInsuranceDecode = HttpUtility.HtmlDecode(row.Field<string>("TravelInsurance")),
                       }).AsQueryable();
            return Json(sql.ToList(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult CapNhatBaoHiemDuLich(mGeneralInfo obj)
        {
            bool IsSuccess;
            DataAccess m_Dal = new DataAccess();
            clsList_GeneralInfo clsGeneralInfo = new clsList_GeneralInfo(m_Dal);
            m_Dal.BeginTrans(IsolationLevel.ReadCommitted);
            clsGeneralInfo.TravelInsurance = obj.TravelInsurance;
            clsGeneralInfo.LastUpdatedBy = int.Parse(Session["UserID"].ToString());
            IsSuccess = clsGeneralInfo.Update("TravelInsurance");
            if (IsSuccess)
            {
                m_Dal.CommitTrans(true);
                return Json("...", JsonRequestBehavior.AllowGet);
            }
            else
            {
                m_Dal.AbortTrans();
                return Json("Cập nhật thất bại!", JsonRequestBehavior.AllowGet);
            }
        }

        #endregion TravelInsurance

        #region AgencyPolicy

        public ActionResult AgencyPolicy()
        {
            return View();
        }

        public JsonResult Select_AgencyPolicy()
        {
            DataTable tblListGeneralInfo = clsGeneralInfo.Select_GeneralInfo_By_Code("AgencyPolicy");
            var sql = (from row in tblListGeneralInfo.AsEnumerable()
                       select new
                       {
                           AgencyPolicyDecode = HttpUtility.HtmlDecode(row.Field<string>("AgencyPolicy")),
                       }).AsQueryable();
            return Json(sql.ToList(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult CapNhatChinhSachDaiLy(mGeneralInfo obj)
        {
            bool IsSuccess;
            DataAccess m_Dal = new DataAccess();
            clsList_GeneralInfo clsGeneralInfo = new clsList_GeneralInfo(m_Dal);
            m_Dal.BeginTrans(IsolationLevel.ReadCommitted);
            clsGeneralInfo.AgencyPolicy = obj.AgencyPolicy;
            clsGeneralInfo.LastUpdatedBy = int.Parse(Session["UserID"].ToString());
            IsSuccess = clsGeneralInfo.Update("AgencyPolicy");
            if (IsSuccess)
            {
                m_Dal.CommitTrans(true);
                return Json("...", JsonRequestBehavior.AllowGet);
            }
            else
            {
                m_Dal.AbortTrans();
                return Json("Cập nhật thất bại!", JsonRequestBehavior.AllowGet);
            }
        }

        #endregion AgencyPolicy

        #region Contact

        public ActionResult Contact()
        {
            return View();
        }

        public JsonResult Select_List_GeneralInfo()
        {
            DataTable tblListGeneralInfo = clsGeneralInfo.Select_GeneralInfo_By_Code("General");
            var sql = (from row in tblListGeneralInfo.AsEnumerable()
                       select new
                       {
                           CompanyName = row.Field<string>("CompanyName"),
                           TaxNumber = row.Field<string>("TaxNumber"),
                           CompanyAddress = row.Field<string>("CompanyAddress"),
                           CompanyMail = row.Field<string>("CompanyMail"),
                           Hotline = row.Field<string>("Hotline"),
                           CompanyPhone = row.Field<string>("CompanyPhone"),
                           CompanyFax = row.Field<string>("CompanyFax"),
                           Logo = row.Field<string>("Logo")
                       }).AsQueryable();
            return Json(sql.ToList(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult CapNhatThongTinLienHe(mGeneralInfo obj)
        {
            bool IsSuccess;
            DataAccess m_Dal = new DataAccess();
            clsList_GeneralInfo clsGeneralInfo = new clsList_GeneralInfo(m_Dal);
            m_Dal.BeginTrans(IsolationLevel.ReadCommitted);
            if (obj.Logo == null)
            {
                mUploadImage mUpload = new mUploadImage();
                mUpload.Folder = "Logo";
                mUpload.ImageFile = obj.ImageFile;
                string path = UploadImage(mUpload).ToString();
                string[] a = path.Split('|');
                clsGeneralInfo.Logo = a[1];
            }
            else
            {
                clsGeneralInfo.Logo = obj.Logo;
            }
            clsGeneralInfo.CompanyName = obj.CompanyName;
            clsGeneralInfo.TaxNumber = obj.TaxNumber;
            clsGeneralInfo.CompanyAddress = obj.CompanyAddress;
            clsGeneralInfo.CompanyMail = obj.CompanyMail;
            clsGeneralInfo.Hotline = obj.Hotline;
            clsGeneralInfo.CompanyPhone = obj.CompanyPhone;
            clsGeneralInfo.CompanyFax = obj.CompanyFax;
            clsGeneralInfo.LastUpdatedBy = int.Parse(Session["UserID"].ToString());
            IsSuccess = clsGeneralInfo.Update("General");
            if (IsSuccess)
            {
                m_Dal.CommitTrans(true);
                return Json("...", JsonRequestBehavior.AllowGet);
            }
            else
            {
                m_Dal.AbortTrans();
                return Json("Cập nhật thất bại!", JsonRequestBehavior.AllowGet);
            }
        }

        #endregion Contact

        #region PlaceCategory

        public ActionResult PlaceCategory()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Select_CountryOrPlace_List(bool IsForeign, string Keysearch, int? skip, int? take, int? page, int? pageSize, List<Sort> sort = null, FilterContainer filter = null)
        {
            DataTable tblListCountryOrPlace = clsCountryOrPlace.Select_Country_By_Code(IsForeign, Keysearch);

            int total = tblListCountryOrPlace.Rows.Count;

            if (filter != null && filter.filters != null)
            {
                tblListCountryOrPlace = FilterHelper.FilterDatatable(tblListCountryOrPlace, filter);
                total = tblListCountryOrPlace.Rows.Count;
            }

            var sql = (from row in tblListCountryOrPlace.AsEnumerable()
                       select new
                       {
                           CountryID = row.Field<int>("CountryID"),
                           CountryName = row.Field<string>("CountryName"),
                           IsCountry = row.Field<bool>("IsCountry"),
                           IsForeign = row.Field<bool>("IsForeign")
                       }).AsQueryable();

            if (sort != null && sort.Count >= 0)
            {
                foreach (var s in sort)
                {
                    if (s.dir.ToLower() == "asc")
                    {
                        sql = SortHelper.OrderBy(sql, s.field);
                    }
                    else
                    {
                        sql = SortHelper.OrderByDescending(sql, s.field);
                    }
                }
            }

            if (page.HasValue && pageSize.HasValue)
            {
                int start = (page.Value - 1) * pageSize.Value;
                sql = sql.Skip(start).Take(pageSize.Value);
            }

            var records = sql.ToList();

            return Json(new { records, total }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult CapNhatCountryOrPlace(mCountryOrPlace obj)
        {
            bool IsSuccess;
            DataAccess m_Dal = new DataAccess();
            clsList_CountryOrPlace clsCountryOrPlace = new clsList_CountryOrPlace(m_Dal);
            if (obj.LOAI == "INSERT")
            {
                m_Dal.BeginTrans(IsolationLevel.ReadCommitted);
                clsCountryOrPlace.CountryName = obj.CountryName;
                clsCountryOrPlace.IsForeign = obj.IsForeign;
                clsCountryOrPlace.IsCountry = obj.IsCountry;
                IsSuccess = clsCountryOrPlace.Insert();
                if (IsSuccess)
                {
                    m_Dal.CommitTrans(true);
                    return Json("...", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    m_Dal.AbortTrans();
                    return Json("Cập nhật thất bại!", JsonRequestBehavior.AllowGet);
                }
            }
            else if (obj.LOAI == "UPDATE")
            {
                m_Dal.BeginTrans(IsolationLevel.ReadCommitted);
                clsCountryOrPlace.CountryID = obj.CountryID;
                clsCountryOrPlace.CountryName = obj.CountryName;
                clsCountryOrPlace.IsForeign = obj.IsForeign;
                clsCountryOrPlace.IsCountry = obj.IsCountry;
                IsSuccess = clsCountryOrPlace.Update();
                if (IsSuccess)
                {
                    m_Dal.CommitTrans(true);
                    return Json("...", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    m_Dal.AbortTrans();
                    return Json("Cập nhật thất bại!", JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                int CountryID = obj.CountryID;
                m_Dal.BeginTrans(IsolationLevel.ReadCommitted);
                IsSuccess = clsCountryOrPlace.Delete(CountryID);
                if (IsSuccess)
                {
                    m_Dal.CommitTrans(true);
                    return Json("...", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    m_Dal.AbortTrans();
                    return Json("Cập nhật thất bại!", JsonRequestBehavior.AllowGet);
                }
            }
        }

        #endregion PlaceCategory

        #region BrandCategory

        public ActionResult BrandCategory()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Select_Brand_List(int? skip, int? take, int? page, int? pageSize, List<Sort> sort = null, FilterContainer filter = null)
        {
            DataTable tblListBrand = clsBrand.SelectAll();

            int total = tblListBrand.Rows.Count;

            if (filter != null && filter.filters != null)
            {
                tblListBrand = FilterHelper.FilterDatatable(tblListBrand, filter);
                total = tblListBrand.Rows.Count;
            }

            var sql = (from row in tblListBrand.AsEnumerable()
                       select new
                       {
                           BrandID = row.Field<int>("BrandID"),
                           BrandName = row.Field<string>("BrandName")
                       }).AsQueryable();

            if (sort != null && sort.Count >= 0)
            {
                foreach (var s in sort)
                {
                    if (s.dir.ToLower() == "asc")
                    {
                        sql = SortHelper.OrderBy(sql, s.field);
                    }
                    else
                    {
                        sql = SortHelper.OrderByDescending(sql, s.field);
                    }
                }
            }

            if (page.HasValue && pageSize.HasValue)
            {
                int start = (page.Value - 1) * pageSize.Value;
                sql = sql.Skip(start).Take(pageSize.Value);
            }

            var records = sql.ToList();

            return Json(new { records, total }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult CapNhatDoiTac(mBrand obj)
        {
            bool IsSuccess;
            DataAccess m_Dal = new DataAccess();
            clsList_Brand clsBrand = new clsList_Brand(m_Dal);
            if (obj.LOAI == "INSERT")
            {
                m_Dal.BeginTrans(IsolationLevel.ReadCommitted);
                clsBrand.BrandName = obj.BrandName;
                IsSuccess = clsBrand.Insert();
                if (IsSuccess)
                {
                    m_Dal.CommitTrans(true);
                    return Json("...", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    m_Dal.AbortTrans();
                    return Json("Cập nhật thất bại!", JsonRequestBehavior.AllowGet);
                }
            }
            else if (obj.LOAI == "UPDATE")
            {
                m_Dal.BeginTrans(IsolationLevel.ReadCommitted);
                clsBrand.BrandID = obj.BrandID;
                clsBrand.BrandName = obj.BrandName;
                IsSuccess = clsBrand.Update();
                if (IsSuccess)
                {
                    m_Dal.CommitTrans(true);
                    return Json("...", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    m_Dal.AbortTrans();
                    return Json("Cập nhật thất bại!", JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                int BrandID = obj.BrandID;
                m_Dal.BeginTrans(IsolationLevel.ReadCommitted);
                IsSuccess = clsBrand.Delete(BrandID);
                if (IsSuccess)
                {
                    m_Dal.CommitTrans(true);
                    return Json("...", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    m_Dal.AbortTrans();
                    return Json("Cập nhật thất bại!", JsonRequestBehavior.AllowGet);
                }
            }
        }

        #endregion BrandCategory

        #region Visa

        public ActionResult Visa()
        {
            return View();
        }

        public JsonResult Select_List_VisaCountry()
        {
            DataTable tblListCountryOrPlace = clsCountryOrPlace.SelectAll_VisaCountry();
            var sql = (from row in tblListCountryOrPlace.AsEnumerable()
                       select new
                       {
                           CountryID = row.Field<int>("CountryID"),
                           CountryName = row.Field<string>("CountryName")
                       }).AsQueryable();
            return Json(sql.ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Select_List_Visa(string VisaCountryID, int? skip, int? take, int? page, int? pageSize, List<Sort> sort = null, FilterContainer filter = null)
        {
            DataTable tblListVisa = clsVisa.Select_Visa_By_Code(Convert.ToInt32(VisaCountryID));

            int total = tblListVisa.Rows.Count;

            if (filter != null && filter.filters != null)
            {
                tblListVisa = FilterHelper.FilterDatatable(tblListVisa, filter);
                total = tblListVisa.Rows.Count;
            }

            var sql = (from row in tblListVisa.AsEnumerable()
                       select new
                       {
                           VisaID = row.Field<int>("VisaID"),
                           VisaCountryID = row.Field<int>("VisaCountryID"),
                           CountryName = row.Field<string>("CountryName"),
                           VisaTitle = row.Field<string>("VisaTitle"),
                           VisaContentDecode = HttpUtility.HtmlDecode(row.Field<string>("VisaContent")),
                           VisaImage = row.Field<string>("VisaImage"),
                           CreatedBy = row.Field<string>("CreatedBy"),
                           CreatedDate = (row.Field<DateTime?>("CreatedDate")).HasValue ? row.Field<DateTime>("CreatedDate").ToString("dd/MM/yyyy HH:mm:ss") : "",
                           LastUpdatedBy = row.Field<string>("LastUpdatedBy"),
                           LastUpdatedDate = (row.Field<DateTime?>("LastUpdatedDate")).HasValue ? row.Field<DateTime>("LastUpdatedDate").ToString("dd/MM/yyyy HH:mm:ss") : ""
                       }).AsQueryable();

            if (sort != null && sort.Count >= 0)
            {
                foreach (var s in sort)
                {
                    if (s.dir.ToLower() == "asc")
                    {
                        sql = SortHelper.OrderBy(sql, s.field);
                    }
                    else
                    {
                        sql = SortHelper.OrderByDescending(sql, s.field);
                    }
                }
            }

            if (page.HasValue && pageSize.HasValue)
            {
                int start = (page.Value - 1) * pageSize.Value;
                sql = sql.Skip(start).Take(pageSize.Value);
            }

            var records = sql.ToList();

            return Json(new { records, total }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult CapNhatVisa(mVisa obj)
        {
            bool IsSuccess;
            DataAccess m_Dal = new DataAccess();
            clsList_Visa clsVisa = new clsList_Visa(m_Dal);
            if (obj.LOAI == "INSERT")
            {
                m_Dal.BeginTrans(IsolationLevel.ReadCommitted);
                if (obj.VisaImage == "No Image")
                {
                    clsVisa.VisaImage = "Images/NoImage.jpg";
                }
                else
                {
                    mUploadImage mUpload = new mUploadImage();
                    mUpload.Folder = "VisaImages";
                    mUpload.ImageFile = obj.ImageFile;
                    string path = UploadImage(mUpload).ToString();
                    string[] a = path.Split('|');
                    clsVisa.VisaImage = a[1];
                }
                clsVisa.VisaCountryID = obj.VisaCountryID;
                clsVisa.VisaTitle = obj.VisaTitle;
                clsVisa.VisaContent = obj.VisaContent;
                clsVisa.CreatedBy = int.Parse(Session["UserID"].ToString());
                IsSuccess = clsVisa.Insert();
                if (IsSuccess)
                {
                    m_Dal.CommitTrans(true);
                    return Json("...", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    m_Dal.AbortTrans();
                    return Json("Cập nhật thất bại!", JsonRequestBehavior.AllowGet);
                }
            }
            else if (obj.LOAI == "UPDATE")
            {
                m_Dal.BeginTrans(IsolationLevel.ReadCommitted);
                if (obj.VisaImage == null)
                {
                    mUploadImage mUpload = new mUploadImage();
                    mUpload.Folder = "VisaImages";
                    mUpload.ImageFile = obj.ImageFile;
                    string path = UploadImage(mUpload).ToString();
                    string[] a = path.Split('|');
                    clsVisa.VisaImage = a[1];
                }
                else
                {
                    clsVisa.VisaImage = obj.VisaImage;
                }
                clsVisa.VisaID = obj.VisaID;
                clsVisa.VisaCountryID = obj.VisaCountryID;
                clsVisa.VisaTitle = obj.VisaTitle;
                clsVisa.VisaContent = obj.VisaContent;
                clsVisa.LastUpdatedBy = int.Parse(Session["UserID"].ToString());
                IsSuccess = clsVisa.Update();
                if (IsSuccess)
                {
                    m_Dal.CommitTrans(true);
                    return Json("...", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    m_Dal.AbortTrans();
                    return Json("Cập nhật thất bại!", JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                int VisaID = obj.VisaID;
                m_Dal.BeginTrans(IsolationLevel.ReadCommitted);
                IsSuccess = clsVisa.Delete(VisaID);
                if (IsSuccess)
                {
                    m_Dal.CommitTrans(true);
                    return Json("...", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    m_Dal.AbortTrans();
                    return Json("Cập nhật thất bại!", JsonRequestBehavior.AllowGet);
                }
            }
        }

        #endregion Visa

        #region News

        public ActionResult News()
        {
            return View();
        }

        public JsonResult Select_List_News(string Keysearch, int? skip, int? take, int? page, int? pageSize, List<Sort> sort = null, FilterContainer filter = null)
        {
            DataTable tblListNews = clsNews.Select_News_By_Code(Keysearch);

            int total = tblListNews.Rows.Count;

            if (filter != null && filter.filters != null)
            {
                tblListNews = FilterHelper.FilterDatatable(tblListNews, filter);
                total = tblListNews.Rows.Count;
            }

            var sql = (from row in tblListNews.AsEnumerable()
                       select new
                       {
                           NewsID = row.Field<int>("NewsID"),
                           NewsTitle = row.Field<string>("NewsTitle"),
                           NewsContentDecode = HttpUtility.HtmlDecode(row.Field<string>("NewsContent")),
                           NewsImage = row.Field<string>("NewsImage"),
                           CreatedBy = row.Field<string>("CreatedBy"),
                           CreatedDate = (row.Field<DateTime?>("CreatedDate")).HasValue ? row.Field<DateTime>("CreatedDate").ToString("dd/MM/yyyy HH:mm:ss") : "",
                           LastUpdatedBy = row.Field<string>("LastUpdatedBy"),
                           LastUpdatedDate = (row.Field<DateTime?>("LastUpdatedDate")).HasValue ? row.Field<DateTime>("LastUpdatedDate").ToString("dd/MM/yyyy HH:mm:ss") : ""

                       }).AsQueryable();

            if (sort != null && sort.Count >= 0)
            {
                foreach (var s in sort)
                {
                    if (s.dir.ToLower() == "asc")
                    {
                        sql = SortHelper.OrderBy(sql, s.field);
                    }
                    else
                    {
                        sql = SortHelper.OrderByDescending(sql, s.field);
                    }
                }
            }

            if (page.HasValue && pageSize.HasValue)
            {
                int start = (page.Value - 1) * pageSize.Value;
                sql = sql.Skip(start).Take(pageSize.Value);
            }

            var records = sql.ToList();

            return Json(new { records, total }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult CapNhatTinTuc(mNews obj)
        {
            bool IsSuccess;
            DataAccess m_Dal = new DataAccess();
            clsList_News clsNews = new clsList_News(m_Dal);
            if (obj.LOAI == "INSERT")
            {
                m_Dal.BeginTrans(IsolationLevel.ReadCommitted);
                if (obj.NewsImage == "No Image")
                {
                    clsNews.NewsImage = "Images/NoImage.jpg";
                }
                else
                {
                    mUploadImage mUpload = new mUploadImage();
                    mUpload.Folder = "NewsImages";
                    mUpload.ImageFile = obj.ImageFile;
                    string path = UploadImage(mUpload).ToString();
                    string[] a = path.Split('|');
                    clsNews.NewsImage = a[1];
                }
                clsNews.NewsTitle = obj.NewsTitle;
                clsNews.NewsContent = obj.NewsContent;
                clsNews.CreatedBy = int.Parse(Session["UserID"].ToString());
                IsSuccess = clsNews.Insert();
                if (IsSuccess)
                {
                    m_Dal.CommitTrans(true);
                    return Json("...", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    m_Dal.AbortTrans();
                    return Json("Cập nhật thất bại!", JsonRequestBehavior.AllowGet);
                }
            }
            else if (obj.LOAI == "UPDATE")
            {
                m_Dal.BeginTrans(IsolationLevel.ReadCommitted);
                if (obj.NewsImage == null)
                {
                    mUploadImage mUpload = new mUploadImage();
                    mUpload.Folder = "NewsImages";
                    mUpload.ImageFile = obj.ImageFile;
                    string path = UploadImage(mUpload).ToString();
                    string[] a = path.Split('|');
                    clsNews.NewsImage = a[1];
                }
                else
                {
                    clsNews.NewsImage = obj.NewsImage;
                }
                clsNews.NewsID = obj.NewsID;
                clsNews.NewsTitle = obj.NewsTitle;
                clsNews.NewsContent = obj.NewsContent;
                clsNews.LastUpdatedBy = int.Parse(Session["UserID"].ToString());
                IsSuccess = clsNews.Update();
                if (IsSuccess)
                {
                    m_Dal.CommitTrans(true);
                    return Json("...", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    m_Dal.AbortTrans();
                    return Json("Cập nhật thất bại!", JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                int NewsID = obj.NewsID;
                m_Dal.BeginTrans(IsolationLevel.ReadCommitted);
                IsSuccess = clsNews.Delete(NewsID);
                if (IsSuccess)
                {
                    m_Dal.CommitTrans(true);
                    return Json("...", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    m_Dal.AbortTrans();
                    return Json("Cập nhật thất bại!", JsonRequestBehavior.AllowGet);
                }
            }
        }

        #endregion News

        #region Account

        public ActionResult Account()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Select_List_Account(int? skip, int? take, int? page, int? pageSize, List<Sort> sort = null, FilterContainer filter = null)
        {
            DataTable tblListAccount = clsAccount.SelectAll();

            int total = tblListAccount.Rows.Count;

            if (filter != null && filter.filters != null)
            {
                tblListAccount = FilterHelper.FilterDatatable(tblListAccount, filter);
                total = tblListAccount.Rows.Count;
            }

            var sql = (from row in tblListAccount.AsEnumerable()
                       select new
                       {
                           UserID = row.Field<int>("UserID"),
                           UserName = row.Field<string>("UserName"),
                           FullName = row.Field<string>("FullName"),
                           OriginalPassword = row.Field<string>("OriginalPassword"),
                           Gender = row.Field<bool>("Gender"),
                           UserAddress = row.Field<string>("UserAddress"),
                           DeskphoneNo = row.Field<string>("DeskphoneNo"),
                           PhoneNo = row.Field<string>("PhoneNo"),
                           EmailAddress = row.Field<string>("EmailAddress"),
                           SkypeAccount = row.Field<string>("SkypeAccount"),
                           IsConsultant = row.Field<bool>("IsConsultant"),
                           UserImage = row.Field<string>("UserImage"),
                           CreatedBy = row.Field<string>("CreatedBy"),
                           CreatedDate = (row.Field<DateTime?>("CreatedDate")).HasValue ? row.Field<DateTime>("CreatedDate").ToString("dd/MM/yyyy HH:mm:ss") : "",
                           LastUpdatedBy = row.Field<string>("LastUpdatedBy"),
                           LastUpdatedDate = (row.Field<DateTime?>("LastUpdatedDate")).HasValue ? row.Field<DateTime>("LastUpdatedDate").ToString("dd/MM/yyyy HH:mm:ss") : ""
                       }).AsQueryable();

            if (sort != null && sort.Count >= 0)
            {
                foreach (var s in sort)
                {
                    if (s.dir.ToLower() == "asc")
                    {
                        sql = SortHelper.OrderBy(sql, s.field);
                    }
                    else
                    {
                        sql = SortHelper.OrderByDescending(sql, s.field);
                    }
                }
            }

            if (page.HasValue && pageSize.HasValue)
            {
                int start = (page.Value - 1) * pageSize.Value;
                sql = sql.Skip(start).Take(pageSize.Value);
            }

            var records = sql.ToList();

            return Json(new { records, total }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult CapNhatTaiKhoan(mAccount obj)
        {
            bool IsSuccess;
            DataAccess m_Dal = new DataAccess();
            clsList_Account clsAccount = new clsList_Account(m_Dal);
            DataTable tblListAccount = clsAccount.Select_SALT_By_UserName(obj.UserName);
            if (obj.LOAI == "INSERT")
            {
                m_Dal.BeginTrans(IsolationLevel.ReadCommitted);
                if (obj.UserImage == "No Image")
                {
                    clsAccount.UserImage = "Images/NoImage.jpg";
                }
                else
                {
                    mUploadImage mUpload = new mUploadImage();
                    mUpload.Folder = "UserImages";
                    mUpload.ImageFile = obj.ImageFile;
                    string path = UploadImage(mUpload).ToString();
                    string[] a = path.Split('|');
                    clsAccount.UserImage = a[1];
                }
                clsAccount.UserName = obj.UserName;
                clsAccount.SALT = String.Format("{0:yyyyMMddHHmmss}", DateTime.Now);
                clsAccount.OriginalPassword = obj.Password;
                clsAccount.UserPassword = clsEncrypt.MD5(obj.Password, clsAccount.SALT, true);
                clsAccount.FullName = obj.FullName;
                clsAccount.Gender = obj.Gender;
                clsAccount.UserAddress = obj.UserAddress;
                clsAccount.DeskphoneNo = obj.DeskphoneNo;
                clsAccount.PhoneNo = obj.PhoneNo;
                clsAccount.EmailAddress = obj.EmailAddress;
                clsAccount.SkypeAccount = obj.SkypeAccount;
                clsAccount.IsConsultant = obj.IsConsultant;
                clsAccount.CreatedBy = int.Parse(Session["UserID"].ToString());
                IsSuccess = clsAccount.Insert();
                if (IsSuccess)
                {
                    m_Dal.CommitTrans(true);
                    return Json("...", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    m_Dal.AbortTrans();
                    return Json("Cập nhật thất bại!", JsonRequestBehavior.AllowGet);
                }
            }
            else if (obj.LOAI == "UPDATE")
            {
                m_Dal.BeginTrans(IsolationLevel.ReadCommitted);
                if (obj.UserImage == null)
                {
                    mUploadImage mUpload = new mUploadImage();
                    mUpload.Folder = "UserImages";
                    mUpload.ImageFile = obj.ImageFile;
                    string path = UploadImage(mUpload).ToString();
                    string[] a = path.Split('|');
                    clsAccount.UserImage = a[1];
                }
                else
                {
                    clsAccount.UserImage = obj.UserImage;
                }
                clsAccount.UserID = obj.UserID;
                clsAccount.UserName = obj.UserName;
                clsAccount.OriginalPassword = obj.Password;
                string SALT = tblListAccount.Rows[0][3].ToString();
                clsAccount.UserPassword = clsEncrypt.MD5(obj.Password, SALT, true);
                clsAccount.FullName = obj.FullName;
                clsAccount.Gender = obj.Gender;
                clsAccount.UserAddress = obj.UserAddress;
                clsAccount.DeskphoneNo = obj.DeskphoneNo;
                clsAccount.PhoneNo = obj.PhoneNo;
                clsAccount.EmailAddress = obj.EmailAddress;
                clsAccount.SkypeAccount = obj.SkypeAccount;
                clsAccount.IsConsultant = obj.IsConsultant;
                clsAccount.LastUpdatedBy = int.Parse(Session["UserID"].ToString());
                IsSuccess = clsAccount.Update();
                if (IsSuccess)
                {
                    m_Dal.CommitTrans(true);
                    return Json("...", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    m_Dal.AbortTrans();
                    return Json("Cập nhật thất bại!", JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                int UserID = obj.UserID;
                m_Dal.BeginTrans(IsolationLevel.ReadCommitted);
                clsAccount.LastUpdatedBy = 3;
                IsSuccess = clsAccount.Delete(UserID);
                if (IsSuccess)
                {
                    m_Dal.CommitTrans(true);
                    return Json("...", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    m_Dal.AbortTrans();
                    return Json("Cập nhật thất bại!", JsonRequestBehavior.AllowGet);
                }
            }
        }

        #endregion Account

        #region TicketAndTour

        #region Category

        public JsonResult Select_List_ProductCategory()
        {
            DataTable tblListProductCategory = clsProductCategory.SelectAll();
            var sql = (from row in tblListProductCategory.AsEnumerable()
                       select new
                       {
                           ProductCategoryID = row.Field<int>("ProductCategoryID"),
                           ProductCategoryName = row.Field<string>("ProductCategoryName")
                       }).AsQueryable();
            return Json(sql.ToList(), JsonRequestBehavior.AllowGet);
        }
        
        public JsonResult Select_List_CountryOrPlace(bool IsForeign)
        {
            DataTable tblListCountryOrPlace = clsCountryOrPlace.SelectAll(IsForeign);
            var sql = (from row in tblListCountryOrPlace.AsEnumerable()
                       select new
                       {
                           CountryID = row.Field<int>("CountryID"),
                           CountryName = row.Field<string>("CountryName")
                       }).AsQueryable();
            return Json(sql.ToList(), JsonRequestBehavior.AllowGet);
        }
        
        public JsonResult Select_List_Brand()
        {
            DataTable tblListBrand = clsBrand.SelectAll();
            var sql = (from row in tblListBrand.AsEnumerable()
                       select new
                       {
                           BrandID = row.Field<int>("BrandID"),
                           BrandName = row.Field<string>("BrandName")
                       }).AsQueryable();
            return Json(sql.ToList(), JsonRequestBehavior.AllowGet);
        }
        
        public JsonResult Select_List_ProductStatus()
        {
            DataTable tblListProductStatus = clsProductStatus.SelectAll();
            var sql = (from row in tblListProductStatus.AsEnumerable()
                       select new
                       {
                           ProductStatusID = row.Field<int>("ProductStatusID"),
                           ProductStatusName = row.Field<string>("ProductStatusName")
                       }).AsQueryable();
            return Json(sql.ToList(), JsonRequestBehavior.AllowGet);
        }

        #endregion Category

        [HttpGet]
        public ActionResult TicketAndTour()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TicketAndTour(FormCollection f)
        {
            return View();
        }

        public JsonResult Select_List_Product(string ProductTypeID, string Keysearch, int? skip, int? take, int? page, int? pageSize, List<Sort> sort = null, FilterContainer filter = null)
        {
            DataTable tblListProduct = clsProduct.Select_Product_By_Code(Convert.ToInt32(ProductTypeID), Keysearch);

            int total = tblListProduct.Rows.Count;

            if (filter != null && filter.filters != null)
            {
                tblListProduct = FilterHelper.FilterDatatable(tblListProduct, filter);
                total = tblListProduct.Rows.Count;
            }

            var sql = (from row in tblListProduct.AsEnumerable()
                       select new
                       {
                           ProductID = row.Field<int>("ProductID"),
                           ProductTypeID = row.Field<int>("ProductTypeID"),
                           ProductCategoryID = row.Field<int>("ProductCategoryID"),
                           ProductGroupID = row.Field<int>("ProductGroupID"),
                           ProductCategoryName = row.Field<string>("ProductCategoryName"),
                           ProductName = row.Field<string>("ProductName"),
                           LeavingFrom = row.Field<int>("LeavingFrom"),
                           LeavingFromName = row.Field<string>("LeavingFromName"),
                           GoingTo = row.Field<int>("GoingTo"),
                           GoingToName = row.Field<string>("GoingToName"),
                           BrandID = row.Field<int>("BrandID"),
                           BrandName = row.Field<string>("BrandName"),
                           ProductEffectedDate = (row.Field<DateTime?>("ProductEffectedDate")).HasValue ? row.Field<DateTime>("ProductEffectedDate").ToString("dd/MM/yyyy") : "",
                           ProductPrice = row.Field<double>("ProductPrice"),
                           ProductContentDecode = HttpUtility.HtmlDecode(row.Field<string>("ProductContent")),
                           ProductImage = row.Field<string>("ProductImage"),
                           ProductStatus = row.Field<int>("ProductStatus"),
                           CreatedBy = row.Field<string>("CreatedBy"),
                           CreatedDate = (row.Field<DateTime?>("CreatedDate")).HasValue ? row.Field<DateTime>("CreatedDate").ToString("dd/MM/yyyy HH:mm:ss") : "",
                           LastUpdatedBy = row.Field<string>("LastUpdatedBy"),
                           LastUpdatedDate = (row.Field<DateTime?>("LastUpdatedDate")).HasValue ? row.Field<DateTime>("LastUpdatedDate").ToString("dd/MM/yyyy HH:mm:ss") : ""
                       }).AsQueryable();

            if (sort != null && sort.Count >= 0)
            {
                foreach (var s in sort)
                {
                    if (s.dir.ToLower() == "asc")
                    {
                        sql = SortHelper.OrderBy(sql, s.field);
                    }
                    else
                    {
                        sql = SortHelper.OrderByDescending(sql, s.field);
                    }
                }
            }

            if (page.HasValue && pageSize.HasValue)
            {
                int start = (page.Value - 1) * pageSize.Value;
                sql = sql.Skip(start).Take(pageSize.Value);
            }

            var records = sql.ToList();

            return Json(new { records, total }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult CapNhatVeTour(mProduct obj)
        {
            bool IsSuccess;
            DataAccess m_Dal = new DataAccess();
            clsList_Product clsProduct = new clsList_Product(m_Dal);
            if (obj.LOAI == "INSERT")
            {
                m_Dal.BeginTrans(IsolationLevel.ReadCommitted);
                if (obj.ProductImage == "No Image")
                {
                    clsProduct.ProductImage = "Images/NoImage.jpg";
                }
                else
                {
                    mUploadImage mUpload = new mUploadImage();
                    mUpload.Folder = "ProductImages";
                    mUpload.ImageFile = obj.ImageFile;
                    string path = UploadImage(mUpload).ToString();
                    string[] a = path.Split('|');
                    clsProduct.ProductImage = a[1];
                }
                clsProduct.ProductTypeID = obj.ProductTypeID;
                clsProduct.ProductCategoryID = obj.ProductCategoryID;
                clsProduct.ProductGroupID = obj.ProductGroupID;
                clsProduct.ProductName = obj.ProductName;
                clsProduct.LeavingFrom = obj.LeavingFrom;
                clsProduct.GoingTo = obj.GoingTo;
                clsProduct.BrandID = obj.BrandID;
                clsProduct.ProductEffectedDate = clsCommon.ChangeDate(obj.ProductEffectedDate);
                clsProduct.ProductPrice = obj.ProductPrice;
                clsProduct.ProductContent = obj.ProductContent;
                clsProduct.ProductStatus = obj.ProductStatus;
                clsProduct.CreatedBy = int.Parse(Session["UserID"].ToString());
                IsSuccess = clsProduct.Insert();
                if (IsSuccess)
                {
                    m_Dal.CommitTrans(true);
                    return Json("...", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    m_Dal.AbortTrans();
                    return Json("Cập nhật thất bại!", JsonRequestBehavior.AllowGet);
                }
            }
            else if (obj.LOAI == "UPDATE")
            {
                m_Dal.BeginTrans(IsolationLevel.ReadCommitted);
                if (obj.ProductImage == null)
                {
                    mUploadImage mUpload = new mUploadImage();
                    mUpload.Folder = "ProductImages";
                    mUpload.ImageFile = obj.ImageFile;
                    string path = UploadImage(mUpload).ToString();
                    string[] a = path.Split('|');
                    clsProduct.ProductImage = a[1];
                }
                else
                {
                    clsProduct.ProductImage = obj.ProductImage;
                }
                clsProduct.ProductID = obj.ProductID;
                clsProduct.ProductTypeID = obj.ProductTypeID;
                clsProduct.ProductCategoryID = obj.ProductCategoryID;
                clsProduct.ProductGroupID = obj.ProductGroupID;
                clsProduct.ProductName = obj.ProductName;
                clsProduct.LeavingFrom = obj.LeavingFrom;
                clsProduct.GoingTo = obj.GoingTo;
                clsProduct.BrandID = obj.BrandID;
                clsProduct.ProductEffectedDate = clsCommon.ChangeDate(obj.ProductEffectedDate);
                clsProduct.ProductPrice = obj.ProductPrice;
                clsProduct.ProductContent = obj.ProductContent;
                clsProduct.ProductStatus = obj.ProductStatus;
                clsProduct.LastUpdatedBy = int.Parse(Session["UserID"].ToString());
                IsSuccess = clsProduct.Update();
                if (IsSuccess)
                {
                    m_Dal.CommitTrans(true);
                    return Json("...", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    m_Dal.AbortTrans();
                    return Json("Cập nhật thất bại!", JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                int ProductID = obj.ProductID;
                m_Dal.BeginTrans(IsolationLevel.ReadCommitted);
                IsSuccess = clsProduct.Delete(ProductID);
                if (IsSuccess)
                {
                    m_Dal.CommitTrans(true);
                    return Json("...", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    m_Dal.AbortTrans();
                    return Json("Cập nhật thất bại!", JsonRequestBehavior.AllowGet);
                }
            }
        }

        #endregion TicketAndTour

        #region EmailRegister

        public ActionResult EmailRegister()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Select_List_EmailRegister(string Keysearch, int? skip, int? take, int? page, int? pageSize, List<Sort> sort = null, FilterContainer filter = null)
        {
            DataTable tblListEmailRegister = clsEmailRegister.Select_News_By_Code(Keysearch);

            int total = tblListEmailRegister.Rows.Count;

            if (filter != null && filter.filters != null)
            {
                tblListEmailRegister = FilterHelper.FilterDatatable(tblListEmailRegister, filter);
                total = tblListEmailRegister.Rows.Count;
            }

            var sql = (from row in tblListEmailRegister.AsEnumerable()
                       select new
                       {
                           Customer_EmailRegister_ID = row.Field<int>("Customer_EmailRegister_ID"),
                           Customer_EmailRegister_Name = row.Field<string>("Customer_EmailRegister_Name"),
                           Customer_EmailRegister_Email = row.Field<string>("Customer_EmailRegister_Email"),
                           Customer_EmailRegister_Content = row.Field<string>("Customer_EmailRegister_Content"),
                           CreatedDate = (row.Field<DateTime?>("CreatedDate")).HasValue ? row.Field<DateTime>("CreatedDate").ToString("dd/MM/yyyy HH:mm:ss") : ""
                       }).AsQueryable();

            if (sort != null && sort.Count >= 0)
            {
                foreach (var s in sort)
                {
                    if (s.dir.ToLower() == "asc")
                    {
                        sql = SortHelper.OrderBy(sql, s.field);
                    }
                    else
                    {
                        sql = SortHelper.OrderByDescending(sql, s.field);
                    }
                }
            }

            if (page.HasValue && pageSize.HasValue)
            {
                int start = (page.Value - 1) * pageSize.Value;
                sql = sql.Skip(start).Take(pageSize.Value);
            }

            var records = sql.ToList();

            return Json(new { records, total }, JsonRequestBehavior.AllowGet);
        }

        #endregion EmailRegister

        #region PriceQuotation

        public ActionResult PriceQuotation()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Select_List_PriceQuotation(string Keysearch, int? skip, int? take, int? page, int? pageSize, List<Sort> sort = null, FilterContainer filter = null)
        {
            DataTable tblListPriceQuotation = clsPriceQuotation.Select_News_By_Code(Keysearch);

            int total = tblListPriceQuotation.Rows.Count;

            if (filter != null && filter.filters != null)
            {
                tblListPriceQuotation = FilterHelper.FilterDatatable(tblListPriceQuotation, filter);
                total = tblListPriceQuotation.Rows.Count;
            }

            var sql = (from row in tblListPriceQuotation.AsEnumerable()
                       select new
                       {
                           Customer_PriceQuotation_ID = row.Field<int>("Customer_PriceQuotation_ID"),
                           Customer_PriceQuotation_Name = row.Field<string>("Customer_PriceQuotation_Name"),
                           Customer_PriceQuotation_Phone = row.Field<string>("Customer_PriceQuotation_Phone"),
                           Customer_PriceQuotation_Email = row.Field<string>("Customer_PriceQuotation_Email"),
                           Customer_PriceQuotation_Content = row.Field<string>("Customer_PriceQuotation_Content"),
                           Customer_PriceQuotation_DateFlight = (row.Field<DateTime?>("Customer_PriceQuotation_DateFlight")).HasValue ? row.Field<DateTime>("Customer_PriceQuotation_DateFlight").ToString("dd/MM/yyyy") : "",
                           CreatedDate = (row.Field<DateTime?>("CreatedDate")).HasValue ? row.Field<DateTime>("CreatedDate").ToString("dd/MM/yyyy HH:mm:ss") : ""
                       }).AsQueryable();

            if (sort != null && sort.Count >= 0)
            {
                foreach (var s in sort)
                {
                    if (s.dir.ToLower() == "asc")
                    {
                        sql = SortHelper.OrderBy(sql, s.field);
                    }
                    else
                    {
                        sql = SortHelper.OrderByDescending(sql, s.field);
                    }
                }
            }

            if (page.HasValue && pageSize.HasValue)
            {
                int start = (page.Value - 1) * pageSize.Value;
                sql = sql.Skip(start).Take(pageSize.Value);
            }

            var records = sql.ToList();

            return Json(new { records, total }, JsonRequestBehavior.AllowGet);
        }

        #endregion PriceQuotation

        [HttpPost]
        public ActionResult Update_List_Visa(FormCollection f)
        {
            bool IsSuccess = false;
            string LOAI = Request["LOAI"];
            DataAccess m_Dal = new DataAccess();
            clsList_Visa clsVisa = new clsList_Visa(m_Dal);
            if (LOAI == "INSERT")
            {
                int VisaCountryID = int.Parse(Request["VisaCountryID"]);
                string VisaTitle = Request["VisaTitle"];
                string VisaImage = Request["VisaImage"];
                string VisaContent = Request["VisaContent"];

                m_Dal.BeginTrans(IsolationLevel.ReadCommitted);
                clsVisa.VisaCountryID = VisaCountryID;
                clsVisa.VisaTitle = VisaTitle;
                clsVisa.VisaImage = VisaImage;
                clsVisa.VisaContent = HttpUtility.HtmlEncode(VisaContent);
                clsVisa.CreatedBy = int.Parse(Session["UserID"].ToString());
                IsSuccess = clsVisa.Insert();
                if (IsSuccess)
                {
                    m_Dal.CommitTrans(true);
                    return Content("...");
                }
                else
                {
                    m_Dal.AbortTrans();
                    return Content("Thêm mới thất bại!");
                }
            }
            else if (LOAI == "UPDATE")
            {
                m_Dal.BeginTrans(IsolationLevel.ReadCommitted);
                clsVisa.VisaID = int.Parse(Request["VisaID"]);
                clsVisa.VisaCountryID = int.Parse(Request["VisaCountryID"]);
                clsVisa.VisaTitle = Request["VisaTitle"];
                clsVisa.VisaImage = Request["VisaImage"];
                clsVisa.VisaContent = Request["VisaContent"];
                clsVisa.LastUpdatedBy = int.Parse(Session["UserID"].ToString());
                IsSuccess = clsVisa.Update();
                if (IsSuccess)
                {
                    m_Dal.CommitTrans(true);
                    return Content("...");
                }
                else
                {
                    m_Dal.AbortTrans();
                    return Content("Cập nhật thất bại!");
                }
            }
            else
            {
                int VisaID = int.Parse(Request["VisaID"]);
                m_Dal.BeginTrans(IsolationLevel.ReadCommitted);
                IsSuccess = clsVisa.Delete(VisaID);
                if (IsSuccess)
                {
                    m_Dal.CommitTrans(true);
                    return Content("...");
                }
                else
                {
                    m_Dal.AbortTrans();
                    return Content("Xóa thất bại!");
                }
            }
        }

        public string UploadImage(mUploadImage obj)
        {
            var imgImageUpload = obj.ImageFile;
            var Folder = obj.Folder;
            string path = "";
            string savePath = "";
            string fileName = "";
            if (imgImageUpload.ContentLength > 0 || imgImageUpload != null)
            {
                fileName = Path.GetFileName(imgImageUpload.FileName);
                if (Folder == "Banner")
                {
                    path = Path.Combine(Server.MapPath("~/Images/Banner/") + fileName);
                    savePath = "Images/Banner/" + fileName;
                }
                if (Folder == "Logo")
                {
                    path = Path.Combine(Server.MapPath("~/Images/Logo/") + fileName);
                    savePath = "Images/Logo/" + fileName;
                }
                if (Folder == "NewsImages")
                {
                    path = Path.Combine(Server.MapPath("~/Images/NewsImages/") + fileName);
                    savePath = "Images/NewsImages/" + fileName;
                }
                if (Folder == "ProductImages")
                {
                    path = Path.Combine(Server.MapPath("~/Images/ProductImages/") + fileName);
                    savePath = "Images/ProductImages/" + fileName;
                }
                if (Folder == "UserImages")
                {
                    path = Path.Combine(Server.MapPath("~/Images/UserImages/") + fileName);
                    savePath = "Images/UserImages/" + fileName;
                }
                if (Folder == "VisaImages")
                {
                    path = Path.Combine(Server.MapPath("~/Images/VisaImages/") + fileName);
                    savePath = "Images/VisaImages/" + fileName;
                }
                imgImageUpload.SaveAs(path);
            }
            else
            {
                savePath = "Images/NoImages.jpg";
            }

            return fileName + "|" + savePath;
        }

        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
        public sealed class NoCacheAttribute : ActionFilterAttribute
        {
            public override void OnResultExecuting(ResultExecutingContext filterContext)
            {
                filterContext.HttpContext.Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
                filterContext.HttpContext.Response.Cache.SetValidUntilExpires(false);
                filterContext.HttpContext.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
                filterContext.HttpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                filterContext.HttpContext.Response.Cache.SetNoStore();

                base.OnResultExecuting(filterContext);
            }
        }
    }
}