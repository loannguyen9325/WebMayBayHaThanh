using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Threading;

namespace MayBayHaThanh.Utilities
{
    public sealed class Globals : IDisposable
    {
        #region "Variable"
        
        private static int mLoginSessionID;
        private static int mUserID;
        private static string mFullName;
        private static string mUserName;
        private static DateTime m_CurrentServerDateTime;

        #endregion

        #region "Properties"

        public static int UserID
        {
             
            get
            {
                return mUserID;
            }
            set
            {
                if (value != mUserID)
                {
                    mUserID = value;
                }
            }
        }

        public static string UserName
        {
             
            get
            {
                return mUserName;
            }
            set
            {
                if (value != mUserName)
                {
                    mUserName = value;
                }
            }
        }

        public static string FullName
        {
            get
            {
                return mFullName;
            }
            set
            {
                if (value != mFullName)
                {
                    mFullName = value;
                }
            }
        }

        public static int LoginSessionID
        {
             
            get
            {
                return mLoginSessionID;
            }
            set
            {
                if (value != mLoginSessionID)
                {
                    mLoginSessionID = value;
                }
            }
        }

        //public static DateTime CurrentServerDateTime
        //{
        //    get
        //    {
        //        System.DateTime result;
        //        try
        //        {
        //            DataAccess dataAccess = new DataAccess();
        //            result = System.Convert.ToDateTime(dataAccess.ExecuteScalar("SELECT GETDATE()"));
        //        }
        //        catch
        //        {
        //            result = System.DateTime.Now;
        //        }
        //        finally
        //        {

        //        }
        //        return result;
        //    }
        //    set { m_CurrentServerDateTime = value; }
        //}

        #endregion

        public static void Reset()
        {
            UserID = int.MinValue;
            FullName = string.Empty; 
            UserName = string.Empty;
            LoginSessionID = int.MinValue;
        }

        public void Dispose()
        {
            try
            {
                GC.SuppressFinalize(this);      
            }
            catch
            {
            }
        }
    }
}
