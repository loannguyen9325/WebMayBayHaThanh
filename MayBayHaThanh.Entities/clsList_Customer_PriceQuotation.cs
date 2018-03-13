using System;
using System.Data;

using MayBayHaThanh.DAL;
using MayBayHaThanh.Utilities;

namespace MayBayHaThanh.Entities
{
    public class clsList_Customer_PriceQuotation
    {
        private const string SP_List_Customer_PriceQuotation = "SP_List_Customer_PriceQuotation";
        private DataAccess m_DAL = new DataAccess();

        #region "Variables"

        private Int32 mvarCustomer_PriceQuotation_ID;
        private string mvarCustomer_PriceQuotation_Name;
        private string mvarCustomer_PriceQuotation_Phone;
        private string mvarCustomer_PriceQuotation_Email;
        private string mvarCustomer_PriceQuotation_Content;
        private DateTime mvarCustomer_PriceQuotation_DateFlight;
        private DateTime mvarCreatedDate;

        #endregion

        #region "Properties"

        public Int32 Customer_PriceQuotation_ID
        {
            get { return mvarCustomer_PriceQuotation_ID; }
            set { mvarCustomer_PriceQuotation_ID = value; }
        }

        public string Customer_PriceQuotation_Name
        {
            get { return mvarCustomer_PriceQuotation_Name; }
            set { mvarCustomer_PriceQuotation_Name = value; }
        }

        public string Customer_PriceQuotation_Phone
        {
            get { return mvarCustomer_PriceQuotation_Phone; }
            set { mvarCustomer_PriceQuotation_Phone = value; }
        }

        public string Customer_PriceQuotation_Email
        {
            get { return mvarCustomer_PriceQuotation_Email; }
            set { mvarCustomer_PriceQuotation_Email = value; }
        }

        public string Customer_PriceQuotation_Content
        {
            get { return mvarCustomer_PriceQuotation_Content; }
            set { mvarCustomer_PriceQuotation_Content = value; }
        }

        public DateTime CreatedDate
        {
            get { return mvarCreatedDate; }
            set { mvarCreatedDate = value; }
        }

        public DateTime Customer_PriceQuotation_DateFlight
        {
            get { return mvarCustomer_PriceQuotation_DateFlight; }
            set { mvarCustomer_PriceQuotation_DateFlight = value; }
        }

        #endregion

        #region "Constructors"

        public clsList_Customer_PriceQuotation()
        {
            m_DAL = new DataAccess();
            Reset();
        }

        public clsList_Customer_PriceQuotation(DataAccess mdal)
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
                DAL.CommandText = SP_List_Customer_PriceQuotation;
                DAL.Parameters.Clear();
                DAL.Parameters.Add(new ParamStruct("@Action", DbType.String, "Insert", ParameterDirection.Input, 50));
                DAL.Parameters.Add(new ParamStruct("@Customer_PriceQuotation_Name", DbType.String, clsCommon.GetValueDBNull(mvarCustomer_PriceQuotation_Name), ParameterDirection.Input, 100));
                DAL.Parameters.Add(new ParamStruct("@Customer_PriceQuotation_Phone", DbType.String, clsCommon.GetValueDBNull(mvarCustomer_PriceQuotation_Phone), ParameterDirection.Input, 1000));
                DAL.Parameters.Add(new ParamStruct("@Customer_PriceQuotation_Email", DbType.String, clsCommon.GetValueDBNull(mvarCustomer_PriceQuotation_Email), ParameterDirection.Input, 100));
                DAL.Parameters.Add(new ParamStruct("@Customer_PriceQuotation_Content", DbType.String, clsCommon.GetValueDBNull(mvarCustomer_PriceQuotation_Content), ParameterDirection.Input, 1000));
                DAL.Parameters.Add(new ParamStruct("@Customer_PriceQuotation_DateFlight", DbType.DateTime, clsCommon.GetValueDBNull(mvarCustomer_PriceQuotation_DateFlight), ParameterDirection.Input, 16));

                DAL.ExecNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int Customer_PriceQuotation_ID)
        {
            DataAccess DAL = m_DAL;
            try
            {
                DAL.CommandType = CommandType.StoredProcedure;
                DAL.CommandText = SP_List_Customer_PriceQuotation;
                DAL.Parameters.Clear();
                DAL.Parameters.Add(new ParamStruct("@Action", DbType.String, "Delete", ParameterDirection.Input, 50));
                DAL.Parameters.Add(new ParamStruct("@Customer_PriceQuotation_ID", DbType.Int32, clsCommon.GetValueDBNull(Customer_PriceQuotation_ID), ParameterDirection.InputOutput, 4));
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
                DAL.CommandText = SP_List_Customer_PriceQuotation;
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
            mvarCustomer_PriceQuotation_ID = Int32.MinValue;
            mvarCustomer_PriceQuotation_Name = string.Empty;
            mvarCustomer_PriceQuotation_Phone = string.Empty;
            mvarCustomer_PriceQuotation_Email = string.Empty;
            mvarCustomer_PriceQuotation_Content = string.Empty;
            mvarCustomer_PriceQuotation_DateFlight = DateTime.MinValue;
            mvarCreatedDate = DateTime.MinValue;
        }

        public void FillData(DataRow row)
        {
            mvarCustomer_PriceQuotation_ID = Int32.Parse(clsCommon.GetValue(row["Customer_PriceQuotation_ID"], mvarCustomer_PriceQuotation_ID.GetType().FullName).ToString());
            mvarCustomer_PriceQuotation_Name = clsCommon.GetValue(row["Customer_PriceQuotation_Name"], mvarCustomer_PriceQuotation_Name.GetType().FullName).ToString();
            mvarCustomer_PriceQuotation_Phone = clsCommon.GetValue(row["Customer_PriceQuotation_Phone"], mvarCustomer_PriceQuotation_Phone.GetType().FullName).ToString();
            mvarCustomer_PriceQuotation_Email = clsCommon.GetValue(row["Customer_PriceQuotation_Email"], mvarCustomer_PriceQuotation_Email.GetType().FullName).ToString();
            mvarCustomer_PriceQuotation_Content = clsCommon.GetValue(row["Customer_PriceQuotation_Content"], mvarCustomer_PriceQuotation_Content.GetType().FullName).ToString();
            mvarCustomer_PriceQuotation_DateFlight = DateTime.Parse(clsCommon.GetValue(row["Customer_PriceQuotation_DateFlight"], mvarCustomer_PriceQuotation_DateFlight.GetType().FullName).ToString());
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
                DAL.CommandText = SP_List_Customer_PriceQuotation;
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

        public DataTable Select_News_By_ID(int Customer_PriceQuotation_ID)
        {
            DataAccess DAL = m_DAL;
            try
            {
                DataSet ds = new DataSet();
                DAL.CommandType = CommandType.StoredProcedure;
                DAL.CommandText = SP_List_Customer_PriceQuotation;
                DAL.Parameters.Clear();
                DAL.Parameters.Add(new ParamStruct("@Action", DbType.String, "SelectByID", ParameterDirection.Input, 50));
                DAL.Parameters.Add(new ParamStruct("@Customer_PriceQuotation_ID", DbType.Int32, clsCommon.GetValueDBNull(Customer_PriceQuotation_ID), ParameterDirection.InputOutput, 4));

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
