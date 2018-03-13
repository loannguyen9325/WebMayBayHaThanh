using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayBayHaThanh.Utilities
{
    public class clsCommon
    {
        #region "Public Shared Methods"

        public static bool IsNumber(string obj)
        {
            foreach (var ch in obj)
            {
                if (!Char.IsNumber(ch))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsEmpty(object obj)
        {
            try
            {
                if (object.ReferenceEquals(obj, DBNull.Value) || obj == null)
                {
                    return true;
                }

                switch (obj.GetType().FullName.ToLower())
                {
                    case "system.string":
                        if (obj.ToString() == string.Empty)
                        {
                            return true;
                        }

                        break;
                    case "system.byte":
                        if (Convert.ToByte(obj) == byte.MinValue)
                        {
                            return true;
                        }

                        break;
                    case "system.byte()":
                        if (Convert.ToByte(obj) == 0)
                        {
                            return true;
                        }

                        break;
                    case "system.int16":
                        if (Convert.ToInt16(obj) == Int16.MinValue)
                        {
                            return true;
                        }

                        break;
                    case "system.int32":
                        if (Convert.ToInt32(obj) == Int32.MinValue)
                        {
                            return true;
                        }

                        break;
                    case "system.int64":
                        if (Convert.ToInt64(obj) == Int64.MinValue)
                        {
                            return true;
                        }

                        break;
                    case "system.uint16":
                        if (Convert.ToUInt16(obj).Equals(0))
                        {
                            return true;
                        }

                        break;
                    case "system.uint32":
                        if (Convert.ToUInt32(obj).Equals(0))
                        {
                            return true;
                        }

                        break;
                    case "system.uint64":
                        if (Convert.ToUInt64(obj).Equals(0))
                        {
                            return true;
                        }

                        break;
                    case "system.short":
                        if (Convert.ToInt16(obj) == Int16.MinValue)
                        {
                            return true;
                        }

                        break;
                    case "system.long":
                        if (Convert.ToInt32(obj) == Int32.MinValue)
                        {
                            return true;
                        }

                        break;
                    case "system.decimal":
                        if (Convert.ToDecimal(obj) == decimal.MinValue)
                        {
                            return true;
                        }

                        break;
                    case "system.double":
                        if (Convert.ToDouble(obj) == double.MinValue)
                        {
                            return true;
                        }

                        break;
                    case "system.single":
                        if (Convert.ToSingle(obj) == float.MinValue)
                        {
                            return true;
                        }

                        break;
                    case "system.datetime":
                        if (((DateTime)obj <= clsConstant.NULL_DATE))
                        {
                            return true;
                        }

                        break;
                    case "system.date":
                        if (((DateTime)obj <= clsConstant.NULL_DATE))
                        {
                            return true;
                        }

                        break;
                }
                return false;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool CorvertGender(string gednser)
        {
            if (gednser == "1")
            {
                return true;
            }
            else return false;
        }

        public static object GetValue(object obj)
        {
            return GetValue(obj, string.Empty);
        }

        public static object GetValue(object obj, string TypeFullName)
        {
            try
            {
                if ((TypeFullName == null || TypeFullName == string.Empty) && ((obj != null)))
                {
                    TypeFullName = obj.GetType().ToString();
                }

                if (TypeFullName == null)
                {
                    TypeFullName = string.Empty;
                }

                switch (TypeFullName.ToLower())
                {
                    case "system.string":
                        //Is System.DBNull.Value Then
                        if (!IsEmpty(obj))
                        {
                            return obj.ToString();
                        }
                        else
                        {
                            return string.Empty;
                        }
                       
                    case "system.boolean":
                        // Is System.DBNull.Value Then
                        if (!IsEmpty(obj))
                        {
                            if (obj.ToString() == "0")
                            {
                                return false;
                            }
                            else if (obj.ToString() == "1")
                            {
                                return true;
                            }
                            else
                            {
                                return bool.Parse(obj.ToString());
                            }
                        }
                        else
                        {
                            return false;
                        }
                        break;

                    case "system.byte":
                        if (!IsEmpty(obj))
                        {
                            return byte.Parse(obj.ToString());
                        }
                        else
                        {
                            return byte.MinValue;
                        }

                        break;

                    case "system.byte()":
                        if (!IsEmpty(obj))
                        {
                            return obj.ToString();
                        }
                        else
                        {
                            return null;
                        }

                        break;

                    case "byte()":
                        if (!IsEmpty(obj))
                        {
                            return obj;
                        }
                        else
                        {
                            return null;
                        }

                        break;

                    case "system.int16":
                        if (!IsEmpty(obj))
                        {
                            return Int16.Parse(obj.ToString());
                        }
                        else
                        {
                            return Int16.MinValue;
                        }

                        break;

                    case "system.int32":
                        if (!IsEmpty(obj))
                        {
                            return Int32.Parse(obj.ToString());
                            //Int32.Parse(obj.ToString)
                        }
                        else
                        {
                            return Int32.MinValue;
                        }

                        break;

                    case "system.int64":
                        if (!IsEmpty(obj))
                        {
                            return Int64.Parse(obj.ToString());
                        }
                        else
                        {
                            return Int64.MinValue;
                        }

                        break;

                    case "system.uint16":
                        if (!IsEmpty(obj))
                        {
                            return UInt16.Parse(obj.ToString());
                        }
                        else
                        {
                            return 0;
                        }

                        break;

                    case "system.uint32":
                        if (!IsEmpty(obj))
                        {
                            return UInt32.Parse(obj.ToString());
                        }
                        else
                        {
                            return 0;
                        }

                        break;

                    case "system.uint64":
                        if (!IsEmpty(obj))
                        {
                            return UInt64.Parse(obj.ToString());
                        }
                        else
                        {
                            return 0;
                        }

                        break;

                    case "system.short":
                        if (!IsEmpty(obj))
                        {
                            return short.Parse(obj.ToString());
                        }
                        else
                        {
                            return short.MinValue;
                        }

                        break;

                    case "system.long":
                        if (!IsEmpty(obj))
                        {
                            return long.Parse(obj.ToString());
                        }
                        else
                        {
                            return long.MinValue;
                        }

                        break;

                    case "system.decimal":
                        if (!IsEmpty(obj))
                        {
                            return decimal.Parse(obj.ToString());
                        }
                        else
                        {
                            return decimal.MinValue;
                        }

                        break;

                    case "system.double":
                        if (!IsEmpty(obj))
                        {
                            return double.Parse(obj.ToString());
                        }
                        else
                        {
                            return double.MinValue;
                        }

                        break;

                    case "system.single":
                        if (!IsEmpty(obj))
                        {
                            return float.Parse(obj.ToString());
                        }
                        else
                        {
                            return float.MinValue;
                        }

                        break;

                    case "system.datetime":
                        // If Not obj Is System.DBNull.Value Then
                        if ((!IsEmpty(obj)))
                        {
                            return DateTime.Parse(obj.ToString());
                        }
                        else
                        {
                            return System.DateTime.MinValue;
                            //Return Nothing
                        }

                        break;

                    case "system.date":
                        // If Not obj Is System.DBNull.Value Then
                        if ((!IsEmpty(obj)))
                        {
                            return System.DateTime.Parse(obj.ToString());
                        }
                        else
                        {
                            return System.DateTime.MinValue;
                            //Return Nothing
                        }

                        break;

                    default:
                        if ((!object.ReferenceEquals(obj, System.DBNull.Value)) && (obj != null))
                        {
                            return obj.ToString();
                        }
                        else
                        {
                            return null;
                        }

                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static object GetValueDBNull(object obj)
        {
            //If obj Is Nothing OrElse obj Is System.DBNull.Value OrElse obj = Nothing Then
            //    Return System.DBNull.Value
            //End If

            //Người sửa  : Hồ Quốc Duy
            //Ngày sửa   : 15-Apr-2005
            //Mục đích   : Không cần phép so sánh obj = Nothing
            //           bị sai khi obj là kiều Boolean thì obj = Nothing --> return DBNull (sai)
            if (obj == null || object.ReferenceEquals(obj, System.DBNull.Value))
            {
                return System.DBNull.Value;
            }

            switch (obj.GetType().Name.ToLower())
            {
                case "integer":
                    if ((int)obj == int.MinValue)
                    {
                        return System.DBNull.Value;
                    }
                    else
                    {
                        return obj;
                    }
                    break;

                case "int16":
                    if ((Int16)obj == Int16.MinValue)
                    {
                        return System.DBNull.Value;
                    }
                    else
                    {
                        return obj;
                    }
                    break;

                case "int32":
                    if ((Int32)obj == Int32.MinValue)
                    {
                        //return System.DBNull.Value;
                        return null;
                    }
                    else
                    {
                        return obj;
                    }
                    break;

                case "int64":
                    if ((Int64)obj == Int64.MinValue)
                    {
                        return System.DBNull.Value;
                    }
                    else
                    {
                        return obj;
                    }
                    break;

                case "double":
                    if ((double)obj == double.MinValue)
                    {
                        return System.DBNull.Value;
                    }
                    else
                    {
                        return obj;
                    }
                    break;

                case "single":
                    if ((Single)obj == Single.MinValue)
                    {
                        return System.DBNull.Value;
                    }
                    else
                    {
                        return obj;
                    }
                    break;

                case "long":
                    if ((long)obj == long.MinValue)
                    {
                        return System.DBNull.Value;
                    }
                    else
                    {
                        return obj;
                    }
                    break;

                case "decimal":
                    if ((decimal)obj == decimal.MinValue)
                    {
                        return System.DBNull.Value;
                    }
                    else
                    {
                        return obj;
                    }
                    break;

                case "short":
                    if ((short)obj == short.MinValue)
                    {
                        return System.DBNull.Value;
                    }
                    else
                    {
                        return obj;
                    }
                    break;

                case "byte":
                    if ((byte)obj == byte.MinValue)
                    {
                        return System.DBNull.Value;
                    }
                    else
                    {
                        return obj;
                    }
                    break;

                case "uint16":
                    if ((UInt16)obj == 0)
                    {
                        return System.DBNull.Value;
                    }
                    else
                    {
                        return obj;
                    }
                    break;

                case "uint32":
                    if ((UInt32)obj == 0)
                    {
                        return System.DBNull.Value;
                    }
                    else
                    {
                        return obj;
                    }
                    break;

                case "uint64":
                    if ((UInt64)obj == 0)
                    {
                        return System.DBNull.Value;
                    }
                    else
                    {
                        return obj;
                    }
                    break;

                case "boolean":
                    if (obj == null)
                    {
                        return false;
                    }
                    else
                    {
                        return obj;
                    }
                    break;

                case "string":
                    if ((string)obj == string.Empty || string.IsNullOrEmpty((string)obj))
                    {
                        return System.DBNull.Value;
                    }
                    else
                    {
                        return obj;
                    }
                    break;

                case "byte()":
                    if (obj == null)
                    {
                        return System.DBNull.Value;
                    }
                    else
                    {
                        return obj;
                    }
                    break;

                case "datetime":
                    if (((DateTime)obj == null) || (DateTime)obj == DateTime.MinValue)
                    {
                        return System.DBNull.Value;
                    }
                    else
                    {
                        return obj;
                    }
                    break;

                case "date":
                    if (((DateTime)obj == null))
                    {
                        return System.DBNull.Value;
                    }
                    else
                    {
                        return obj;
                    }
                    break;
            }
            return obj;
        }

        public static object ParseValue(object objValue, string TypeFullName)
        {
            try
            {
                switch (TypeFullName.ToLower())
                {
                    case "system.string":
                        return objValue.ToString();
                    case "system.date":
                    case "system.datetime":
                        return Convert.ToDateTime(objValue);
                    case "system.boolean":
                        return Convert.ToBoolean(objValue);
                    case "system.byte":
                        return Convert.ToByte(objValue);
                    case "system.int16":
                        return Convert.ToInt16(objValue);
                    case "system.integer":
                        return Convert.ToInt32(objValue);
                    case "system.int32":
                        //if DBNull(objValue)
                        return Convert.ToInt32(objValue.ToString());
                    case "system.int64":
                        return Convert.ToInt64(objValue.ToString());
                    case "system.decimal":
                        return Convert.ToDecimal(objValue);
                    case "system.Single":
                        return Convert.ToSingle(objValue);
                    case "system.Double":
                        return Convert.ToDouble(objValue);
                    case "system.SByte":
                        return Convert.ToSByte(objValue);
                    case "system.uint16":
                        return Convert.ToUInt16(objValue);
                    case "system.uint32":
                        return Convert.ToUInt32(objValue);
                    case "system.uint64":
                        return Convert.ToUInt64(objValue);
                    case "system.short":
                        return Convert.ToInt16(objValue);
                    case "system.long":
                        return Convert.ToUInt64(objValue);
                    default:
                        return objValue;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objValue;
        }

        public static object ParseValue(object objValue, string TypeFullName, bool ReturnMinValue)
        {
            try
            {
                switch (TypeFullName)
                {
                    case "system.string":
                        return objValue.ToString();
                    case "system.date":
                    case "system.datetime":
                        return Convert.ToDateTime(objValue);
                    case "system.boolean":
                        return Convert.ToBoolean(objValue);
                    case "system.byte":
                        return Convert.ToByte(objValue);
                    case "system.int16":
                        return Convert.ToInt16(objValue);
                    case "system.integer":
                        return Convert.ToInt32(objValue);
                    case "system.int32":
                        return Convert.ToInt32(objValue);
                    case "system.int64":
                        return Convert.ToInt64(objValue);
                    case "System.Decimal":
                        return Convert.ToDecimal(objValue);
                    case "System.Single":
                        return Convert.ToSingle(objValue);
                    case "System.Double":
                        return Convert.ToDouble(objValue);
                    case "System.SByte":
                        return Convert.ToSByte(objValue);
                    case "system.uint16":
                        return Convert.ToUInt16(objValue);
                    case "system.uint32":
                        return Convert.ToUInt32(objValue);
                    case "system.uint64":
                        return Convert.ToUInt64(objValue);
                    case "system.short":
                        return Convert.ToInt16(objValue);
                    case "system.long":
                        return Convert.ToUInt64(objValue);
                    default:
                        return objValue;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objValue;
        }

        public static DataTable CreateDataAgrs()
        {
            DataTable objDataArgs = new DataTable();

            //Các columns chuẩn
            objDataArgs.Columns.Add("Source", Type.GetType("System.String"));
            objDataArgs.Columns.Add("Status", Type.GetType("System.String"));
            objDataArgs.Columns.Add("Status_Value", Type.GetType("System.Boolean"));

            return objDataArgs;
        }

        public static string GetDateFormatString(DateTime DateValue, string FormatString)
        {
            if (DateValue == null)
            {
                return string.Empty;
            }
            if (FormatString == null || FormatString.Trim() == string.Empty)
            {
                return DateValue.ToString();
            }

            string strReturnString = null;
            string strSeparator = null;

            try
            {
                if (FormatString.ToLower() == "dd/MM/yyyy".ToLower() | FormatString.ToLower() == "dd-MM-yyyy".ToLower())
                {
                    strSeparator = FormatString.Substring(2, 1);
                    strReturnString = DateValue.Day.ToString("00") + strSeparator + DateValue.Month.ToString("00") + strSeparator + DateValue.Year.ToString("0000");
                }
                else if (FormatString.ToLower() == "dd/MMM/yyyy".ToLower() | FormatString.ToLower() == "dd-MMM-yyyy".ToLower())
                {
                    strSeparator = FormatString.Substring(2, 1);
                    strReturnString = DateValue.Day.ToString("00") + strSeparator + GetMonthNameEN(DateValue.Month) + strSeparator + DateValue.Year.ToString("0000");
                }
                else if (FormatString.ToLower() == "MM/dd/yyyy".ToLower() | FormatString.ToLower() == "MM-dd-yyyy".ToLower())
                {
                    strSeparator = FormatString.Substring(2, 1);
                    strReturnString = DateValue.Month.ToString("00") + strSeparator + DateValue.Day.ToString("00") + strSeparator + DateValue.Year.ToString("0000");
                }
                else if (FormatString.ToLower() == "MMM/dd/yyyy".ToLower() | FormatString.ToLower() == "MMM-dd-yyyy".ToLower())
                {
                    strSeparator = FormatString.Substring(3, 1);
                    strReturnString = GetMonthNameEN(DateValue.Month) + strSeparator + DateValue.Day.ToString("00") + strSeparator + DateValue.Year.ToString("0000");
                }
                else if (FormatString.ToLower() == "yyyy/MM/dd".ToLower() | FormatString.ToLower() == "yyyy-MM-dd".ToLower())
                {
                    strSeparator = FormatString.Substring(4, 1);
                    strReturnString = DateValue.Year.ToString("0000") + strSeparator + DateValue.Month.ToString("00") + strSeparator + DateValue.Day.ToString("00");
                }
                else if (FormatString.ToLower() == "yyyy/dd/MM".ToLower() | FormatString.ToLower() == "yyyy-dd-MM".ToLower())
                {
                    strSeparator = FormatString.Substring(4, 1);
                    strReturnString = DateValue.Year.ToString("0000") + strSeparator + DateValue.Day.ToString("00") + strSeparator + DateValue.Month.ToString("00");
                }
                return strReturnString;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        public static string GetMonthNameEN(Int32 MonthValue)
        {
            string strMonthName = null;

            if (MonthValue == null)
                return string.Empty;

            switch (MonthValue)
            {
                case 1:
                    strMonthName = "Jan";
                    break;

                case 2:
                    strMonthName = "Feb";
                    break;

                case 3:
                    strMonthName = "Mar";
                    break;

                case 4:
                    strMonthName = "Apr";
                    break;

                case 5:
                    strMonthName = "May";
                    break;

                case 6:
                    strMonthName = "Jun";
                    break;

                case 7:
                    strMonthName = "Jul";
                    break;

                case 8:
                    strMonthName = "Aug";
                    break;

                case 9:
                    strMonthName = "Sep";
                    break;

                case 10:
                    strMonthName = "Oct";
                    break;

                case 11:
                    strMonthName = "Nov";
                    break;

                case 12:
                    strMonthName = "Dec";
                    break;

                default:
                    strMonthName = string.Empty;
                    break;
            }
            return strMonthName;
        }

        public static string GetMonthNameEN(DateTime DateValue)
        {
            if (DateValue == null)
                return string.Empty;
            return GetMonthNameEN(DateValue.Month);
        }

        public static string DataTableToJsonObj(DataTable dt)
        {
            DataSet ds = new DataSet();
            ds.Merge(dt);
            StringBuilder JsonString = new StringBuilder();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                JsonString.Append("[");
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    JsonString.Append("{");
                    for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
                    {
                        if (j < ds.Tables[0].Columns.Count - 1)
                        {
                            JsonString.Append("\"" + ds.Tables[0].Columns[j].ColumnName.ToString() + "\":" + "\"" + ds.Tables[0].Rows[i][j].ToString() + "\",");
                        }
                        else if (j == ds.Tables[0].Columns.Count - 1)
                        {
                            JsonString.Append("\"" + ds.Tables[0].Columns[j].ColumnName.ToString() + "\":" + "\"" + ds.Tables[0].Rows[i][j].ToString() + "\"");
                        }
                    }
                    if (i == ds.Tables[0].Rows.Count - 1)
                    {
                        JsonString.Append("}");
                    }
                    else
                    {
                        JsonString.Append("},");
                    }
                }
                JsonString.Append("]");
                return JsonString.ToString();
            }
            else
            {
                return null;
            }
        }

        public static DateTime ChangeDate(string DateValue)
        {
            string[] NGAY_SPLIT = DateValue.Split('/');
            int NGAY = int.Parse(NGAY_SPLIT[0]);
            int THANG = int.Parse(NGAY_SPLIT[1]);
            int NAM = int.Parse(NGAY_SPLIT[2]);
            return new DateTime(NAM, THANG, NGAY);
        }

        #endregion
    }
}
