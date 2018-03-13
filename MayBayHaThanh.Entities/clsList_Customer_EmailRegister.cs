using System;
using System.Data;

using MayBayHaThanh.DAL;
using MayBayHaThanh.Utilities;

namespace MayBayHaThanh.Entities
{
    public class clsList_Customer_EmailRegister
    {
        private const string SP_List_Customer_EmailRegister = "SP_List_Customer_EmailRegister";
        private DataAccess m_DAL = new DataAccess();

        #region "Variables"

        private Int32 mvarCustomer_EmailRegister_ID;
        private string mvarCustomer_EmailRegister_Name;
        private string mvarCustomer_EmailRegister_Email;
        private string mvarCustomer_EmailRegister_Content;
        private DateTime mvarCreatedDate;

        #endregion

        #region "Properties"

        public Int32 Customer_EmailRegister_ID
        {
            get { return mvarCustomer_EmailRegister_ID; }
            set { mvarCustomer_EmailRegister_ID = value; }
        }

        public string Customer_EmailRegister_Name
        {
            get { return mvarCustomer_EmailRegister_Name; }
            set { mvarCustomer_EmailRegister_Name = value; }
        }

        public string Customer_EmailRegister_Email
        {
            get { return mvarCustomer_EmailRegister_Email; }
            set { mvarCustomer_EmailRegister_Email = value; }
        }

        public string Customer_EmailRegister_Content
        {
            get { return mvarCustomer_EmailRegister_Content; }
            set { mvarCustomer_EmailRegister_Content = value; }
        }

        public DateTime CreatedDate
        {
            get { return mvarCreatedDate; }
            set { mvarCreatedDate = value; }
        }

        #endregion

        #region "Constructors"

        public clsList_Customer_EmailRegister()
        {
            m_DAL = new DataAccess();
            Reset();
        }

        public clsList_Customer_EmailRegister(DataAccess mdal)
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
                DAL.CommandText = SP_List_Customer_EmailRegister;
                DAL.Parameters.Clear();
                DAL.Parameters.Add(new ParamStruct("@Action", DbType.String, "Insert", ParameterDirection.Input, 50));
                DAL.Parameters.Add(new ParamStruct("@Customer_EmailRegister_Name", DbType.String, clsCommon.GetValueDBNull(mvarCustomer_EmailRegister_Name), ParameterDirection.Input, 100));
                DAL.Parameters.Add(new ParamStruct("@Customer_EmailRegister_Email", DbType.String, clsCommon.GetValueDBNull(mvarCustomer_EmailRegister_Email), ParameterDirection.Input, 100));
                DAL.Parameters.Add(new ParamStruct("@Customer_EmailRegister_Content", DbType.String, clsCommon.GetValueDBNull(mvarCustomer_EmailRegister_Content), ParameterDirection.Input, 1000));

                DAL.ExecNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int Customer_EmailRegister_ID)
        {
            DataAccess DAL = m_DAL;
            try
            {
                DAL.CommandType = CommandType.StoredProcedure;
                DAL.CommandText = SP_List_Customer_EmailRegister;
                DAL.Parameters.Clear();
                DAL.Parameters.Add(new ParamStruct("@Action", DbType.String, "Delete", ParameterDirection.Input, 50));
                DAL.Parameters.Add(new ParamStruct("@Customer_EmailRegister_ID", DbType.Int32, clsCommon.GetValueDBNull(Customer_EmailRegister_ID), ParameterDirection.InputOutput, 4));
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
                DAL.CommandText = SP_List_Customer_EmailRegister;
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
            mvarCustomer_EmailRegister_ID = Int32.MinValue;
            mvarCustomer_EmailRegister_Name = string.Empty;
            mvarCustomer_EmailRegister_Email = string.Empty;
            mvarCustomer_EmailRegister_Content = string.Empty;
            mvarCreatedDate = DateTime.MinValue;
        }

        public void FillData(DataRow row)
        {
            mvarCustomer_EmailRegister_ID = Int32.Parse(clsCommon.GetValue(row["Customer_EmailRegister_ID"], mvarCustomer_EmailRegister_ID.GetType().FullName).ToString());
            mvarCustomer_EmailRegister_Name = clsCommon.GetValue(row["Customer_EmailRegister_Name"], mvarCustomer_EmailRegister_Name.GetType().FullName).ToString();
            mvarCustomer_EmailRegister_Email = clsCommon.GetValue(row["Customer_EmailRegister_Email"], mvarCustomer_EmailRegister_Email.GetType().FullName).ToString();
            mvarCustomer_EmailRegister_Content = clsCommon.GetValue(row["Customer_EmailRegister_Content"], mvarCustomer_EmailRegister_Content.GetType().FullName).ToString();
            mvarCreatedDate = DateTime.Parse(clsCommon.GetValue(row["CreatedDate"], mvarCreatedDate.GetType().FullName).ToString());
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
                DAL.CommandText = SP_List_Customer_EmailRegister;
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

        public DataTable Select_News_By_ID(int Customer_EmailRegister_ID)
        {
            DataAccess DAL = m_DAL;
            try
            {
                DataSet ds = new DataSet();
                DAL.CommandType = CommandType.StoredProcedure;
                DAL.CommandText = SP_List_Customer_EmailRegister;
                DAL.Parameters.Clear();
                DAL.Parameters.Add(new ParamStruct("@Action", DbType.String, "SelectByID", ParameterDirection.Input, 50));
                DAL.Parameters.Add(new ParamStruct("@Customer_EmailRegister_ID", DbType.Int32, clsCommon.GetValueDBNull(Customer_EmailRegister_ID), ParameterDirection.InputOutput, 4));

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
