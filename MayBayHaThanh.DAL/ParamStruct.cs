using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace MayBayHaThanh.DAL
{
    public class ParamStruct
    {
        private string mvarParamName = string.Empty;
        private DbType mvarDataType = DbType.String;
        private SqlDbType mvarSqlDataType = SqlDbType.Text;
        private object mvarValue = null;
        private ParameterDirection mvarDirection = ParameterDirection.Input;
        private Int32 mvarSize = -1;

        #region "Properties"

        public string ParamName
        {
            get { return mvarParamName; }
            set { mvarParamName = value; }
        }

        public DbType DataType
        {
            get { return mvarDataType; }
            set { mvarDataType = value; }
        }

        public SqlDbType SqlDataType
        {
            get { return mvarSqlDataType; }
            set { mvarSqlDataType = value; }
        }

        public object Value
        {
            get { return mvarValue; }
            set { mvarValue = value; }
        }

        public ParameterDirection Direction
        {
            get { return mvarDirection; }
            set { mvarDirection = value; }
        }

        public Int32 Size
        {
            get { return mvarSize; }
            set { mvarSize = value; }
        }

        #endregion

        #region "Constructors"

        public ParamStruct(string mParamName, DbType mDataType, object mValue, ParameterDirection mDirection, Int32 mSize)
        {
            mvarParamName = mParamName;
            mvarDataType = mDataType;
            mvarValue = RuntimeHelpers.GetObjectValue(mValue);
            mvarDirection = mDirection;
            mvarSize = mSize;
        }
        public ParamStruct(string mParamName, SqlDbType mSqlDataType, object mValue, ParameterDirection mDirection, Int32 mSize)
        {
            mvarParamName = mParamName;
            mvarSqlDataType = mSqlDataType;
            mvarValue = RuntimeHelpers.GetObjectValue(mValue);
            mvarDirection = mDirection;
            mvarSize = mSize;
        }
        #endregion
    }
}
