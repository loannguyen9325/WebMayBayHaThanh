using System;
using System.Data;

using MayBayHaThanh.DAL;
using MayBayHaThanh.Utilities;

namespace MayBayHaThanh.Entities
{
    public class clsList_Account
    {
        private const string SP_List_Account = "SP_List_Account";
        private DataAccess m_DAL = new DataAccess();

        #region "Variables"

        private Int32 mvarUserID;
        private string mvarUserName;
        private string mvarSALT;
        private string mvarUserPassword;
        private string mvarFullName;
        private string mvarOriginalPassword;
        private bool mvarGender;
        private string mvarUserAddress;
        private string mvarDeskphoneNo;
        private string mvarPhoneNo;
        private string mvarEmailAddress;
        private string mvarSkypeAccount;
        private bool mvarIsConsultant; 
        private string mvarUserImage;
        private Int32 mvarCreatedBy;
        private DateTime mvarCreatedDate;
        private Int32 mvarLastUpdatedBy;
        private DateTime mvarLastUpdatedDate;

        #endregion

        #region "Properties"

        public Int32 UserID
        {
            get { return mvarUserID; }
            set { mvarUserID = value; }
        }

        public string UserName
        {
            get { return mvarUserName; }
            set { mvarUserName = value; }
        }

        public string SALT
        {
            get { return mvarSALT; }
            set { mvarSALT = value; }
        }

        public string UserPassword
        {
            get { return mvarUserPassword; }
            set { mvarUserPassword = value; }
        }

        public string FullName
        {
            get { return mvarFullName; }
            set { mvarFullName = value; }
        }

        public string OriginalPassword
        {
            get { return mvarOriginalPassword; }
            set { mvarOriginalPassword = value; }
        }

        public bool Gender
        {
            get { return mvarGender; }
            set { mvarGender = value; }
        }

        public string UserAddress
        {
            get { return mvarUserAddress; }
            set { mvarUserAddress = value; }
        }

        public string DeskphoneNo
        {
            get { return mvarDeskphoneNo; }
            set { mvarDeskphoneNo = value; }
        }

        public string PhoneNo
        {
            get { return mvarPhoneNo; }
            set { mvarPhoneNo = value; }
        }

        public string EmailAddress
        {
            get { return mvarEmailAddress; }
            set { mvarEmailAddress = value; }
        }

        public string SkypeAccount
        {
            get { return mvarSkypeAccount; }
            set { mvarSkypeAccount = value; }
        }

        public bool IsConsultant
        {
            get { return mvarIsConsultant; }
            set { mvarIsConsultant = value; }
        }

        public string UserImage
        {
            get { return mvarUserImage; }
            set { mvarUserImage = value; }
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

        public clsList_Account()
        {
            m_DAL = new DataAccess();
            Reset();
        }

        public clsList_Account(DataAccess mdal)
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
                DAL.CommandText = SP_List_Account;
                DAL.Parameters.Clear();
                DAL.Parameters.Add(new ParamStruct("@Action", DbType.String, "Insert", ParameterDirection.Input, 50));
                DAL.Parameters.Add(new ParamStruct("@UserName", DbType.String, clsCommon.GetValueDBNull(mvarUserName), ParameterDirection.Input, 50));
                DAL.Parameters.Add(new ParamStruct("@SALT", DbType.String, clsCommon.GetValueDBNull(mvarSALT), ParameterDirection.Input, 50));
                DAL.Parameters.Add(new ParamStruct("@UserPassword", DbType.String, clsCommon.GetValueDBNull(mvarUserPassword), ParameterDirection.Input, 250));
                DAL.Parameters.Add(new ParamStruct("@FullName", DbType.String, clsCommon.GetValueDBNull(mvarFullName), ParameterDirection.Input, 100));
                DAL.Parameters.Add(new ParamStruct("@OriginalPassword", DbType.String, clsCommon.GetValueDBNull(mvarOriginalPassword), ParameterDirection.Input, 250));
                DAL.Parameters.Add(new ParamStruct("@Gender", DbType.Boolean, clsCommon.GetValueDBNull(mvarGender), ParameterDirection.Input, 2));
                DAL.Parameters.Add(new ParamStruct("@UserAddress", DbType.String, clsCommon.GetValueDBNull(mvarUserAddress), ParameterDirection.Input, 250));
                DAL.Parameters.Add(new ParamStruct("@DeskphoneNo", DbType.String, clsCommon.GetValueDBNull(mvarDeskphoneNo), ParameterDirection.Input, 15));
                DAL.Parameters.Add(new ParamStruct("@PhoneNo", DbType.String, clsCommon.GetValueDBNull(mvarPhoneNo), ParameterDirection.Input, 15));
                DAL.Parameters.Add(new ParamStruct("@EmailAddress", DbType.String, clsCommon.GetValueDBNull(mvarEmailAddress), ParameterDirection.Input, 100));
                DAL.Parameters.Add(new ParamStruct("@SkypeAccount", DbType.String, clsCommon.GetValueDBNull(mvarSkypeAccount), ParameterDirection.Input, 100));
                DAL.Parameters.Add(new ParamStruct("@IsConsultant", DbType.Boolean, clsCommon.GetValueDBNull(mvarIsConsultant), ParameterDirection.Input, 2));
                DAL.Parameters.Add(new ParamStruct("@UserImage", DbType.String, clsCommon.GetValueDBNull(mvarUserImage), ParameterDirection.Input, 200));
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
                DAL.CommandText = SP_List_Account;
                DAL.Parameters.Clear();
                DAL.Parameters.Add(new ParamStruct("@Action", DbType.String, "Update", ParameterDirection.Input, 50));
                DAL.Parameters.Add(new ParamStruct("@UserID", DbType.Int32, clsCommon.GetValueDBNull(mvarUserID), ParameterDirection.InputOutput, 4));
                DAL.Parameters.Add(new ParamStruct("@UserName", DbType.String, clsCommon.GetValueDBNull(mvarUserName), ParameterDirection.Input, 50));
                DAL.Parameters.Add(new ParamStruct("@UserPassword", DbType.String, clsCommon.GetValueDBNull(mvarUserPassword), ParameterDirection.Input, 250));
                DAL.Parameters.Add(new ParamStruct("@FullName", DbType.String, clsCommon.GetValueDBNull(mvarFullName), ParameterDirection.Input, 100));
                DAL.Parameters.Add(new ParamStruct("@OriginalPassword", DbType.String, clsCommon.GetValueDBNull(mvarOriginalPassword), ParameterDirection.Input, 250));
                DAL.Parameters.Add(new ParamStruct("@Gender", DbType.Boolean, clsCommon.GetValueDBNull(mvarGender), ParameterDirection.Input, 2));
                DAL.Parameters.Add(new ParamStruct("@UserAddress", DbType.String, clsCommon.GetValueDBNull(mvarUserAddress), ParameterDirection.Input, 250));
                DAL.Parameters.Add(new ParamStruct("@DeskphoneNo", DbType.String, clsCommon.GetValueDBNull(mvarDeskphoneNo), ParameterDirection.Input, 15));
                DAL.Parameters.Add(new ParamStruct("@PhoneNo", DbType.String, clsCommon.GetValueDBNull(mvarPhoneNo), ParameterDirection.Input, 15));
                DAL.Parameters.Add(new ParamStruct("@EmailAddress", DbType.String, clsCommon.GetValueDBNull(mvarEmailAddress), ParameterDirection.Input, 100));
                DAL.Parameters.Add(new ParamStruct("@SkypeAccount", DbType.String, clsCommon.GetValueDBNull(mvarSkypeAccount), ParameterDirection.Input, 100));
                DAL.Parameters.Add(new ParamStruct("@IsConsultant", DbType.Boolean, clsCommon.GetValueDBNull(mvarIsConsultant), ParameterDirection.Input, 2));
                DAL.Parameters.Add(new ParamStruct("@UserImage", DbType.String, clsCommon.GetValueDBNull(mvarUserImage), ParameterDirection.Input, 200));
                DAL.Parameters.Add(new ParamStruct("@LastUpdatedBy", DbType.Int32, clsCommon.GetValueDBNull(mvarLastUpdatedBy), ParameterDirection.Input, 4));

                return (DAL.ExecNonQuery() > 0);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int UserID)
        {
            DataAccess DAL = m_DAL;
            try
            {
                DAL.CommandType = CommandType.StoredProcedure;
                DAL.CommandText = SP_List_Account;
                DAL.Parameters.Clear();
                DAL.Parameters.Add(new ParamStruct("@Action", DbType.String, "Delete", ParameterDirection.Input, 50));
                DAL.Parameters.Add(new ParamStruct("@UserID", DbType.Int32, clsCommon.GetValueDBNull(UserID), ParameterDirection.InputOutput, 4));
                DAL.Parameters.Add(new ParamStruct("@LastUpdatedBy", DbType.Int32, clsCommon.GetValueDBNull(mvarLastUpdatedBy), ParameterDirection.Input, 4));
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
                DAL.CommandText = SP_List_Account;
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

        public DataTable SelectByKey(int UserID)
        {
            DataAccess DAL = m_DAL;
            try
            {
                DataSet ds = new DataSet();
                DAL.CommandType = CommandType.StoredProcedure;
                DAL.CommandText = SP_List_Account;
                DAL.Parameters.Clear();
                DAL.Parameters.Add(new ParamStruct("@Action", DbType.String, "SelectByKey", ParameterDirection.Input, 50));
                DAL.Parameters.Add(new ParamStruct("@UserID", DbType.Int32, clsCommon.GetValueDBNull(UserID), ParameterDirection.InputOutput, 4));

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
            mvarUserID = Int32.MinValue;
            mvarUserName = string.Empty;
            mvarSALT = string.Empty;
            mvarUserPassword = string.Empty;
            mvarFullName = string.Empty;
            mvarOriginalPassword = string.Empty;
            mvarGender = false;
            mvarUserAddress = string.Empty;
            mvarDeskphoneNo = string.Empty;
            mvarPhoneNo = string.Empty;
            mvarEmailAddress = string.Empty;
            mvarSkypeAccount = string.Empty;
            mvarIsConsultant = false;
            mvarUserImage = string.Empty;
            mvarCreatedBy = Int32.MinValue;
            mvarCreatedDate = DateTime.MinValue;
            mvarLastUpdatedBy = Int32.MinValue;
            mvarLastUpdatedDate = DateTime.MinValue;
        }

        public void FillData(DataRow row)
        {
            mvarUserID = Int32.Parse(clsCommon.GetValue(row["UserID"], mvarUserID.GetType().FullName).ToString());
            mvarUserName = clsCommon.GetValue(row["UserName"], mvarUserName.GetType().FullName).ToString();
            mvarSALT = clsCommon.GetValue(row["SALT"], mvarSALT.GetType().FullName).ToString();
            mvarUserPassword = clsCommon.GetValue(row["UserPassword"], mvarUserPassword.GetType().FullName).ToString();
            mvarFullName = clsCommon.GetValue(row["FullName"], mvarFullName.GetType().FullName).ToString();
            mvarOriginalPassword = clsCommon.GetValue(row["OriginalPassword"], mvarOriginalPassword.GetType().FullName).ToString();
            mvarGender = Boolean.Parse(clsCommon.GetValue(row["Gender"], mvarGender.GetType().FullName).ToString());
            mvarUserAddress = clsCommon.GetValue(row["UserAddress"], mvarUserAddress.GetType().FullName).ToString();
            mvarDeskphoneNo = clsCommon.GetValue(row["DeskphoneNo"], mvarDeskphoneNo.GetType().FullName).ToString();
            mvarPhoneNo = clsCommon.GetValue(row["PhoneNo"], mvarPhoneNo.GetType().FullName).ToString();
            mvarEmailAddress = clsCommon.GetValue(row["EmailAddress"], mvarEmailAddress.GetType().FullName).ToString();
            mvarSkypeAccount = clsCommon.GetValue(row["SkypeAccount"], mvarSkypeAccount.GetType().FullName).ToString();
            mvarIsConsultant = Boolean.Parse(clsCommon.GetValue(row["IsConsultant"], mvarIsConsultant.GetType().FullName).ToString());
            mvarUserImage = clsCommon.GetValue(row["UserImage"], mvarUserImage.GetType().FullName).ToString();
            mvarCreatedBy = Int32.Parse(clsCommon.GetValue(row["CreatedBy"], mvarCreatedBy.GetType().FullName).ToString());
            mvarCreatedDate = DateTime.Parse(clsCommon.GetValue(row["CreatedDate"], mvarCreatedDate.GetType().FullName).ToString());
            mvarLastUpdatedBy = Int32.Parse(clsCommon.GetValue(row["LastUpdatedBy"], mvarLastUpdatedBy.GetType().FullName).ToString());
            mvarLastUpdatedDate = DateTime.Parse(clsCommon.GetValue(row["LastUpdatedDate"], mvarLastUpdatedDate.GetType().FullName).ToString());
        }

        #endregion

        #region "Other Methods"

        public bool Select_Account_By_UserName(string UserName)
        {
            DataAccess DAL = m_DAL;
            try
            {
                DataSet ds = new DataSet();
                DAL.CommandType = CommandType.StoredProcedure;
                DAL.CommandText = SP_List_Account;
                DAL.Parameters.Clear();
                DAL.Parameters.Add(new ParamStruct("@Action", DbType.String, "SelectByCode", ParameterDirection.Input, 50));
                DAL.Parameters.Add(new ParamStruct("@UserName", DbType.String, clsCommon.GetValueDBNull(UserName), ParameterDirection.Input, 50));
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

        public DataTable Select_SALT_By_UserName(string UserName)
        {
            DataAccess DAL = m_DAL;
            try
            {
                DataSet ds = new DataSet();
                DAL.CommandType = CommandType.StoredProcedure;
                DAL.CommandText = SP_List_Account;
                DAL.Parameters.Clear();
                DAL.Parameters.Add(new ParamStruct("@Action", DbType.String, "SelectByCode", ParameterDirection.Input, 50));
                DAL.Parameters.Add(new ParamStruct("@UserName", DbType.String, clsCommon.GetValueDBNull(UserName), ParameterDirection.Input, 50));

                ds = DAL.ExecDataSet();
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable Select_Top2_Consultant()
        {
            DataAccess DAL = m_DAL;
            try
            {
                DataSet ds = new DataSet();
                DAL.CommandType = CommandType.StoredProcedure;
                DAL.CommandText = SP_List_Account;
                DAL.Parameters.Clear();
                DAL.Parameters.Add(new ParamStruct("@Action", DbType.String, "SelectTop2Consultant", ParameterDirection.Input, 50));

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
