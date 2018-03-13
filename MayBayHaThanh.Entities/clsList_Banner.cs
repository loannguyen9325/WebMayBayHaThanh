using System;
using System.Data;

using MayBayHaThanh.DAL;
using MayBayHaThanh.Utilities;

namespace MayBayHaThanh.Entities
{
    public class clsList_Banner
    {
        private const string SP_List_Banner = "SP_List_Banner";
        private DataAccess m_DAL = new DataAccess();

        #region "Variables"

        private Int32 mvarBannerID;
        private string mvarBannerName;
        private bool mvarIsActive;
        private string mvarBannerUrl;
        private Int32 mvarCreatedBy;
        private DateTime mvarCreatedDate;
        private Int32 mvarLastUpdatedBy;
        private DateTime mvarLastUpdatedDate;

        #endregion

        #region "Properties"

        public Int32 BannerID
        {
            get { return mvarBannerID; }
            set { mvarBannerID = value; }
        }

        public string BannerName
        {
            get { return mvarBannerName; }
            set { mvarBannerName = value; }
        }

        public bool IsActive
        {
            get { return mvarIsActive; }
            set { mvarIsActive = value; }
        }

        public string BannerUrl
        {
            get { return mvarBannerUrl; }
            set { mvarBannerUrl = value; }
        }

        public int CreatedBy
        {
            get { return mvarCreatedBy; }
            set { mvarCreatedBy = value; }
        }

        public DateTime CreatedDate
        {
            get { return mvarCreatedDate; }
            set { mvarCreatedDate = value; }
        }

        public int LastUpdatedBy
        {
            get { return mvarLastUpdatedBy; }
            set { mvarLastUpdatedBy = value; }
        }

        public DateTime LastUpdatedDate
        {
            get { return mvarLastUpdatedDate; }
            set { mvarLastUpdatedDate = value; }
        }

        #endregion

        #region "Constructors"

        public clsList_Banner()
        {
            m_DAL = new DataAccess();
            Reset();
        }

        public clsList_Banner(DataAccess mdal)
        {
            m_DAL = mdal;
            Reset();
        }

        #endregion

        #region "Methods"

        public bool Insert()
        {
            DataAccess DAL = m_DAL;
            try
            {
                DAL.CommandType = CommandType.StoredProcedure;
                DAL.CommandText = SP_List_Banner;
                DAL.Parameters.Clear();
                DAL.Parameters.Add(new ParamStruct("@Action", DbType.String, "Insert", ParameterDirection.Input, 50));
                DAL.Parameters.Add(new ParamStruct("@BannerName", DbType.String, clsCommon.GetValueDBNull(mvarBannerName), ParameterDirection.Input, 100));
                DAL.Parameters.Add(new ParamStruct("@IsActive", DbType.Boolean, clsCommon.GetValueDBNull(mvarIsActive), ParameterDirection.Input, 2));
                DAL.Parameters.Add(new ParamStruct("@BannerUrl", DbType.String, clsCommon.GetValueDBNull(mvarBannerUrl), ParameterDirection.Input, 200));
                DAL.Parameters.Add(new ParamStruct("@LastUpdatedBy", DbType.Int32, clsCommon.GetValueDBNull(mvarCreatedBy), ParameterDirection.Input, 4));

                DAL.ExecNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Update()
        {
            DataAccess DAL = m_DAL;
            try
            {
                DAL.CommandType = CommandType.StoredProcedure;
                DAL.CommandText = SP_List_Banner;
                DAL.Parameters.Clear();
                DAL.Parameters.Add(new ParamStruct("@Action", DbType.String, "Update", ParameterDirection.Input, 50));
                DAL.Parameters.Add(new ParamStruct("@BannerID", DbType.Int32, clsCommon.GetValueDBNull(mvarBannerID), ParameterDirection.InputOutput, 4));
                DAL.Parameters.Add(new ParamStruct("@IsActive", DbType.Boolean, clsCommon.GetValueDBNull(mvarIsActive), ParameterDirection.Input, 2));
                DAL.Parameters.Add(new ParamStruct("@LastUpdatedBy", DbType.Int32, clsCommon.GetValueDBNull(mvarLastUpdatedBy), ParameterDirection.Input, 4));

                return (DAL.ExecNonQuery() > 0);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int BannerID)
        {
            DataAccess DAL = m_DAL;
            try
            {
                DAL.CommandType = CommandType.StoredProcedure;
                DAL.CommandText = SP_List_Banner;
                DAL.Parameters.Clear();
                DAL.Parameters.Add(new ParamStruct("@Action", DbType.String, "Delete", ParameterDirection.Input, 50));
                DAL.Parameters.Add(new ParamStruct("@BannerID", DbType.Int32, clsCommon.GetValueDBNull(BannerID), ParameterDirection.InputOutput, 4));
                return (DAL.ExecNonQuery() > 0);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public DataTable SelectAll()
        {
            DataAccess DAL = m_DAL;
            try
            {
                DataSet ds = new DataSet();
                DAL.CommandType = CommandType.StoredProcedure;
                DAL.CommandText = SP_List_Banner;
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

        public bool SelectByKey(int BannerID)
        {
            DataAccess DAL = m_DAL;
            try
            {
                DataSet ds = new DataSet();
                DAL.CommandType = CommandType.StoredProcedure;
                DAL.CommandText = SP_List_Banner;
                DAL.Parameters.Clear();
                DAL.Parameters.Add(new ParamStruct("@Action", DbType.String, "SelectByKey", ParameterDirection.Input, 50));
                DAL.Parameters.Add(new ParamStruct("@BannerID", DbType.Int32, clsCommon.GetValueDBNull(BannerID), ParameterDirection.InputOutput, 4));
                ds = DAL.ExecDataSet();

                Reset();

                if (ds == null || ds.Tables.Count == 0)
                {
                    return false;
                }

                if (ds.Tables[0].Rows.Count > 0)
                {
                    FillData(ds.Tables[0].Rows[0]);
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return false;
        }

        public void Reset()
        {
            mvarBannerID = Int32.MinValue;
            mvarBannerName = string.Empty;
            mvarIsActive = false;
            mvarBannerUrl = string.Empty;
            mvarCreatedBy = Int32.MinValue;
            mvarCreatedDate = DateTime.MinValue;
            mvarLastUpdatedBy = Int32.MinValue;
            mvarLastUpdatedDate = DateTime.MinValue;
        }

        public void FillData(DataRow row)
        {
            mvarBannerID = Int32.Parse(clsCommon.GetValue(row["BannerID"], mvarBannerID.GetType().FullName).ToString());
            mvarBannerName = clsCommon.GetValue(row["BannerName"], mvarBannerName.GetType().FullName).ToString();
            mvarIsActive = Boolean.Parse(clsCommon.GetValue(row["IsActive"], mvarIsActive.GetType().FullName).ToString());
            mvarBannerUrl = clsCommon.GetValue(row["BannerUrl"], mvarBannerUrl.GetType().FullName).ToString();
            mvarCreatedBy = Int32.Parse(clsCommon.GetValue(row["CreatedBy"], mvarCreatedBy.GetType().FullName).ToString());
            mvarCreatedDate = DateTime.Parse(clsCommon.GetValue(row["CreatedDate"], mvarCreatedDate.GetType().FullName).ToString());
            mvarLastUpdatedBy = Int32.Parse(clsCommon.GetValue(row["LastUpdatedBy"], mvarLastUpdatedBy.GetType().FullName).ToString());
            mvarLastUpdatedDate = DateTime.Parse(clsCommon.GetValue(row["LastUpdatedDate"], mvarLastUpdatedDate.GetType().FullName).ToString());
        }

        #endregion

        #region "Other Methods"

        public DataTable SelectAllActiveBanner()
        {
            DataAccess DAL = m_DAL;
            try
            {
                DataSet ds = new DataSet();
                DAL.CommandType = CommandType.StoredProcedure;
                DAL.CommandText = SP_List_Banner;
                DAL.Parameters.Clear();
                DAL.Parameters.Add(new ParamStruct("@Action", DbType.String, "SelectAllActiveBanner", ParameterDirection.Input, 50));

                ds = DAL.ExecDataSet();
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion
    }
}
