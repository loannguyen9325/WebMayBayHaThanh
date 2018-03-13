using System;
using System.Data;

using MayBayHaThanh.DAL;
using MayBayHaThanh.Utilities;

namespace MayBayHaThanh.Entities
{
    public class clsList_Product
    {
        private const string SP_List_Product = "SP_List_Product";
        private DataAccess m_DAL = new DataAccess();

        #region "Variables"

        private Int32 mvarProductID;
        private Int32 mvarProductTypeID;
        private Int32 mvarProductCategoryID;
        private Int32 mvarProductGroupID;
        private string mvarProductName;
        private Int32 mvarLeavingFrom;
        private Int32 mvarGoingTo;
        private Int32 mvarBrandID;
        private DateTime mvarProductEffectedDate;
        private float mvarProductPrice;
        private string mvarProductContent;
        private string mvarProductImage;
        private Int32 mvarProductStatus;
        private Int32 mvarCreatedBy;
        private DateTime mvarCreatedDate;
        private Int32 mvarLastUpdatedBy;
        private DateTime mvarLastUpdatedDate;

        #endregion

        #region "Properties"

        public Int32 ProductID
        {
            get { return mvarProductID; }
            set { mvarProductID = value; }
        }

        public Int32 ProductTypeID
        {
            get { return mvarProductTypeID; }
            set { mvarProductTypeID = value; }
        }

        public Int32 ProductCategoryID
        {
            get { return mvarProductCategoryID; }
            set { mvarProductCategoryID = value; }
        }

        public Int32 ProductGroupID
        {
            get { return mvarProductGroupID; }
            set { mvarProductGroupID = value; }
        }

        public string ProductName
        {
            get { return mvarProductName; }
            set { mvarProductName = value; }
        }

        public Int32 LeavingFrom
        {
            get { return mvarLeavingFrom; }
            set { mvarLeavingFrom = value; }
        }

        public Int32 GoingTo
        {
            get { return mvarGoingTo; }
            set { mvarGoingTo = value; }
        }

        public Int32 BrandID
        {
            get { return mvarBrandID; }
            set { mvarBrandID = value; }
        }

        public DateTime ProductEffectedDate
        {
            get { return mvarProductEffectedDate; }
            set { mvarProductEffectedDate = value; }
        }

        public float ProductPrice
        {
            get { return mvarProductPrice; }
            set { mvarProductPrice = value; }
        }

        public string ProductContent
        {
            get { return mvarProductContent; }
            set { mvarProductContent = value; }
        }

        public string ProductImage
        {
            get { return mvarProductImage; }
            set { mvarProductImage = value; }
        }

        public Int32 ProductStatus
        {
            get { return mvarProductStatus; }
            set { mvarProductStatus = value; }
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

        public clsList_Product()
        {
            m_DAL = new DataAccess();
            Reset();
        }

        public clsList_Product(DataAccess mdal)
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
                DAL.CommandText = SP_List_Product;
                DAL.Parameters.Clear();
                DAL.Parameters.Add(new ParamStruct("@Action", DbType.String, "Insert", ParameterDirection.Input, 50));
                DAL.Parameters.Add(new ParamStruct("@ProductTypeID", DbType.Int32, clsCommon.GetValueDBNull(mvarProductTypeID), ParameterDirection.InputOutput, 4));
                DAL.Parameters.Add(new ParamStruct("@ProductCategoryID", DbType.Int32, clsCommon.GetValueDBNull(mvarProductCategoryID), ParameterDirection.InputOutput, 4));
                DAL.Parameters.Add(new ParamStruct("@ProductGroupID", DbType.Int32, clsCommon.GetValueDBNull(mvarProductGroupID), ParameterDirection.InputOutput, 4));
                DAL.Parameters.Add(new ParamStruct("@ProductName", DbType.String, clsCommon.GetValueDBNull(mvarProductName), ParameterDirection.Input, 250));
                DAL.Parameters.Add(new ParamStruct("@LeavingFrom", DbType.Int32, clsCommon.GetValueDBNull(mvarLeavingFrom), ParameterDirection.InputOutput, 4));
                DAL.Parameters.Add(new ParamStruct("@GoingTo", DbType.Int32, clsCommon.GetValueDBNull(mvarGoingTo), ParameterDirection.InputOutput, 4));
                DAL.Parameters.Add(new ParamStruct("@BrandID", DbType.Int32, clsCommon.GetValueDBNull(mvarBrandID), ParameterDirection.InputOutput, 4));
                DAL.Parameters.Add(new ParamStruct("@ProductEffectedDate", DbType.DateTime, clsCommon.GetValueDBNull(mvarProductEffectedDate), ParameterDirection.Input, 16));
                DAL.Parameters.Add(new ParamStruct("@ProductPrice", DbType.Double, clsCommon.GetValueDBNull(mvarProductPrice), ParameterDirection.InputOutput, 4));
                DAL.Parameters.Add(new ParamStruct("@ProductContent", DbType.String, clsCommon.GetValueDBNull(mvarProductContent), ParameterDirection.Input, 1000000));
                DAL.Parameters.Add(new ParamStruct("@ProductImage", DbType.String, clsCommon.GetValueDBNull(mvarProductImage), ParameterDirection.Input, 200));
                DAL.Parameters.Add(new ParamStruct("@ProductStatus", DbType.Int32, clsCommon.GetValueDBNull(mvarProductStatus), ParameterDirection.InputOutput, 4));
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
                DAL.CommandText = SP_List_Product;
                DAL.Parameters.Clear();
                DAL.Parameters.Add(new ParamStruct("@Action", DbType.String, "Update", ParameterDirection.Input, 50));
                DAL.Parameters.Add(new ParamStruct("@ProductID", DbType.Int32, clsCommon.GetValueDBNull(mvarProductID), ParameterDirection.InputOutput, 4));
                DAL.Parameters.Add(new ParamStruct("@ProductTypeID", DbType.Int32, clsCommon.GetValueDBNull(mvarProductTypeID), ParameterDirection.InputOutput, 4));
                DAL.Parameters.Add(new ParamStruct("@ProductCategoryID", DbType.Int32, clsCommon.GetValueDBNull(mvarProductCategoryID), ParameterDirection.InputOutput, 4));
                DAL.Parameters.Add(new ParamStruct("@ProductGroupID", DbType.Int32, clsCommon.GetValueDBNull(mvarProductGroupID), ParameterDirection.InputOutput, 4));
                DAL.Parameters.Add(new ParamStruct("@ProductName", DbType.String, clsCommon.GetValueDBNull(mvarProductName), ParameterDirection.Input, 250));
                DAL.Parameters.Add(new ParamStruct("@LeavingFrom", DbType.Int32, clsCommon.GetValueDBNull(mvarLeavingFrom), ParameterDirection.InputOutput, 4));
                DAL.Parameters.Add(new ParamStruct("@GoingTo", DbType.Int32, clsCommon.GetValueDBNull(mvarGoingTo), ParameterDirection.InputOutput, 4));
                DAL.Parameters.Add(new ParamStruct("@BrandID", DbType.Int32, clsCommon.GetValueDBNull(mvarBrandID), ParameterDirection.InputOutput, 4));
                DAL.Parameters.Add(new ParamStruct("@ProductEffectedDate", DbType.DateTime, clsCommon.GetValueDBNull(mvarProductEffectedDate), ParameterDirection.Input, 16));
                DAL.Parameters.Add(new ParamStruct("@ProductPrice", DbType.Double, clsCommon.GetValueDBNull(mvarProductPrice), ParameterDirection.InputOutput, 4));
                DAL.Parameters.Add(new ParamStruct("@ProductContent", DbType.String, clsCommon.GetValueDBNull(mvarProductContent), ParameterDirection.Input, 1000000));
                DAL.Parameters.Add(new ParamStruct("@ProductImage", DbType.String, clsCommon.GetValueDBNull(mvarProductImage), ParameterDirection.Input, 200));
                DAL.Parameters.Add(new ParamStruct("@ProductStatus", DbType.Int32, clsCommon.GetValueDBNull(mvarProductStatus), ParameterDirection.InputOutput, 4));
                DAL.Parameters.Add(new ParamStruct("@LastUpdatedBy", DbType.Int32, clsCommon.GetValueDBNull(mvarLastUpdatedBy), ParameterDirection.Input, 4));

                return (DAL.ExecNonQuery() > 0);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int ProductID)
        {
            DataAccess DAL = m_DAL;
            try
            {
                DAL.CommandType = CommandType.StoredProcedure;
                DAL.CommandText = SP_List_Product;
                DAL.Parameters.Clear();
                DAL.Parameters.Add(new ParamStruct("@Action", DbType.String, "Delete", ParameterDirection.Input, 50));
                DAL.Parameters.Add(new ParamStruct("@ProductID", DbType.Int32, clsCommon.GetValueDBNull(ProductID), ParameterDirection.InputOutput, 4));
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
                DAL.CommandText = SP_List_Product;
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

        public bool SelectByKey(int ProductID)
        {
            DataAccess DAL = m_DAL;
            try
            {
                DataSet ds = new DataSet();
                DAL.CommandType = CommandType.StoredProcedure;
                DAL.CommandText = SP_List_Product;
                DAL.Parameters.Clear();
                DAL.Parameters.Add(new ParamStruct("@Action", DbType.String, "SelectByKey", ParameterDirection.Input, 50));
                DAL.Parameters.Add(new ParamStruct("@ProductID", DbType.Int32, clsCommon.GetValueDBNull(ProductID), ParameterDirection.InputOutput, 4));
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
            mvarProductID = Int32.MinValue;
            mvarProductTypeID = Int32.MinValue;
            mvarProductCategoryID = Int32.MinValue;
            mvarProductGroupID = Int32.MinValue;
            mvarProductName = string.Empty;
            mvarLeavingFrom = Int32.MinValue;
            mvarGoingTo = Int32.MinValue;
            mvarBrandID = Int32.MinValue;
            mvarProductEffectedDate = DateTime.MinValue;
            mvarProductPrice = float.MinValue;
            mvarProductContent = string.Empty;
            mvarProductImage = string.Empty;
            mvarProductStatus = Int32.MinValue;
            mvarCreatedBy = Int32.MinValue;
            mvarCreatedDate = DateTime.MinValue;
            mvarLastUpdatedBy = Int32.MinValue;
            mvarLastUpdatedDate = DateTime.MinValue;
        }

        public void FillData(DataRow row)
        {
            mvarProductID = Int32.Parse(clsCommon.GetValue(row["ProductID"], mvarProductID.GetType().FullName).ToString());
            mvarProductTypeID = Int32.Parse(clsCommon.GetValue(row["ProductTypeID"], mvarProductTypeID.GetType().FullName).ToString());
            mvarProductCategoryID = Int32.Parse(clsCommon.GetValue(row["ProductCategoryID"], mvarProductCategoryID.GetType().FullName).ToString());
            mvarProductGroupID = Int32.Parse(clsCommon.GetValue(row["ProductGroupID"], mvarProductGroupID.GetType().FullName).ToString());
            mvarProductName = clsCommon.GetValue(row["ProductName"], mvarProductName.GetType().FullName).ToString();
            mvarLeavingFrom = Int32.Parse(clsCommon.GetValue(row["LeavingFrom"], mvarLeavingFrom.GetType().FullName).ToString());
            mvarGoingTo = Int32.Parse(clsCommon.GetValue(row["GoingTo"], mvarGoingTo.GetType().FullName).ToString());
            mvarBrandID = Int32.Parse(clsCommon.GetValue(row["BrandID"], mvarBrandID.GetType().FullName).ToString());
            mvarProductEffectedDate = DateTime.Parse(clsCommon.GetValue(row["ProductEffectedDate"], mvarProductEffectedDate.GetType().FullName).ToString());
            mvarProductPrice = float.Parse(clsCommon.GetValue(row["ProductPrice"], mvarProductPrice.GetType().FullName).ToString());
            mvarProductContent = clsCommon.GetValue(row["ProductContent"], mvarProductContent.GetType().FullName).ToString();
            mvarProductImage = clsCommon.GetValue(row["ProductImage"], mvarProductImage.GetType().FullName).ToString();
            mvarProductStatus = Int32.Parse(clsCommon.GetValue(row["ProductStatus"], mvarProductStatus.GetType().FullName).ToString());
            mvarCreatedBy = Int32.Parse(clsCommon.GetValue(row["CreatedBy"], mvarCreatedBy.GetType().FullName).ToString());
            mvarCreatedDate = DateTime.Parse(clsCommon.GetValue(row["CreatedDate"], mvarCreatedDate.GetType().FullName).ToString());
            mvarLastUpdatedBy = Int32.Parse(clsCommon.GetValue(row["LastUpdatedBy"], mvarLastUpdatedBy.GetType().FullName).ToString());
            mvarLastUpdatedDate = DateTime.Parse(clsCommon.GetValue(row["LastUpdatedDate"], mvarLastUpdatedDate.GetType().FullName).ToString());
        }

        #endregion

        #region "Other Methods"

        public DataTable Select_Product_By_Code(int ProductTypeID, string Keysearch)
        {
            DataAccess DAL = m_DAL;
            try
            {
                DataSet ds = new DataSet();
                DAL.CommandType = CommandType.StoredProcedure;
                DAL.CommandText = SP_List_Product;
                DAL.Parameters.Clear();
                DAL.Parameters.Add(new ParamStruct("@Action", DbType.String, "SelectByCode", ParameterDirection.Input, 50));
                DAL.Parameters.Add(new ParamStruct("@ProductTypeID", DbType.Int32, clsCommon.GetValueDBNull(ProductTypeID), ParameterDirection.InputOutput, 4));
                DAL.Parameters.Add(new ParamStruct("@Keysearch", DbType.String, clsCommon.GetValueDBNull(Keysearch), ParameterDirection.Input, 250));
                ds = DAL.ExecDataSet();
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable Select_Product_By_Category(int ProductCategoryID, string Keysearch)
        {
            DataAccess DAL = m_DAL;
            try
            {
                DataSet ds = new DataSet();
                DAL.CommandType = CommandType.StoredProcedure;
                DAL.CommandText = SP_List_Product;
                DAL.Parameters.Clear();
                DAL.Parameters.Add(new ParamStruct("@Action", DbType.String, "SelectByCategory", ParameterDirection.Input, 50));
                DAL.Parameters.Add(new ParamStruct("@ProductCategoryID", DbType.Int32, clsCommon.GetValueDBNull(ProductCategoryID), ParameterDirection.InputOutput, 4));
                DAL.Parameters.Add(new ParamStruct("@Keysearch", DbType.String, clsCommon.GetValueDBNull(Keysearch), ParameterDirection.Input, 250));
                ds = DAL.ExecDataSet();
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable Select_Top8_Newest_Post()
        {
            DataAccess DAL = m_DAL;
            try
            {
                DataSet ds = new DataSet();
                DAL.CommandType = CommandType.StoredProcedure;
                DAL.CommandText = SP_List_Product;
                DAL.Parameters.Clear();
                DAL.Parameters.Add(new ParamStruct("@Action", DbType.String, "SelectTop8NewestPost", ParameterDirection.Input, 50));

                ds = DAL.ExecDataSet();
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable Select_Top8_Cheapest_Post()
        {
            DataAccess DAL = m_DAL;
            try
            {
                DataSet ds = new DataSet();
                DAL.CommandType = CommandType.StoredProcedure;
                DAL.CommandText = SP_List_Product;
                DAL.Parameters.Clear();
                DAL.Parameters.Add(new ParamStruct("@Action", DbType.String, "SelectTop8CheapestPost", ParameterDirection.Input, 50));

                ds = DAL.ExecDataSet();
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable Select_Top4_Related_Post(int ProductID)
        {
            DataAccess DAL = m_DAL;
            try
            {
                DataSet ds = new DataSet();
                DAL.CommandType = CommandType.StoredProcedure;
                DAL.CommandText = SP_List_Product;
                DAL.Parameters.Clear();
                DAL.Parameters.Add(new ParamStruct("@Action", DbType.String, "SelectTop4RelatedPost", ParameterDirection.Input, 50));
                DAL.Parameters.Add(new ParamStruct("@ProductID", DbType.Int32, clsCommon.GetValueDBNull(ProductID), ParameterDirection.InputOutput, 4));

                ds = DAL.ExecDataSet();
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable Select_Total_Sale_Post()
        {
            DataAccess DAL = m_DAL;
            try
            {
                DataSet ds = new DataSet();
                DAL.CommandType = CommandType.StoredProcedure;
                DAL.CommandText = SP_List_Product;
                DAL.Parameters.Clear();
                DAL.Parameters.Add(new ParamStruct("@Action", DbType.String, "SelectTotalSalePost", ParameterDirection.Input, 50));

                ds = DAL.ExecDataSet();
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable Select_Total_Domestic_Post()
        {
            DataAccess DAL = m_DAL;
            try
            {
                DataSet ds = new DataSet();
                DAL.CommandType = CommandType.StoredProcedure;
                DAL.CommandText = SP_List_Product;
                DAL.Parameters.Clear();
                DAL.Parameters.Add(new ParamStruct("@Action", DbType.String, "SelectTotalDomesticPost", ParameterDirection.Input, 50));

                ds = DAL.ExecDataSet();
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable Select_Total_Foreign_Post()
        {
            DataAccess DAL = m_DAL;
            try
            {
                DataSet ds = new DataSet();
                DAL.CommandType = CommandType.StoredProcedure;
                DAL.CommandText = SP_List_Product;
                DAL.Parameters.Clear();
                DAL.Parameters.Add(new ParamStruct("@Action", DbType.String, "SelectTotalForeignPost", ParameterDirection.Input, 50));

                ds = DAL.ExecDataSet();
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable Select_Product_By_ID(int ProductID)
        {
            DataAccess DAL = m_DAL;
            try
            {
                DataSet ds = new DataSet();
                DAL.CommandType = CommandType.StoredProcedure;
                DAL.CommandText = SP_List_Product;
                DAL.Parameters.Clear();
                DAL.Parameters.Add(new ParamStruct("@Action", DbType.String, "SelectByID", ParameterDirection.Input, 50));
                DAL.Parameters.Add(new ParamStruct("@ProductID", DbType.Int32, clsCommon.GetValueDBNull(ProductID), ParameterDirection.InputOutput, 4));

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