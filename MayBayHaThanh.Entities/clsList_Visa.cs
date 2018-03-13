using System;
using System.Data;

using MayBayHaThanh.DAL;
using MayBayHaThanh.Utilities;

namespace MayBayHaThanh.Entities
{
    public class clsList_Visa
    {
        private const string SP_List_Visa = "SP_List_Visa";
        private DataAccess m_DAL = new DataAccess();

        #region "Variables"

        private Int32 mvarVisaID;
        private Int32 mvarVisaCountryID;
        private string mvarVisaTitle;
        private string mvarVisaContent;
        private string mvarVisaImage;
        private Int32 mvarCreatedBy;
        private DateTime mvarCreatedDate;
        private Int32 mvarLastUpdatedBy;
        private DateTime mvarLastUpdatedDate;

        #endregion

        #region "Properties"

        public Int32 VisaID
        {
            get { return mvarVisaID; }
            set { mvarVisaID = value; }
        }

        public Int32 VisaCountryID
        {
            get { return mvarVisaCountryID; }
            set { mvarVisaCountryID = value; }
        }

        public string VisaTitle
        {
            get { return mvarVisaTitle; }
            set { mvarVisaTitle = value; }
        }

        public string VisaContent
        {
            get { return mvarVisaContent; }
            set { mvarVisaContent = value; }
        }

        public string VisaImage
        {
            get { return mvarVisaImage; }
            set { mvarVisaImage = value; }
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

        public clsList_Visa()
        {
            m_DAL = new DataAccess();
            Reset();
        }

        public clsList_Visa(DataAccess mdal)
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
                DAL.CommandText = SP_List_Visa;
                DAL.Parameters.Clear();
                DAL.Parameters.Add(new ParamStruct("@Action", DbType.String, "Insert", ParameterDirection.Input, 50));
                DAL.Parameters.Add(new ParamStruct("@VisaCountryID", DbType.Int32, clsCommon.GetValueDBNull(mvarVisaCountryID), ParameterDirection.InputOutput, 4));
                DAL.Parameters.Add(new ParamStruct("@VisaTitle", DbType.String, clsCommon.GetValueDBNull(mvarVisaTitle), ParameterDirection.Input, 250));
                DAL.Parameters.Add(new ParamStruct("@VisaContent", DbType.String, clsCommon.GetValueDBNull(mvarVisaContent), ParameterDirection.Input, 1000000));
                DAL.Parameters.Add(new ParamStruct("@VisaImage", DbType.String, clsCommon.GetValueDBNull(mvarVisaImage), ParameterDirection.Input, 200));
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
                DAL.CommandText = SP_List_Visa;
                DAL.Parameters.Clear();
                DAL.Parameters.Add(new ParamStruct("@Action", DbType.String, "Update", ParameterDirection.Input, 50));
                DAL.Parameters.Add(new ParamStruct("@VisaID", DbType.Int32, clsCommon.GetValueDBNull(mvarVisaID), ParameterDirection.InputOutput, 4));
                DAL.Parameters.Add(new ParamStruct("@VisaCountryID", DbType.Int32, clsCommon.GetValueDBNull(mvarVisaCountryID), ParameterDirection.InputOutput, 4));
                DAL.Parameters.Add(new ParamStruct("@VisaTitle", DbType.String, clsCommon.GetValueDBNull(mvarVisaTitle), ParameterDirection.Input, 250));
                DAL.Parameters.Add(new ParamStruct("@VisaContent", DbType.String, clsCommon.GetValueDBNull(mvarVisaContent), ParameterDirection.Input, 1000000));
                DAL.Parameters.Add(new ParamStruct("@VisaImage", DbType.String, clsCommon.GetValueDBNull(mvarVisaImage), ParameterDirection.Input, 200));
                DAL.Parameters.Add(new ParamStruct("@LastUpdatedBy", DbType.Int32, clsCommon.GetValueDBNull(mvarLastUpdatedBy), ParameterDirection.Input, 4));

                return (DAL.ExecNonQuery() > 0);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int VisaID)
        {
            DataAccess DAL = m_DAL;
            try
            {
                DAL.CommandType = CommandType.StoredProcedure;
                DAL.CommandText = SP_List_Visa;
                DAL.Parameters.Clear();
                DAL.Parameters.Add(new ParamStruct("@Action", DbType.String, "Delete", ParameterDirection.Input, 50));
                DAL.Parameters.Add(new ParamStruct("@VisaID", DbType.Int32, clsCommon.GetValueDBNull(VisaID), ParameterDirection.InputOutput, 4));
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
                DAL.CommandText = SP_List_Visa;
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

        public bool SelectByKey(int VisaID)
        {
            DataAccess DAL = m_DAL;
            try
            {
                DataSet ds = new DataSet();
                DAL.CommandType = CommandType.StoredProcedure;
                DAL.CommandText = SP_List_Visa;
                DAL.Parameters.Clear();
                DAL.Parameters.Add(new ParamStruct("@Action", DbType.String, "SelectByKey", ParameterDirection.Input, 50));
                DAL.Parameters.Add(new ParamStruct("@VisaID", DbType.Int32, clsCommon.GetValueDBNull(VisaID), ParameterDirection.InputOutput, 4));
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
            mvarVisaID = Int32.MinValue;
            mvarVisaCountryID = Int32.MinValue;
            mvarVisaTitle = string.Empty;
            mvarVisaContent = string.Empty;
            mvarVisaImage = string.Empty;
            mvarCreatedBy = Int32.MinValue;
            mvarCreatedDate = DateTime.MinValue;
            mvarLastUpdatedBy = Int32.MinValue;
            mvarLastUpdatedDate = DateTime.MinValue;
        }

        public void FillData(DataRow row)
        {
            mvarVisaID = Int32.Parse(clsCommon.GetValue(row["VisaID"], mvarVisaID.GetType().FullName).ToString());
            mvarVisaCountryID = Int32.Parse(clsCommon.GetValue(row["VisaCountryID"], mvarVisaCountryID.GetType().FullName).ToString());
            mvarVisaTitle = clsCommon.GetValue(row["VisaTitle"], mvarVisaTitle.GetType().FullName).ToString();
            mvarVisaContent = clsCommon.GetValue(row["VisaContent"], mvarVisaContent.GetType().FullName).ToString();
            mvarVisaImage = clsCommon.GetValue(row["VisaImage"], mvarVisaImage.GetType().FullName).ToString();
            mvarCreatedBy = Int32.Parse(clsCommon.GetValue(row["CreatedBy"], mvarCreatedBy.GetType().FullName).ToString());
            mvarCreatedDate = DateTime.Parse(clsCommon.GetValue(row["CreatedDate"], mvarCreatedDate.GetType().FullName).ToString());
            mvarLastUpdatedBy = Int32.Parse(clsCommon.GetValue(row["LastUpdatedBy"], mvarLastUpdatedBy.GetType().FullName).ToString());
            mvarLastUpdatedDate = DateTime.Parse(clsCommon.GetValue(row["LastUpdatedDate"], mvarLastUpdatedDate.GetType().FullName).ToString());
        }

        #endregion

        #region "Other Methods"

        public DataTable Select_Visa_By_Code(int VisaCountryID)
        {
            DataAccess DAL = m_DAL;
            try
            {
                DataSet ds = new DataSet();
                DAL.CommandType = CommandType.StoredProcedure;
                DAL.CommandText = SP_List_Visa;
                DAL.Parameters.Clear();
                DAL.Parameters.Add(new ParamStruct("@Action", DbType.String, "SelectByCode", ParameterDirection.Input, 50));
                DAL.Parameters.Add(new ParamStruct("@VisaCountryID", DbType.Int32, clsCommon.GetValueDBNull(VisaCountryID), ParameterDirection.InputOutput, 4));

                ds = DAL.ExecDataSet();
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable Select_Visa_By_Keysearch(string Keysearch)
        {
            DataAccess DAL = m_DAL;
            try
            {
                DataSet ds = new DataSet();
                DAL.CommandType = CommandType.StoredProcedure;
                DAL.CommandText = SP_List_Visa;
                DAL.Parameters.Clear();
                DAL.Parameters.Add(new ParamStruct("@Action", DbType.String, "SelectByKeysearch", ParameterDirection.Input, 50));
                DAL.Parameters.Add(new ParamStruct("@Keysearch", DbType.String, clsCommon.GetValueDBNull(Keysearch), ParameterDirection.InputOutput, 4));
                ds = DAL.ExecDataSet();
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable Select_Total_Visa_Post()
        {
            DataAccess DAL = m_DAL;
            try
            {
                DataSet ds = new DataSet();
                DAL.CommandType = CommandType.StoredProcedure;
                DAL.CommandText = SP_List_Visa;
                DAL.Parameters.Clear();
                DAL.Parameters.Add(new ParamStruct("@Action", DbType.String, "SelectTotalVisaPost", ParameterDirection.Input, 50));

                ds = DAL.ExecDataSet();
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable Select_Visa_By_ID(int VisaID)
        {
            DataAccess DAL = m_DAL;
            try
            {
                DataSet ds = new DataSet();
                DAL.CommandType = CommandType.StoredProcedure;
                DAL.CommandText = SP_List_Visa;
                DAL.Parameters.Clear();
                DAL.Parameters.Add(new ParamStruct("@Action", DbType.String, "SelectByID", ParameterDirection.Input, 50));
                DAL.Parameters.Add(new ParamStruct("@VisaID", DbType.Int32, clsCommon.GetValueDBNull(VisaID), ParameterDirection.InputOutput, 4));

                ds = DAL.ExecDataSet();
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable Select_Top4_Related_Post(int VisaID)
        {
            DataAccess DAL = m_DAL;
            try
            {
                DataSet ds = new DataSet();
                DAL.CommandType = CommandType.StoredProcedure;
                DAL.CommandText = SP_List_Visa;
                DAL.Parameters.Clear();
                DAL.Parameters.Add(new ParamStruct("@Action", DbType.String, "SelectTop4RelatedPost", ParameterDirection.Input, 50));
                DAL.Parameters.Add(new ParamStruct("@VisaID", DbType.Int32, clsCommon.GetValueDBNull(VisaID), ParameterDirection.InputOutput, 4));

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