using System;
using System.Data;

using MayBayHaThanh.DAL;
using MayBayHaThanh.Utilities;

namespace MayBayHaThanh.Entities
{
    public class clsList_ProductCategory
    {
        private const string SP_List_ProductCategory = "SP_List_ProductCategory";
        private DataAccess m_DAL = new DataAccess();
            
        #region "Variables"

        private Int32 mvarProductCategoryID;
        private string mvarProductCategoryName;

        #endregion

        #region "Properties"

        public Int32 ProductCategoryID
        {
            get { return mvarProductCategoryID; }
            set { mvarProductCategoryID = value; }
        }

        public string ProductCategoryName
        {
            get { return mvarProductCategoryName; }
            set { mvarProductCategoryName = value; }
        }

        #endregion

        #region "Constructors"

        public clsList_ProductCategory()
        {
            m_DAL = new DataAccess();
            Reset();
        }

        public clsList_ProductCategory(DataAccess mdal)
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
                DAL.CommandText = SP_List_ProductCategory;
                DAL.Parameters.Clear();
                DAL.Parameters.Add(new ParamStruct("@Action", DbType.String, "Insert", ParameterDirection.Input, 50));
                DAL.Parameters.Add(new ParamStruct("@ProductCategoryName", DbType.String, clsCommon.GetValueDBNull(mvarProductCategoryName), ParameterDirection.Input, 100));

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
                DAL.CommandText = SP_List_ProductCategory;
                DAL.Parameters.Clear();
                DAL.Parameters.Add(new ParamStruct("@Action", DbType.String, "Update", ParameterDirection.Input, 50));
                DAL.Parameters.Add(new ParamStruct("@ProductCategoryID", DbType.Int32, clsCommon.GetValueDBNull(mvarProductCategoryID), ParameterDirection.InputOutput, 4));
                DAL.Parameters.Add(new ParamStruct("@ProductCategoryName", DbType.String, clsCommon.GetValueDBNull(mvarProductCategoryName), ParameterDirection.Input, 100));

                return (DAL.ExecNonQuery() > 0);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int ProductCategoryID)
        {
            DataAccess DAL = m_DAL;
            try
            {
                DAL.CommandType = CommandType.StoredProcedure;
                DAL.CommandText = SP_List_ProductCategory;
                DAL.Parameters.Clear();
                DAL.Parameters.Add(new ParamStruct("@Action", DbType.String, "Delete", ParameterDirection.Input, 50));
                DAL.Parameters.Add(new ParamStruct("@ProductCategoryID", DbType.Int32, clsCommon.GetValueDBNull(ProductCategoryID), ParameterDirection.InputOutput, 4));
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
                DAL.CommandText = SP_List_ProductCategory;
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

        public bool SelectByKey(int ProductCategoryID)
        {
            DataAccess DAL = m_DAL;
            try
            {
                DataSet ds = new DataSet();
                DAL.CommandType = CommandType.StoredProcedure;
                DAL.CommandText = SP_List_ProductCategory;
                DAL.Parameters.Clear();
                DAL.Parameters.Add(new ParamStruct("@Action", DbType.String, "SelectByKey", ParameterDirection.Input, 50));
                DAL.Parameters.Add(new ParamStruct("@ProductCategoryID", DbType.Int32, clsCommon.GetValueDBNull(ProductCategoryID), ParameterDirection.InputOutput, 4));
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
            mvarProductCategoryID = Int32.MinValue;
            mvarProductCategoryName = string.Empty;
        }

        public void FillData(DataRow row)
        {
            mvarProductCategoryID = Int32.Parse(clsCommon.GetValue(row["ProductCategoryID"], mvarProductCategoryID.GetType().FullName).ToString());
            mvarProductCategoryName = clsCommon.GetValue(row["ProductCategoryName"], mvarProductCategoryName.GetType().FullName).ToString();
        }

        #endregion
        
        #region "Other Methods"

        public DataTable Select_ProductCategory_By_Code(int ProductCategoryID)
        {
            DataAccess DAL = m_DAL;
            try
            {
                DataSet ds = new DataSet();
                DAL.CommandType = CommandType.StoredProcedure;
                DAL.CommandText = SP_List_ProductCategory;
                DAL.Parameters.Clear();
                DAL.Parameters.Add(new ParamStruct("@Action", DbType.String, "SelectByCode", ParameterDirection.Input, 50));
                DAL.Parameters.Add(new ParamStruct("@ProductCategoryID", DbType.Int32, clsCommon.GetValueDBNull(ProductCategoryID), ParameterDirection.InputOutput, 4));
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


