using System;
using System.Data;

using MayBayHaThanh.DAL;
using MayBayHaThanh.Utilities;

namespace MayBayHaThanh.Entities
{
    public class clsList_News
    {
        private const string SP_List_News = "SP_List_News";
        private DataAccess m_DAL = new DataAccess();

        #region "Variables"

        private Int32 mvarNewsID;
        private string mvarNewsTitle;
        private string mvarNewsContent;
        private string mvarNewsImage;
        private Int32 mvarCreatedBy;
        private DateTime mvarCreatedDate;
        private Int32 mvarLastUpdatedBy;
        private DateTime mvarLastUpdatedDate;

        #endregion

        #region "Properties"

        public Int32 NewsID
        {
            get { return mvarNewsID; }
            set { mvarNewsID = value; }
        }

        public string NewsTitle
        {
            get { return mvarNewsTitle; }
            set { mvarNewsTitle = value; }
        }

        public string NewsContent
        {
            get { return mvarNewsContent; }
            set { mvarNewsContent = value; }
        }

        public string NewsImage
        {
            get { return mvarNewsImage; }
            set { mvarNewsImage = value; }
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

        public clsList_News()
        {
            m_DAL = new DataAccess();
            Reset();
        }

        public clsList_News(DataAccess mdal)
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
                DAL.CommandText = SP_List_News;
                DAL.Parameters.Clear();
                DAL.Parameters.Add(new ParamStruct("@Action", DbType.String, "Insert", ParameterDirection.Input, 50));
                DAL.Parameters.Add(new ParamStruct("@NewsTitle", DbType.String, clsCommon.GetValueDBNull(mvarNewsTitle), ParameterDirection.Input, 250));
                DAL.Parameters.Add(new ParamStruct("@NewsContent", DbType.String, clsCommon.GetValueDBNull(mvarNewsContent), ParameterDirection.Input, 1000000));
                DAL.Parameters.Add(new ParamStruct("@NewsImage", DbType.String, clsCommon.GetValueDBNull(mvarNewsImage), ParameterDirection.Input, 200));
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
                DAL.CommandText = SP_List_News;
                DAL.Parameters.Clear();
                DAL.Parameters.Add(new ParamStruct("@Action", DbType.String, "Update", ParameterDirection.Input, 50));
                DAL.Parameters.Add(new ParamStruct("@NewsID", DbType.Int32, clsCommon.GetValueDBNull(mvarNewsID), ParameterDirection.InputOutput, 4));
                DAL.Parameters.Add(new ParamStruct("@NewsTitle", DbType.String, clsCommon.GetValueDBNull(mvarNewsTitle), ParameterDirection.Input, 250));
                DAL.Parameters.Add(new ParamStruct("@NewsContent", DbType.String, clsCommon.GetValueDBNull(mvarNewsContent), ParameterDirection.Input, 1000000));
                DAL.Parameters.Add(new ParamStruct("@NewsImage", DbType.String, clsCommon.GetValueDBNull(mvarNewsImage), ParameterDirection.Input, 200));
                DAL.Parameters.Add(new ParamStruct("@LastUpdatedBy", DbType.Int32, clsCommon.GetValueDBNull(mvarLastUpdatedBy), ParameterDirection.Input, 4));

                return (DAL.ExecNonQuery() > 0);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int NewsID)
        {
            DataAccess DAL = m_DAL;
            try
            {
                DAL.CommandType = CommandType.StoredProcedure;
                DAL.CommandText = SP_List_News;
                DAL.Parameters.Clear();
                DAL.Parameters.Add(new ParamStruct("@Action", DbType.String, "Delete", ParameterDirection.Input, 50));
                DAL.Parameters.Add(new ParamStruct("@NewsID", DbType.Int32, clsCommon.GetValueDBNull(NewsID), ParameterDirection.InputOutput, 4));
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
                DAL.CommandText = SP_List_News;
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

        public bool SelectByKey(int NewsID)
        {
            DataAccess DAL = m_DAL;
            try
            {
                DataSet ds = new DataSet();
                DAL.CommandType = CommandType.StoredProcedure;
                DAL.CommandText = SP_List_News;
                DAL.Parameters.Clear();
                DAL.Parameters.Add(new ParamStruct("@Action", DbType.String, "SelectByKey", ParameterDirection.Input, 50));
                DAL.Parameters.Add(new ParamStruct("@NewsID", DbType.Int32, clsCommon.GetValueDBNull(NewsID), ParameterDirection.InputOutput, 4));
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
            mvarNewsID = Int32.MinValue;
            mvarNewsTitle = string.Empty;
            mvarNewsContent = string.Empty;
            mvarNewsImage = string.Empty;
            mvarCreatedBy = Int32.MinValue;
            mvarCreatedDate = DateTime.MinValue;
            mvarLastUpdatedBy = Int32.MinValue;
            mvarLastUpdatedDate = DateTime.MinValue;
        }

        public void FillData(DataRow row)
        {
            mvarNewsID = Int32.Parse(clsCommon.GetValue(row["NewsID"], mvarNewsID.GetType().FullName).ToString());
            mvarNewsTitle = clsCommon.GetValue(row["NewsTitle"], mvarNewsTitle.GetType().FullName).ToString();
            mvarNewsContent = clsCommon.GetValue(row["NewsContent"], mvarNewsContent.GetType().FullName).ToString();
            mvarNewsImage = clsCommon.GetValue(row["NewsImage"], mvarNewsImage.GetType().FullName).ToString();
            mvarCreatedBy = Int32.Parse(clsCommon.GetValue(row["CreatedBy"], mvarCreatedBy.GetType().FullName).ToString());
            mvarCreatedDate = DateTime.Parse(clsCommon.GetValue(row["CreatedDate"], mvarCreatedDate.GetType().FullName).ToString());
            mvarLastUpdatedBy = Int32.Parse(clsCommon.GetValue(row["LastUpdatedBy"], mvarLastUpdatedBy.GetType().FullName).ToString());
            mvarLastUpdatedDate = DateTime.Parse(clsCommon.GetValue(row["LastUpdatedDate"], mvarLastUpdatedDate.GetType().FullName).ToString());
        }

        #endregion

        #region "Other Methods"

        public DataTable Select_News_By_Code(string Keysearch)
        {
            DataAccess DAL = m_DAL;
            try
            {
                DataSet ds = new DataSet();
                DAL.CommandType = CommandType.StoredProcedure;
                DAL.CommandText = SP_List_News;
                DAL.Parameters.Clear();
                DAL.Parameters.Add(new ParamStruct("@Action", DbType.String, "SelectByCode", ParameterDirection.Input, 50));
                DAL.Parameters.Add(new ParamStruct("@Keysearch", DbType.String, clsCommon.GetValueDBNull(Keysearch), ParameterDirection.InputOutput, 4));
                ds = DAL.ExecDataSet();
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable Select_News_By_ID(int NewsID)
        {
            DataAccess DAL = m_DAL;
            try
            {
                DataSet ds = new DataSet();
                DAL.CommandType = CommandType.StoredProcedure;
                DAL.CommandText = SP_List_News;
                DAL.Parameters.Clear();
                DAL.Parameters.Add(new ParamStruct("@Action", DbType.String, "SelectByID", ParameterDirection.Input, 50));
                DAL.Parameters.Add(new ParamStruct("@NewsID", DbType.Int32, clsCommon.GetValueDBNull(NewsID), ParameterDirection.InputOutput, 4));

                ds = DAL.ExecDataSet();
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable Select_Top4_Related_Post(int NewsID)
        {
            DataAccess DAL = m_DAL;
            try
            {
                DataSet ds = new DataSet();
                DAL.CommandType = CommandType.StoredProcedure;
                DAL.CommandText = SP_List_News;
                DAL.Parameters.Clear();
                DAL.Parameters.Add(new ParamStruct("@Action", DbType.String, "SelectTop4RelatedPost", ParameterDirection.Input, 50));
                DAL.Parameters.Add(new ParamStruct("@NewsID", DbType.Int32, clsCommon.GetValueDBNull(NewsID), ParameterDirection.InputOutput, 4));

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