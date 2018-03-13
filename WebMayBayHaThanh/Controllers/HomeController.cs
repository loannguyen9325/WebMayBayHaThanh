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

using System.Web.Routing;
using PagedList.Mvc;
using PagedList;

namespace WebMayBayHaThanh.Controllers
{
    [NoCache]
    public class HomeController : Controller
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
        clsList_Others clsOthers = new clsList_Others();

        #endregion

        #region Homepage

        public ActionResult Index()
        {
            DataTable tblListBanner = clsBanner.SelectAllActiveBanner();
            DataTable tblListNews = clsNews.Select_News_By_Code("");
            Session.RemoveAll();
            Session["ActiveBanner"] = tblListBanner;
            Session["ListNews"] = tblListNews;
            return View();
        }

        public JsonResult Select_List_VisaCountry()
        {
            DataTable tblListCountryOrPlace = clsCountryOrPlace.Select_VisaCountry();
            var sql = (from row in tblListCountryOrPlace.AsEnumerable()
                       select new
                       {
                           CountryID = row.Field<int>("CountryID"),
                           CountryName = row.Field<string>("CountryName")
                       }).AsQueryable();
            return Json(sql.ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Select_Top8_Newest_Post()
        {
            DataTable tblListProduct = clsProduct.Select_Top8_Newest_Post();
            var sql = (from row in tblListProduct.AsEnumerable()
                       select new
                       {
                           ProductID = row.Field<int>("ProductID"),
                           ProductName = row.Field<string>("ProductName"),
                           ProductImage = row.Field<string>("ProductImage"),
                           ProductStatus = row.Field<int>("ProductStatus"),
                           BrandName = row.Field<string>("BrandName"),
                           CreatedDate = (row.Field<DateTime?>("CreatedDate")).HasValue ? row.Field<DateTime>("CreatedDate").ToString("dd/MM/yyyy") : ""
                       }).AsQueryable();
            return Json(sql.ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Select_Top8_Cheapest_Post()
        {
            DataTable tblListProduct = clsProduct.Select_Top8_Cheapest_Post();
            var sql = (from row in tblListProduct.AsEnumerable()
                       select new
                       {
                           ProductID = row.Field<int>("ProductID"),
                           LeavingFromName = row.Field<string>("LeavingFromName"),
                           GoingToName = row.Field<string>("GoingToName"),
                           ProductImage = row.Field<string>("ProductImage"),
                           ProductStatus = row.Field<int>("ProductStatus"),
                           BrandName = row.Field<string>("BrandName"),
                           FormattedProductPrice = row.Field<string>("FormattedProductPrice")
                       }).AsQueryable();
            return Json(sql.ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Select_Top2_Consultant()
        {
            DataTable tblListAccount = clsAccount.Select_Top2_Consultant();
            var sql = (from row in tblListAccount.AsEnumerable()
                       select new
                       {
                           UserID = row.Field<int>("UserID"),
                           FullName = row.Field<string>("FullName"),
                           Gender = row.Field<bool>("Gender"),
                           DeskphoneNo = row.Field<string>("DeskphoneNo"),
                           PhoneNo = row.Field<string>("PhoneNo"),
                           EmailAddress = row.Field<string>("EmailAddress"),
                           SkypeAccount = row.Field<string>("SkypeAccount"),
                           UserImage = row.Field<string>("UserImage"),
                       }).AsQueryable();
            return Json(sql.ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Select_Total_Sale_Post()
        {
            DataTable tblListProduct = clsProduct.Select_Total_Sale_Post();
            var sql = (from row in tblListProduct.AsEnumerable()
                       select new
                       {
                           TotalSalePost = row.Field<int>("TotalSalePost")
                       }).AsQueryable();
            return Json(sql.ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Select_Total_Domestic_Post()
        {
            DataTable tblListProduct = clsProduct.Select_Total_Domestic_Post();
            var sql = (from row in tblListProduct.AsEnumerable()
                       select new
                       {
                           TotalDomesticPost = row.Field<int>("TotalDomesticPost")
                       }).AsQueryable();
            return Json(sql.ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Select_Total_Foreign_Post()
        {
            DataTable tblListProduct = clsProduct.Select_Total_Foreign_Post();
            var sql = (from row in tblListProduct.AsEnumerable()
                       select new
                       {
                           TotalForeignPost = row.Field<int>("TotalForeignPost")
                       }).AsQueryable();
            return Json(sql.ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Select_Total_Other_Post()
        {
            DataTable tblListOthers = clsOthers.Select_Total_Other_Post();
            var sql = (from row in tblListOthers.AsEnumerable()
                       select new
                       {
                           TotalOtherPost = row.Field<int>("TotalOtherPost")
                       }).AsQueryable();
            return Json(sql.ToList(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult CapNhatDangKyBaiViet(mCustomer_EmailRegister obj)
        {
            bool IsSuccess;
            DataAccess m_Dal = new DataAccess();
            clsList_Customer_EmailRegister clsCustomer_EmailRegister = new clsList_Customer_EmailRegister(m_Dal);
            if (obj.LOAI == "INSERT")
            {
                m_Dal.BeginTrans(IsolationLevel.ReadCommitted);
                clsCustomer_EmailRegister.Customer_EmailRegister_Name = obj.Customer_EmailRegister_Name;
                clsCustomer_EmailRegister.Customer_EmailRegister_Email = obj.Customer_EmailRegister_Email;
                clsCustomer_EmailRegister.Customer_EmailRegister_Content = obj.Customer_EmailRegister_Content;
                IsSuccess = clsCustomer_EmailRegister.Insert();
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
                int Customer_EmailRegister_ID = obj.Customer_EmailRegister_ID;
                m_Dal.BeginTrans(IsolationLevel.ReadCommitted);
                IsSuccess = clsCustomer_EmailRegister.Delete(Customer_EmailRegister_ID);
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

        [HttpPost]
        public JsonResult CapNhatDangKyNhanBaoGia(mCustomer_PriceQuotation obj)
        {
            bool IsSuccess;
            DataAccess m_Dal = new DataAccess();
            clsList_Customer_PriceQuotation clsCustomer_PriceQuotation = new clsList_Customer_PriceQuotation(m_Dal);
            if (obj.LOAI == "INSERT")
            {
                m_Dal.BeginTrans(IsolationLevel.ReadCommitted);
                clsCustomer_PriceQuotation.Customer_PriceQuotation_Name = obj.Customer_PriceQuotation_Name;
                clsCustomer_PriceQuotation.Customer_PriceQuotation_Phone = obj.Customer_PriceQuotation_Phone;
                clsCustomer_PriceQuotation.Customer_PriceQuotation_Email = obj.Customer_PriceQuotation_Email;
                clsCustomer_PriceQuotation.Customer_PriceQuotation_Content = obj.Customer_PriceQuotation_Content;
                clsCustomer_PriceQuotation.Customer_PriceQuotation_DateFlight = clsCommon.ChangeDate(obj.Customer_PriceQuotation_DateFlight);
                IsSuccess = clsCustomer_PriceQuotation.Insert();
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
                int Customer_PriceQuotation_ID = obj.Customer_PriceQuotation_ID;
                m_Dal.BeginTrans(IsolationLevel.ReadCommitted);
                IsSuccess = clsCustomer_PriceQuotation.Delete(Customer_PriceQuotation_ID);
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

        #endregion Homepage

        #region About

        public ActionResult About()
        {
            DataTable tblListBanner = clsBanner.SelectAllActiveBanner();
            Session.RemoveAll();
            Session["ActiveBanner"] = tblListBanner;
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

        #endregion About

        #region TicketAndTour

        public ActionResult TicketAndTour(int? page)
        {
            DataTable tblListBanner = clsBanner.SelectAllActiveBanner();
            Session.RemoveAll();
            Session["ActiveBanner"] = tblListBanner;

            string ProductCategoryID = Request.QueryString["id"];
            if (String.IsNullOrEmpty(ProductCategoryID))
            {
                ProductCategoryID = Request.QueryString["ID"];
                if (String.IsNullOrEmpty(ProductCategoryID))
                {
                    ProductCategoryID = Request.QueryString["Id"];
                    if (String.IsNullOrEmpty(ProductCategoryID))
                    {
                        ProductCategoryID = Request.QueryString["iD"];
                    }
                }
            }

            //string Keysearch = Request.QueryString["key"];
            //if (String.IsNullOrEmpty(Keysearch))
            //{
            //    Keysearch = Request.QueryString["KEY"];
            //    if (String.IsNullOrEmpty(Keysearch))
            //    {
            //        Keysearch = Request.QueryString["Key"];
            //        if (String.IsNullOrEmpty(Keysearch))
            //        {
            //            Keysearch = Request.QueryString["KEy"];
            //            if (String.IsNullOrEmpty(Keysearch))
            //            {
            //                Keysearch = Request.QueryString["KeY"];
            //                if (String.IsNullOrEmpty(Keysearch))
            //                {
            //                    Keysearch = Request.QueryString["kEy"];
            //                    if (String.IsNullOrEmpty(Keysearch))
            //                    {
            //                        Keysearch = Request.QueryString["keY"];
            //                        if (String.IsNullOrEmpty(Keysearch))
            //                        {
            //                            Keysearch = Request.QueryString["kEY"];
            //                        }
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}

            int pageSize = 12;
            int pageNumber = (page ?? 1);
            DataTable tblListProduct = new DataTable();
            //if (!String.IsNullOrEmpty(ProductCategoryID))
            //{
            //    tblListProduct = clsProduct.Select_Product_By_Category(Convert.ToInt32(ProductCategoryID), Keysearch);
            //}
            //else
            //{
            //    tblListProduct = clsProduct.Select_Product_By_Category(0, Keysearch);
            //}
            tblListProduct = clsProduct.Select_Product_By_Category(Convert.ToInt32(ProductCategoryID), "");
            List<mProduct> vProduct = (from row in tblListProduct.AsEnumerable()
                                       select new mProduct()
                                       {
                                           ProductID = row.Field<int>("ProductID"),
                                           ProductTypeID = row.Field<int>("ProductTypeID"),
                                           ProductName = row.Field<string>("ProductName"),
                                           BrandName = row.Field<string>("BrandName"),
                                           ProductImage = row.Field<string>("ProductImage"),
                                           ProductStatus = row.Field<int>("ProductStatus"),
                                           CreatedDate = (row.Field<DateTime?>("CreatedDate")).HasValue ? row.Field<DateTime>("CreatedDate").ToString("dd/MM/yyyy") : "",
                                       }).ToList();
            return Request.IsAjaxRequest()
                    ? (ActionResult)PartialView("_ListProduct", vProduct.ToList().ToPagedList(pageNumber, pageSize))
                    : View(vProduct.ToList().ToPagedList(pageNumber, pageSize));
        }

        public JsonResult Select_Product_By_Keysearch(string Keysearch)
        {
            DataTable tblListProduct = clsProduct.Select_Product_By_Category(0, Keysearch);
            var sql = (from row in tblListProduct.AsEnumerable()
                       select new
                       {
                           ProductID = row.Field<int>("ProductID"),
                           ProductTypeID = row.Field<int>("ProductTypeID"),
                           ProductName = row.Field<string>("ProductName"),
                           BrandName = row.Field<string>("BrandName"),
                           ProductImage = row.Field<string>("ProductImage"),
                           ProductStatus = row.Field<int>("ProductStatus"),
                           CreatedDate = (row.Field<DateTime?>("CreatedDate")).HasValue ? row.Field<DateTime>("CreatedDate").ToString("dd/MM/yyyy") : "",
                       }).AsQueryable();
            return Json(sql.ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Select_Top4_Related_Post_Product(string ProductID)
        {
            DataTable tblListProduct = clsProduct.Select_Top4_Related_Post(Convert.ToInt32(ProductID));
            var sql = (from row in tblListProduct.AsEnumerable()
                       select new
                       {
                           ProductID = row.Field<int>("ProductID"),
                           ProductName = row.Field<string>("ProductName"),
                           ProductImage = row.Field<string>("ProductImage"),
                           ProductStatus = row.Field<int>("ProductStatus"),
                           ProductCategoryName = row.Field<string>("ProductCategoryName"),
                           CreatedDate = (row.Field<DateTime?>("CreatedDate")).HasValue ? row.Field<DateTime>("CreatedDate").ToString("dd/MM/yyyy") : ""
                       }).AsQueryable();
            return Json(sql.ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Select_Product_By_ID(string ProductID)
        {
            DataTable tblListProduct = clsProduct.Select_Product_By_ID(Convert.ToInt32(ProductID));
            var sql = (from row in tblListProduct.AsEnumerable()
                       select new
                       {
                           ProductID = row.Field<int>("ProductID"),
                           ProductTypeID = row.Field<int>("ProductTypeID"),
                           ProductCategoryName = row.Field<string>("ProductCategoryName"),
                           ProductName = row.Field<string>("ProductName"),
                           LeavingFromName = row.Field<string>("LeavingFromName"),
                           GoingToName = row.Field<string>("GoingToName"),
                           BrandName = row.Field<string>("BrandName"),
                           ProductEffectedDate = (row.Field<DateTime?>("ProductEffectedDate")).HasValue ? row.Field<DateTime>("ProductEffectedDate").ToString("dd/MM/yyyy") : "",
                           FormattedProductPrice = row.Field<string>("FormattedProductPrice"),
                           ProductContentDecode = HttpUtility.HtmlDecode(row.Field<string>("ProductContent")),
                           ProductImage = row.Field<string>("ProductImage"),
                           ProductStatus = row.Field<int>("ProductStatus"),
                           CreatedDate = (row.Field<DateTime?>("CreatedDate")).HasValue ? row.Field<DateTime>("CreatedDate").ToString("dd/MM/yyyy") : ""
                       }).AsQueryable();
            return Json(sql.ToList(), JsonRequestBehavior.AllowGet);
        }

        #endregion TicketAndTour

        #region SearchResult
        public ActionResult SearchResult()
        {
            DataTable tblListBanner = clsBanner.SelectAllActiveBanner();
            Session.RemoveAll();
            Session["ActiveBanner"] = tblListBanner;
            return View();
        }
        #endregion

        #region HotelService

        public ActionResult HotelService()
        {
            DataTable tblListBanner = clsBanner.SelectAllActiveBanner();
            Session.RemoveAll();
            Session["ActiveBanner"] = tblListBanner;
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

        #endregion HotelService

        #region Visa

        public ActionResult Visa(int? page)
        {
            DataTable tblListBanner = clsBanner.SelectAllActiveBanner();
            Session.RemoveAll();
            Session["ActiveBanner"] = tblListBanner;

            int pageSize = 12;
            int pageNumber = (page ?? 1);
            DataTable tblListVisa = clsVisa.Select_Visa_By_Code(0);
            List<mVisa> vVisa = (from row in tblListVisa.AsEnumerable()
                                 select new mVisa()
                                 {
                                     VisaID = row.Field<int>("VisaID"),
                                     VisaTitle = row.Field<string>("VisaTitle"),
                                     VisaImage = row.Field<string>("VisaImage"),
                                     CreatedDate = (row.Field<DateTime?>("CreatedDate")).HasValue ? row.Field<DateTime>("CreatedDate").ToString("dd/MM/yyyy") : ""
                                 }).ToList();
            return Request.IsAjaxRequest()
                    ? (ActionResult)PartialView("_ListVisa", vVisa.ToList().ToPagedList(pageNumber, pageSize))
                    : View(vVisa.ToList().ToPagedList(pageNumber, pageSize));
        }

        public JsonResult Select_Visa_By_ID(string VisaID)
        {
            DataTable tblListVisa = clsVisa.Select_Visa_By_ID(Convert.ToInt32(VisaID));
            var sql = (from row in tblListVisa.AsEnumerable()
                       select new
                       {
                           VisaID = row.Field<int>("VisaID"),
                           CountryName = row.Field<string>("CountryName"),
                           VisaTitle = row.Field<string>("VisaTitle"),
                           VisaContentDecode = HttpUtility.HtmlDecode(row.Field<string>("VisaContent")),
                           VisaImage = row.Field<string>("VisaImage"),
                           CreatedDate = (row.Field<DateTime?>("CreatedDate")).HasValue ? row.Field<DateTime>("CreatedDate").ToString("dd/MM/yyyy") : ""
                       }).AsQueryable();
            return Json(sql.ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Select_Visa_By_Keysearch(string Keysearch)
        {
            DataTable tblListVisa = clsVisa.Select_Visa_By_Keysearch(Keysearch);
            var sql = (from row in tblListVisa.AsEnumerable()
                       select new
                       {
                           VisaID = row.Field<int>("VisaID"),
                           VisaTitle = row.Field<string>("VisaTitle"),
                           VisaImage = row.Field<string>("VisaImage"),
                           CreatedDate = (row.Field<DateTime?>("CreatedDate")).HasValue ? row.Field<DateTime>("CreatedDate").ToString("dd/MM/yyyy") : ""
                       }).AsQueryable();
            return Json(sql.ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Select_Top4_Related_Post_Visa(string VisaID)
        {
            DataTable tblListVisa = clsVisa.Select_Top4_Related_Post(Convert.ToInt32(VisaID));
            var sql = (from row in tblListVisa.AsEnumerable()
                       select new
                       {
                           VisaID = row.Field<int>("VisaID"),
                           VisaTitle = row.Field<string>("VisaTitle"),
                           VisaImage = row.Field<string>("VisaImage"),
                           CreatedDate = (row.Field<DateTime?>("CreatedDate")).HasValue ? row.Field<DateTime>("CreatedDate").ToString("dd/MM/yyyy") : ""
                       }).AsQueryable();
            return Json(sql.ToList(), JsonRequestBehavior.AllowGet);
        }

        #endregion Visa

        #region BookingAndPayment

        public ActionResult BookingAndPayment()
        {
            DataTable tblListBanner = clsBanner.SelectAllActiveBanner();
            Session.RemoveAll();
            Session["ActiveBanner"] = tblListBanner;
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

        #endregion BookingAndPayment

        #region TravelInsurance

        public ActionResult TravelInsurance()
        {
            DataTable tblListBanner = clsBanner.SelectAllActiveBanner();
            Session.RemoveAll();
            Session["ActiveBanner"] = tblListBanner;
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

        #endregion TravelInsurance

        #region AgencyPolicy

        public ActionResult AgencyPolicy()
        {
            DataTable tblListBanner = clsBanner.SelectAllActiveBanner();
            Session.RemoveAll();
            Session["ActiveBanner"] = tblListBanner;
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

        #endregion TravelInsurance

        #region News

        public ActionResult News(int? page)
        {
            DataTable tblListBanner = clsBanner.SelectAllActiveBanner();
            Session.RemoveAll();
            Session["ActiveBanner"] = tblListBanner;

            int pageSize = 12;
            int pageNumber = (page ?? 1);
            DataTable tblListNews = clsNews.Select_News_By_Code("");
            List<mNews> vNews = (from row in tblListNews.AsEnumerable()
                                 select new mNews()
                                 {
                                     NewsID = row.Field<int>("NewsID"),
                                     NewsTitle = row.Field<string>("NewsTitle"),
                                     NewsImage = row.Field<string>("NewsImage"),
                                     CreatedDate = (row.Field<DateTime?>("CreatedDate")).HasValue ? row.Field<DateTime>("CreatedDate").ToString("dd/MM/yyyy") : ""
                                 }).ToList();
            return Request.IsAjaxRequest()
                    ? (ActionResult)PartialView("_ListNews", vNews.ToList().ToPagedList(pageNumber, pageSize))
                    : View(vNews.ToList().ToPagedList(pageNumber, pageSize));
        }

        public JsonResult Select_News_By_ID(string NewsID)
        {
            DataTable tblListNews = clsNews.Select_News_By_ID(Convert.ToInt32(NewsID));
            var sql = (from row in tblListNews.AsEnumerable()
                       select new
                       {
                           NewsID = row.Field<int>("NewsID"),
                           NewsTitle = row.Field<string>("NewsTitle"),
                           NewsContentDecode = HttpUtility.HtmlDecode(row.Field<string>("NewsContent")),
                           NewsImage = row.Field<string>("NewsImage"),
                           CreatedDate = (row.Field<DateTime?>("CreatedDate")).HasValue ? row.Field<DateTime>("CreatedDate").ToString("dd/MM/yyyy") : ""
                       }).AsQueryable();
            return Json(sql.ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Select_News_By_Code(string Keysearch)
        {
            DataTable tblListNews = clsNews.Select_News_By_Code(Keysearch);
            var sql = (from row in tblListNews.AsEnumerable()
                       select new
                       {
                           NewsID = row.Field<int>("NewsID"),
                           NewsTitle = row.Field<string>("NewsTitle"),
                           NewsImage = row.Field<string>("NewsImage"),
                           CreatedDate = (row.Field<DateTime?>("CreatedDate")).HasValue ? row.Field<DateTime>("CreatedDate").ToString("dd/MM/yyyy") : ""
                       }).AsQueryable();
            return Json(sql.ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Select_Top4_Related_Post_News(string NewsID)
        {
            DataTable tblListNews = clsNews.Select_Top4_Related_Post(Convert.ToInt32(NewsID));
            var sql = (from row in tblListNews.AsEnumerable()
                       select new
                       {
                           NewsID = row.Field<int>("NewsID"),
                           NewsTitle = row.Field<string>("NewsTitle"),
                           NewsImage = row.Field<string>("NewsImage"),
                           CreatedDate = (row.Field<DateTime?>("CreatedDate")).HasValue ? row.Field<DateTime>("CreatedDate").ToString("dd/MM/yyyy") : ""
                       }).AsQueryable();
            return Json(sql.ToList(), JsonRequestBehavior.AllowGet);
        }

        #endregion News

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

        #endregion Contact

        #region Others

        public ActionResult Others(int? page)
        {
            DataTable tblListBanner = clsBanner.SelectAllActiveBanner();
            Session.RemoveAll();
            Session["ActiveBanner"] = tblListBanner;

            int pageSize = 12;
            int pageNumber = (page ?? 1);
            DataTable tblListOthers = clsOthers.SelectAll();
            List<mOthers> vOthers = (from row in tblListOthers.AsEnumerable()
                                     select new mOthers()
                                     {
                                         ID = row.Field<int>("ID"),
                                         Title = row.Field<string>("Title"),
                                         ImageUrl = row.Field<string>("ImageUrl"),
                                         Type = row.Field<string>("Type"),
                                         CreatedDate = (row.Field<DateTime?>("CreatedDate")).HasValue ? row.Field<DateTime>("CreatedDate").ToString("dd/MM/yyyy") : ""
                                     }).ToList();
            return Request.IsAjaxRequest()
                    ? (ActionResult)PartialView("_ListOthers", vOthers.ToList().ToPagedList(pageNumber, pageSize))
                    : View(vOthers.ToList().ToPagedList(pageNumber, pageSize));
        }

        #endregion Others

        #region Details

        public ActionResult Details()
        {
            DataTable tblListBanner = clsBanner.SelectAllActiveBanner();
            Session.RemoveAll();
            Session["ActiveBanner"] = tblListBanner;
            return View();
        }

        #endregion Details

        public class RootRouteConstraint<T> : IRouteConstraint
        {
            public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
            {
                var rootMethodNames = typeof(T).GetMethods().Select(x => x.Name.ToLower());
                return rootMethodNames.Contains(values["action"].ToString().ToLower());
            }
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