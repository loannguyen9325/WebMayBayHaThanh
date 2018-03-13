using System;
using System.Data;

using MayBayHaThanh.DAL;
using MayBayHaThanh.Utilities;

namespace MayBayHaThanh.Entities
{
    public class clsList_CountryOrPlace
    {
        private const string SP_List_CountryOrPlace = "SP_List_CountryOrPlace";
        private DataAccess m_DAL = new DataAccess();

        #region "Variables"

        private Int32 mvarCountryID;
        private bool mvarIsCountry;
        private bool mvarIsForeign;
        private string mvarCountryName;

        #endregion

        #region "Properties"

        public Int32 CountryID
        {
            get { return mvarCountryID; }
            set { mvarCountryID = value; }
        }

        public bool IsCountry
        {
            get { return mvarIsCountry; }
            set { mvarIsCountry = value; }
        }

        public bool IsForeign
        {
            get { return mvarIsForeign; }
            set { mvarIsForeign = value; }
        }

        public string CountryName
        {
            get { return mvarCountryName; }
            set { mvarCountryName = value; }
        }

        #endregion

        #region "Constructors"

        public clsList_CountryOrPlace()
        {
            m_DAL = new DataAccess();
            Reset();
        }

        public clsList_CountryOrPlace(DataAccess mdal)
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
                DAL.CommandText = SP_List_CountryOrPlace;
                DAL.Parameters.Clear();
                DAL.Parameters.Add(new ParamStruct("@Action", DbType.String, "Insert", ParameterDirection.Input, 50));
                DAL.Parameters.Add(new ParamStruct("@IsForeign", DbType.Boolean, clsCommon.GetValueDBNull(mvarIsForeign), ParameterDirection.Input, 2));
                DAL.Parameters.Add(new ParamStruct("@IsCountry", DbType.Boolean, clsCommon.GetValueDBNull(mvarIsCountry), ParameterDirection.Input, 2));
                DAL.Parameters.Add(new ParamStruct("@CountryName", DbType.String, clsCommon.GetValueDBNull(mvarCountryName), ParameterDirection.Input, 100));

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
                DAL.CommandText = SP_List_CountryOrPlace;
                DAL.Parameters.Clear();
                DAL.Parameters.Add(new ParamStruct("@Action", DbType.String, "Update", ParameterDirection.Input, 50));
                DAL.Parameters.Add(new ParamStruct("@CountryID", DbType.Int32, clsCommon.GetValueDBNull(mvarCountryID), ParameterDirection.InputOutput, 4));
                DAL.Parameters.Add(new ParamStruct("@IsCountry", DbType.Boolean, clsCommon.GetValueDBNull(mvarIsCountry), ParameterDirection.Input, 2));
                DAL.Parameters.Add(new ParamStruct("@IsForeign", DbType.Boolean, clsCommon.GetValueDBNull(mvarIsForeign), ParameterDirection.Input, 2));
                DAL.Parameters.Add(new ParamStruct("@CountryName", DbType.String, clsCommon.GetValueDBNull(mvarCountryName), ParameterDirection.Input, 100));

                return (DAL.ExecNonQuery() > 0);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int CountryID)
        {
            DataAccess DAL = m_DAL;
            try
            {
                DAL.CommandType = CommandType.StoredProcedure;
                DAL.CommandText = SP_List_CountryOrPlace;
                DAL.Parameters.Clear();
                DAL.Parameters.Add(new ParamStruct("@Action", DbType.String, "Delete", ParameterDirection.Input, 50));
                DAL.Parameters.Add(new ParamStruct("@CountryID", DbType.Int32, clsCommon.GetValueDBNull(CountryID), ParameterDirection.InputOutput, 4));
                return (DAL.ExecNonQuery() > 0);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public DataTable SelectAll(bool IsForeign)
        {
            DataAccess DAL = m_DAL;
            try
            {
                DataSet ds = new DataSet();
                DAL.CommandType = CommandType.StoredProcedure;
                DAL.CommandText = SP_List_CountryOrPlace;
                DAL.Parameters.Clear();
                DAL.Parameters.Add(new ParamStruct("@Action", DbType.String, "SelectAll", ParameterDirection.Input, 50));
                DAL.Parameters.Add(new ParamStruct("@IsForeign", DbType.Boolean, clsCommon.GetValueDBNull(IsForeign), ParameterDirection.Input, 2));

                ds = DAL.ExecDataSet();
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable SelectByKey(int CountryID)
        {
            DataAccess DAL = m_DAL;
            try
            {
                DataSet ds = new DataSet();
                DAL.CommandType = CommandType.StoredProcedure;
                DAL.CommandText = SP_List_CountryOrPlace;
                DAL.Parameters.Clear();
                DAL.Parameters.Add(new ParamStruct("@Action", DbType.String, "SelectByKey", ParameterDirection.Input, 50));
                DAL.Parameters.Add(new ParamStruct("@CountryID", DbType.Int32, clsCommon.GetValueDBNull(CountryID), ParameterDirection.InputOutput, 4));

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
            mvarCountryID = Int32.MinValue;
            mvarIsCountry = true;
            mvarCountryName = string.Empty;
        }

        public void FillData(DataRow row)
        {
            mvarCountryID = Int32.Parse(clsCommon.GetValue(row["CountryID"], mvarCountryID.GetType().FullName).ToString());
            mvarIsCountry = Boolean.Parse(clsCommon.GetValue(row["IsCountry"], mvarIsCountry.GetType().FullName).ToString());
            mvarCountryName = clsCommon.GetValue(row["CountryName"], mvarCountryName.GetType().FullName).ToString();
        }

        #endregion

        #region "Other Methods"

        public DataTable Select_Country_By_Code(bool IsForeign, string Keysearch)
        {
            DataAccess DAL = m_DAL;
            try
            {
                DataSet ds = new DataSet();
                DAL.CommandType = CommandType.StoredProcedure;
                DAL.CommandText = SP_List_CountryOrPlace;
                DAL.Parameters.Clear();
                DAL.Parameters.Add(new ParamStruct("@Action", DbType.String, "SelectByCode", ParameterDirection.Input, 50));
                DAL.Parameters.Add(new ParamStruct("@IsForeign", DbType.Boolean, clsCommon.GetValueDBNull(IsForeign), ParameterDirection.Input, 2));
                DAL.Parameters.Add(new ParamStruct("@Keysearch", DbType.String, clsCommon.GetValueDBNull(Keysearch), ParameterDirection.Input, 250));
                ds = DAL.ExecDataSet();
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable Select_VisaCountry()
        {
            DataAccess DAL = m_DAL;
            try
            {
                DataSet ds = new DataSet();
                DAL.CommandType = CommandType.StoredProcedure;
                DAL.CommandText = SP_List_CountryOrPlace;
                DAL.Parameters.Clear();
                DAL.Parameters.Add(new ParamStruct("@Action", DbType.String, "SelectVisaCountry", ParameterDirection.Input, 50));

                ds = DAL.ExecDataSet();
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable SelectAll_VisaCountry()
        {
            DataAccess DAL = m_DAL;
            try
            {
                DataSet ds = new DataSet();
                DAL.CommandType = CommandType.StoredProcedure;
                DAL.CommandText = SP_List_CountryOrPlace;
                DAL.Parameters.Clear();
                DAL.Parameters.Add(new ParamStruct("@Action", DbType.String, "SelectAllVisaCountry", ParameterDirection.Input, 50));

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
