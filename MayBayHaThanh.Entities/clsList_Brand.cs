using System;
using System.Data;

using MayBayHaThanh.DAL;
using MayBayHaThanh.Utilities;

namespace MayBayHaThanh.Entities
{
    public class clsList_Brand
    {
        private const string SP_List_Brand = "SP_List_Brand";
        private DataAccess m_DAL = new DataAccess();

        #region "Variables"

        private Int32 mvarBrandID;
        private string mvarBrandName;

        #endregion

        #region "Properties"

        public Int32 BrandID
        {
            get { return mvarBrandID; }
            set { mvarBrandID = value; }
        }

        public string BrandName
        {
            get { return mvarBrandName; }
            set { mvarBrandName = value; }
        }

        #endregion

        #region "Constructors"

        public clsList_Brand()
        {
            m_DAL = new DataAccess();
            Reset();
        }

        public clsList_Brand(DataAccess mdal)
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
                DAL.CommandText = SP_List_Brand;
                DAL.Parameters.Clear();
                DAL.Parameters.Add(new ParamStruct("@Action", DbType.String, "Insert", ParameterDirection.Input, 50));
                DAL.Parameters.Add(new ParamStruct("@BrandName", DbType.String, clsCommon.GetValueDBNull(mvarBrandName), ParameterDirection.Input, 100));

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
                DAL.CommandText = SP_List_Brand;
                DAL.Parameters.Clear();
                DAL.Parameters.Add(new ParamStruct("@Action", DbType.String, "Update", ParameterDirection.Input, 50));
                DAL.Parameters.Add(new ParamStruct("@BrandID", DbType.Int32, clsCommon.GetValueDBNull(mvarBrandID), ParameterDirection.InputOutput, 4));
                DAL.Parameters.Add(new ParamStruct("@BrandName", DbType.String, clsCommon.GetValueDBNull(mvarBrandName), ParameterDirection.Input, 100));

                return (DAL.ExecNonQuery() > 0);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int BrandID)
        {
            DataAccess DAL = m_DAL;
            try
            {
                DAL.CommandType = CommandType.StoredProcedure;
                DAL.CommandText = SP_List_Brand;
                DAL.Parameters.Clear();
                DAL.Parameters.Add(new ParamStruct("@Action", DbType.String, "Delete", ParameterDirection.Input, 50));
                DAL.Parameters.Add(new ParamStruct("@BrandID", DbType.Int32, clsCommon.GetValueDBNull(BrandID), ParameterDirection.InputOutput, 4));
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
                DAL.CommandText = SP_List_Brand;
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

        public DataTable SelectByKey(int BrandID)
        {
            DataAccess DAL = m_DAL;
            try
            {
                DataSet ds = new DataSet();
                DAL.CommandType = CommandType.StoredProcedure;
                DAL.CommandText = SP_List_Brand;
                DAL.Parameters.Clear();
                DAL.Parameters.Add(new ParamStruct("@Action", DbType.String, "SelectByKey", ParameterDirection.Input, 50));
                DAL.Parameters.Add(new ParamStruct("@BrandID", DbType.Int32, clsCommon.GetValueDBNull(BrandID), ParameterDirection.InputOutput, 4));

                ds = DAL.ExecDataSet();
                Reset();
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void Reset()
        {
            mvarBrandID = Int32.MinValue;
            mvarBrandName = string.Empty;
        }

        public void FillData(DataRow row)
        {
            mvarBrandID = Int32.Parse(clsCommon.GetValue(row["BrandID"], mvarBrandID.GetType().FullName).ToString());
            mvarBrandName = clsCommon.GetValue(row["BrandName"], mvarBrandName.GetType().FullName).ToString();
        }

        #endregion

        #region "Other Methods"

        public DataTable Select_Brand_By_Code(int BrandID)
        {
            DataAccess DAL = m_DAL;
            try
            {
                DataSet ds = new DataSet();
                DAL.CommandType = CommandType.StoredProcedure;
                DAL.CommandText = SP_List_Brand;
                DAL.Parameters.Clear();
                DAL.Parameters.Add(new ParamStruct("@Action", DbType.String, "SelectByCode", ParameterDirection.Input, 50));
                DAL.Parameters.Add(new ParamStruct("@BrandID", DbType.Int32, clsCommon.GetValueDBNull(BrandID), ParameterDirection.InputOutput, 4));
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
