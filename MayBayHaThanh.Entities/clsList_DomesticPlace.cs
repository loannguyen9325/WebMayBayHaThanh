using System;
using System.Data;

using MayBayHaThanh.DAL;
using MayBayHaThanh.Utilities;

namespace MayBayHaThanh.Entities
{
    public class clsList_DomesticPlace
    {
        private const string SP_List_DomesticPlace = "SP_List_DomesticPlace";
        private DataAccess m_DAL = new DataAccess();

        #region "Variables"

        private Int32 mvarDomesticPlaceID;
        private string mvarDomesticPlaceName;

        #endregion

        #region "Properties"

        public Int32 DomesticPlaceID
        {
            get { return mvarDomesticPlaceID; }
            set { mvarDomesticPlaceID = value; }
        }

        public string DomesticPlaceName
        {
            get { return mvarDomesticPlaceName; }
            set { mvarDomesticPlaceName = value; }
        }

        #endregion

        #region "Constructors"

        public clsList_DomesticPlace()
        {
            m_DAL = new DataAccess();
            Reset();
        }

        public clsList_DomesticPlace(DataAccess mdal)
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
                DAL.CommandText = SP_List_DomesticPlace;
                DAL.Parameters.Clear();
                DAL.Parameters.Add(new ParamStruct("@Action", DbType.String, "Insert", ParameterDirection.Input, 50));
                DAL.Parameters.Add(new ParamStruct("@DomesticPlaceName", DbType.String, clsCommon.GetValueDBNull(mvarDomesticPlaceName), ParameterDirection.Input, 100));

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
                DAL.CommandText = SP_List_DomesticPlace;
                DAL.Parameters.Clear();
                DAL.Parameters.Add(new ParamStruct("@Action", DbType.String, "Update", ParameterDirection.Input, 50));
                DAL.Parameters.Add(new ParamStruct("@DomesticPlaceID", DbType.Int32, clsCommon.GetValueDBNull(mvarDomesticPlaceID), ParameterDirection.InputOutput, 4));
                DAL.Parameters.Add(new ParamStruct("@DomesticPlaceName", DbType.String, clsCommon.GetValueDBNull(mvarDomesticPlaceName), ParameterDirection.Input, 100));

                return (DAL.ExecNonQuery() > 0);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int DomesticPlaceID)
        {
            DataAccess DAL = m_DAL;
            try
            {
                DAL.CommandType = CommandType.StoredProcedure;
                DAL.CommandText = SP_List_DomesticPlace;
                DAL.Parameters.Clear();
                DAL.Parameters.Add(new ParamStruct("@Action", DbType.String, "Delete", ParameterDirection.Input, 50));
                DAL.Parameters.Add(new ParamStruct("@DomesticPlaceID", DbType.Int32, clsCommon.GetValueDBNull(DomesticPlaceID), ParameterDirection.InputOutput, 4));
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
                DAL.CommandText = SP_List_DomesticPlace;
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

        public DataTable SelectByKey(int DomesticPlaceID)
        {
            DataAccess DAL = m_DAL;
            try
            {
                DataSet ds = new DataSet();
                DAL.CommandType = CommandType.StoredProcedure;
                DAL.CommandText = SP_List_DomesticPlace;
                DAL.Parameters.Clear();
                DAL.Parameters.Add(new ParamStruct("@Action", DbType.String, "SelectByKey", ParameterDirection.Input, 50));
                DAL.Parameters.Add(new ParamStruct("@DomesticPlaceID", DbType.Int32, clsCommon.GetValueDBNull(DomesticPlaceID), ParameterDirection.InputOutput, 4));

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
            mvarDomesticPlaceID = Int32.MinValue;
            mvarDomesticPlaceName = string.Empty;
        }

        public void FillData(DataRow row)
        {
            mvarDomesticPlaceID = Int32.Parse(clsCommon.GetValue(row["DomesticPlaceID"], mvarDomesticPlaceID.GetType().FullName).ToString());
            mvarDomesticPlaceName = clsCommon.GetValue(row["DomesticPlaceName"], mvarDomesticPlaceName.GetType().FullName).ToString();
        }

        #endregion

        #region "Other Methods"

        public DataTable Select_DomesticPlace_By_Code(string Keysearch)
        {
            DataAccess DAL = m_DAL;
            try
            {
                DataSet ds = new DataSet();
                DAL.CommandType = CommandType.StoredProcedure;
                DAL.CommandText = SP_List_DomesticPlace;
                DAL.Parameters.Clear();
                DAL.Parameters.Add(new ParamStruct("@Action", DbType.String, "SelectByCode", ParameterDirection.Input, 50));
                DAL.Parameters.Add(new ParamStruct("@Keysearch", DbType.String, clsCommon.GetValueDBNull(Keysearch), ParameterDirection.Input, 250));
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
