using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayBayHaThanh.BLL.DTO
{
    public class clsParameterTransfer
    {
        #region "Variable"
        
        private int mvarUserID;
        private int mvarLoginSessionID;

        #endregion

        #region "Variable"
        
        public int UserID
        {
            get { return mvarUserID; }
            set { mvarUserID = value; }
        }

        public int LoginSessionID
        {
            get { return mvarLoginSessionID; }
            set { mvarLoginSessionID = value; }
        }

        #endregion

        public clsParameterTransfer()
        {

        }

        public clsParameterTransfer(int intUserID)
        {
            UserID = intUserID;
        }
        public clsParameterTransfer(int intUserID, int intLoginSessionID)
        {
            UserID = intUserID;
            LoginSessionID = intLoginSessionID;
        }
    }
}
