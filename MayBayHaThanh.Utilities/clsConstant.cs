using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayBayHaThanh.Utilities
{
    public class clsConstant
    {
        // Lưu các giá trị hệ thống
        #region ----------- Hệ thống-----------
        public const int IS_AUTHENTICATION_SUCCESS = 1;
        public const string A_SECRECT_KEY = "mbht-hisreport";
        public const string A_SYS_ADMIN_PASSWORD = "123456a@";
        public const string A_SYS_ADMIN_USERNAME = "System Administration";
        public const int A_TIME_RENEW_SECRECT_KEY = 30;
        //-----tham số trả về khi goi services
        public const int CODE_SUCCESS = 1;
        public const int CODE_FAIL = -1;
        public const int CODE_PARAMS_ERROR = 3;
        public const int CODE_USER_NOT_EXISTS = 4;
        public const int CODE_AUTHEN_FAILS = 5;
        #endregion

        //Giá trị Null khi lưu xuống CSDL
        public static DateTime NULL_DATE = DateTime.Parse("12/31/1899");
        //Giá trị nhỏ nhất khi lưu vào DateType: Smalldatetime
        public static DateTime SMALLDATE_MIN = DateTime.Parse("01/01/1900");
        //Giá trị lớn nhất khi lưu vào DateType: Smalldatetime
        public static DateTime SMALLDATE_MAX = DateTime.Parse("31/12/2075");
        //Giá trị password chuỗi băm:
        public static string PASSWORD_HASH = "#MBHT.P@SSW0RD#";
    }
}
