using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Text;
using System.Configuration;

using Newtonsoft.Json;
using NLog;

using MayBayHaThanh.Utilities;
using MayBayHaThanh.DAL;
using MayBayHaThanh.BLL;
using System.Web.Routing;

namespace WebMayBayHaThanh.Controllers
{
    public class BaseController : Controller
    {
        public string _userSession { set; get; }

        protected Logger Mylogger { get; private set; }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpSessionStateBase session = filterContext.HttpContext.Session;
            string CurrentController = HttpContext.Request.RequestContext.RouteData.Values["controller"].ToString();
            string CurrentAction = HttpContext.Request.RequestContext.RouteData.Values["Action"].ToString();

            if (Session["UserID"] != null || Session["IsLogin"] != null)
            {
                return;
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary {
                        { "Controller", "Login" },
                        { "Action", "AdminLogin" }
                        });
                return;
            }
        }

        public BaseController()
        {

        }
    }
}