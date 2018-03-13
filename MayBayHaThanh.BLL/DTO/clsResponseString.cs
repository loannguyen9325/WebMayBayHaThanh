using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Threading.Tasks;

namespace MayBayHaThanh.BLL.DTO
{
    public class clsResponseString
    {
        private int mvarResultValue;
        private string mvarResultMessage;
        //1 : thêm , cập nhật , xóa  thành công
        //0 : thêm , cập nhật , xóa không thành công
        //2: không tồn tại giá trị này!!!
        //3 : tham số không hợp lệ
        //5 : authentication fails
        private object mvarObjectReturn;
        private DataTable mvarObjectReturnDetails;

        public int ResultValue
        {
            get { return mvarResultValue; }
            set { mvarResultValue = value; }
        }

        public string ResultMessage
        {
            get { return mvarResultMessage; }
            set { mvarResultMessage = value; }
        }

        public object ObjectReturn
        {
            get { return mvarObjectReturn; }
            set { mvarObjectReturn = value; }
        }

        public DataTable DataStringDetails
        {
            get { return mvarObjectReturnDetails; }
            set { mvarObjectReturnDetails = value; }
        }
    }
}
