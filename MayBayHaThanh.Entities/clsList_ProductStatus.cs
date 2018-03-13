using System;
using System.Data;

using MayBayHaThanh.DAL;
using MayBayHaThanh.Utilities;

namespace MayBayHaThanh.Entities
{
    public class clsList_ProductStatus
    {
        private const string SP_List_ProductStatus = "SP_List_ProductStatus";
        private DataAccess m_DAL = new DataAccess();

        #region "Variables"

        private Int32 mvarProductStatusID;
        private string mvarProductStatusName;

        #endregion

        #region "Properties"

        public Int32 ProductStatusID
        {
            get { return mvarProductStatusID; }
            set { mvarProductStatusID = value; }
        }

        public string ProductStatusName
        {
            get { return mvarProductStatusName; }
            set { mvarProductStatusName = value; }
        }

        #endregion

        #region "Constructors"

        public clsList_ProductStatus()
        {
            m_DAL = new DataAccess();
            Reset();
        }

        public clsList_ProductStatus(DataAccess mdal)
        {
            m_DAL = mdal;
            Reset();
        }

        #endregion

        #region "Methods"

        public DataTable SelectAll()
        {
            DataAccess DAL = m_DAL;
            try
            {
                DataSet ds = new DataSet();
                DAL.CommandType = CommandType.StoredProcedure;
                DAL.CommandText = SP_List_ProductStatus;
                DAL.Parameters.Clear();
                DAL.Parameters.Add(new ParamStruct("@Action", DbType.String, "SelectAll", ParameterDirection.Input, 50));

                ds = DAL.ExecDataSet();
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void Reset()
        {
            mvarProductStatusID = Int32.MinValue;
            mvarProductStatusName = string.Empty;
        }

        public void FillData(DataRow row)
        {
            mvarProductStatusID = Int32.Parse(clsCommon.GetValue(row["ProductStatusID"], mvarProductStatusID.GetType().FullName).ToString());
            mvarProductStatusName = clsCommon.GetValue(row["ProductStatusName"], mvarProductStatusName.GetType().FullName).ToString();
        }
        #endregion

        #region "Other Methods"
        
        #endregion
    }
}
