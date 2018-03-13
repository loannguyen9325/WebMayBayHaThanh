using System;
using System.Data;

using MayBayHaThanh.DAL;
using MayBayHaThanh.Utilities;

namespace MayBayHaThanh.Entities
{
    public class clsList_GeneralInfo
    {
        private const string SP_List_GeneralInfo = "SP_List_GeneralInfo";
        private DataAccess m_DAL = new DataAccess();

        #region "Variables"
        
        private string mvarAbout;
        private string mvarBookingAndPayment;
        private string mvarHotelBooking;
        private string mvarTravelInsurance;
        private string mvarAgencyPolicy;
        private string mvarCompanyName;
        private string mvarTaxNumber;
        private string mvarCompanyAddress;
        private string mvarCompanyMail;
        private string mvarHotline;
        private string mvarCompanyPhone;
        private string mvarCompanyFax;
        private string mvarLogo;
        private Int32 mvarLastUpdatedBy;
        private DateTime mvarLastUpdatedDate;

        #endregion

        #region "Properties"

        public string About
        {
            get { return mvarAbout; }
            set { mvarAbout = value; }
        }

        public string BookingAndPayment
        {
            get { return mvarBookingAndPayment; }
            set { mvarBookingAndPayment = value; }
        }

        public string HotelBooking
        {
            get { return mvarHotelBooking; }
            set { mvarHotelBooking = value; }
        }

        public string TravelInsurance
        {
            get { return mvarTravelInsurance; }
            set { mvarTravelInsurance = value; }
        }

        public string AgencyPolicy
        {
            get { return mvarAgencyPolicy; }
            set { mvarAgencyPolicy = value; }
        }

        public string CompanyName
        {
            get { return mvarCompanyName; }
            set { mvarCompanyName = value; }
        }

        public string TaxNumber
        {
            get { return mvarTaxNumber; }
            set { mvarTaxNumber = value; }
        }

        public string CompanyAddress
        {
            get { return mvarCompanyAddress; }
            set { mvarCompanyAddress = value; }
        }

        public string CompanyMail
        {
            get { return mvarCompanyMail; }
            set { mvarCompanyMail = value; }
        }

        public string Hotline
        {
            get { return mvarHotline; }
            set { mvarHotline = value; }
        }

        public string CompanyPhone
        {
            get { return mvarCompanyPhone; }
            set { mvarCompanyPhone = value; }
        }

        public string CompanyFax
        {
            get { return mvarCompanyFax; }
            set { mvarCompanyFax = value; }
        }

        public string Logo
        {
            get { return mvarLogo; }
            set { mvarLogo = value; }
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

        public clsList_GeneralInfo()
        {
            m_DAL = new DataAccess();
            Reset();
        }

        public clsList_GeneralInfo(DataAccess mdal)
        {
            m_DAL = mdal;
            Reset();
        }

        #endregion

        #region "Methods"

        public bool Update(string Field)
        {
            DataAccess DAL = m_DAL;
            try
            {
                DAL.CommandType = CommandType.StoredProcedure;
                DAL.CommandText = SP_List_GeneralInfo;
                DAL.Parameters.Clear();
                DAL.Parameters.Add(new ParamStruct("@Action", DbType.String, "Update", ParameterDirection.Input, 50));
                DAL.Parameters.Add(new ParamStruct("@Field", DbType.String, Utilities.clsCommon.GetValueDBNull(Field), ParameterDirection.Input, 50));
                DAL.Parameters.Add(new ParamStruct("@About", DbType.String, clsCommon.GetValueDBNull(mvarAbout), ParameterDirection.Input, 1000000));
                DAL.Parameters.Add(new ParamStruct("@BookingAndPayment", DbType.String, clsCommon.GetValueDBNull(mvarBookingAndPayment), ParameterDirection.Input, 1000000));
                DAL.Parameters.Add(new ParamStruct("@HotelBooking", DbType.String, clsCommon.GetValueDBNull(mvarHotelBooking), ParameterDirection.Input, 1000000));
                DAL.Parameters.Add(new ParamStruct("@TravelInsurance", DbType.String, clsCommon.GetValueDBNull(mvarTravelInsurance), ParameterDirection.Input, 1000000));
                DAL.Parameters.Add(new ParamStruct("@AgencyPolicy", DbType.String, clsCommon.GetValueDBNull(mvarAgencyPolicy), ParameterDirection.Input, 1000000));
                DAL.Parameters.Add(new ParamStruct("@CompanyName", DbType.String, clsCommon.GetValueDBNull(mvarCompanyName), ParameterDirection.Input, 250));
                DAL.Parameters.Add(new ParamStruct("@TaxNumber", DbType.String, clsCommon.GetValueDBNull(mvarTaxNumber), ParameterDirection.Input, 250));
                DAL.Parameters.Add(new ParamStruct("@CompanyAddress", DbType.String, clsCommon.GetValueDBNull(mvarCompanyAddress), ParameterDirection.Input, 250));
                DAL.Parameters.Add(new ParamStruct("@CompanyMail", DbType.String, clsCommon.GetValueDBNull(mvarCompanyMail), ParameterDirection.Input, 100));
                DAL.Parameters.Add(new ParamStruct("@Hotline", DbType.String, clsCommon.GetValueDBNull(mvarHotline), ParameterDirection.Input, 50));
                DAL.Parameters.Add(new ParamStruct("@CompanyPhone", DbType.String, clsCommon.GetValueDBNull(mvarCompanyPhone), ParameterDirection.Input, 15));
                DAL.Parameters.Add(new ParamStruct("@CompanyFax", DbType.String, clsCommon.GetValueDBNull(mvarCompanyFax), ParameterDirection.Input, 15));
                DAL.Parameters.Add(new ParamStruct("@Logo", DbType.String, clsCommon.GetValueDBNull(mvarLogo), ParameterDirection.Input, 200));
                DAL.Parameters.Add(new ParamStruct("@LastUpdatedBy", DbType.Int32, clsCommon.GetValueDBNull(mvarLastUpdatedBy), ParameterDirection.Input, 4));

                return (DAL.ExecNonQuery() > 0);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void Reset()
        {
            mvarAbout = string.Empty;
            mvarBookingAndPayment = string.Empty;
            mvarHotelBooking = string.Empty;
            mvarTravelInsurance = string.Empty;
            mvarAgencyPolicy = string.Empty;
            mvarCompanyName = string.Empty;
            mvarTaxNumber = string.Empty;
            mvarCompanyAddress = string.Empty;
            mvarCompanyMail = string.Empty;
            mvarHotline = string.Empty;
            mvarCompanyPhone = string.Empty;
            mvarCompanyFax = string.Empty;
            mvarLogo = string.Empty;
            mvarLastUpdatedBy = Int32.MinValue;
            mvarLastUpdatedDate = DateTime.MinValue;
        }

        public void FillData(DataRow row)
        {
            mvarAbout = clsCommon.GetValue(row["About"], mvarAbout.GetType().FullName).ToString();
            mvarBookingAndPayment = clsCommon.GetValue(row["BookingAndPayment"], mvarBookingAndPayment.GetType().FullName).ToString();
            mvarHotelBooking = clsCommon.GetValue(row["HotelBooking"], mvarHotelBooking.GetType().FullName).ToString();
            mvarTravelInsurance = clsCommon.GetValue(row["TravelInsurance"], mvarTravelInsurance.GetType().FullName).ToString();
            mvarAgencyPolicy = clsCommon.GetValue(row["AgencyPolicy"], mvarAgencyPolicy.GetType().FullName).ToString();
            mvarCompanyName = clsCommon.GetValue(row["CompanyName"], mvarCompanyName.GetType().FullName).ToString();
            mvarTaxNumber = clsCommon.GetValue(row["TaxNumber"], mvarTaxNumber.GetType().FullName).ToString();
            mvarCompanyAddress = clsCommon.GetValue(row["CompanyAddress"], mvarCompanyAddress.GetType().FullName).ToString();
            mvarCompanyMail = clsCommon.GetValue(row["CompanyMail"], mvarCompanyMail.GetType().FullName).ToString();
            mvarHotline = clsCommon.GetValue(row["Hotline"], mvarHotline.GetType().FullName).ToString();
            mvarCompanyPhone = clsCommon.GetValue(row["CompanyPhone"], mvarCompanyPhone.GetType().FullName).ToString();
            mvarCompanyFax = clsCommon.GetValue(row["CompanyFax"], mvarCompanyFax.GetType().FullName).ToString();
            mvarLogo = clsCommon.GetValue(row["Logo"], mvarLogo.GetType().FullName).ToString();
            mvarLastUpdatedBy = Int32.Parse(clsCommon.GetValue(row["LastUpdatedBy"], mvarLastUpdatedBy.GetType().FullName).ToString());
            mvarLastUpdatedDate = DateTime.Parse(clsCommon.GetValue(row["LastUpdatedDate"], mvarLastUpdatedDate.GetType().FullName).ToString());
        }

        #endregion

        #region "Other Methods"

        public DataTable Select_GeneralInfo_By_Code(string Field)
        {
            DataAccess DAL = m_DAL;
            try
            {
                DataSet ds = new DataSet();
                DAL.CommandType = CommandType.StoredProcedure;
                DAL.CommandText = SP_List_GeneralInfo;
                DAL.Parameters.Clear();
                DAL.Parameters.Add(new ParamStruct("@Action", DbType.String, "SelectByCode", ParameterDirection.Input, 50));
                DAL.Parameters.Add(new ParamStruct("@Field", DbType.String, clsCommon.GetValueDBNull(Field), ParameterDirection.Input, 50));
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
