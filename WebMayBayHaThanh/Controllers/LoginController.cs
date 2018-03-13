using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Data;
using System.IdentityModel;
using System.ServiceModel.Security;
using Newtonsoft.Json;

using MayBayHaThanh.BLL;
using MayBayHaThanh.DAL;
using MayBayHaThanh.Utilities;
using MayBayHaThanh.Entities;
using MayBayHaThanh.BLL.DTO;
using NLog;

namespace WebMayBayHaThanh.Controllers
{
    public class LoginController : Controller
    {
        private Logger Mylogger = LogManager.GetCurrentClassLogger();

        clsList_Account clsAccount = new clsList_Account();
        SYS_BLL objBussinessLayer = new SYS_BLL();

        // GET: Login
        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminLogin(FormCollection f)
        {
            string UserName = f.Get("Username");
            string Password = f.Get("Password");
            if (UserName.Trim() != "" && Password.Trim() != "")
            {
                Mylogger.Info("Login To System: " + UserName.Trim() + "- Pass: " + Password.Trim());
                clsResponseString objReturn = new clsResponseString();
                objReturn = objBussinessLayer.IsLoginSucess(UserName, Password);
                if (objReturn.ResultValue == clsConstant.CODE_SUCCESS)
                {
                    Session["UserID"] = Globals.UserID;
                    Session["IsLogin"] = clsConstant.IS_AUTHENTICATION_SUCCESS;

                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    Globals.Reset();
                    return RedirectToAction("AdminLogin", "Login");
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult Logout()
        {
            //objBussinessLayer.IsLogOutSucess(Globals.UserName);
            Session.RemoveAll();
            return RedirectToAction("AdminLogin", "Login");
        }
    }
}