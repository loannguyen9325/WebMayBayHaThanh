using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Configuration;
using System.Text;
using System.Web;
using System.Web.Caching;
using System.Threading.Tasks;

namespace MayBayHaThanh.DAL
{
    public class DataAccess
    {
        protected internal const String DefaultConnectionStringItem = "ConnectionString";

        private SqlTransaction _trans;
        private IsolationLevel _isolationLevel;

        private SqlConnection _conn;

        private string _connString;
        private string _connStringFile;

        private ParamCollection _parameters;
        private CommandType _commandType;
        private string _commandText;

        //PhuongLN2: Cache connectionstring
        private static Cache cacheCMS = HttpContext.Current.Cache;

        #region "Properties"
        public SqlConnection Connection
        {
            get { return _conn; }
            set { _conn = value; }
        }

        public string ConnectionString
        {
            get { return _connString; }
            set { _connString = value; }
        }

        public string ConnectionStringFile
        {
            get { return _connStringFile; }
            set { _connStringFile = value; }
        }

        public ParamCollection Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }

        public CommandType CommandType
        {
            get { return _commandType; }
            set { _commandType = value; }
        }

        public string CommandText
        {
            get { return _commandText; }
            set { _commandText = value; }
        }

        #endregion

        #region "Constructors"
        public DataAccess()
        {
            _isolationLevel = IsolationLevel.ReadCommitted;
            _connString = string.Empty;
            _commandText = string.Empty;
            _commandType = CommandType.Text;
            _parameters = new ParamCollection();
        }
        public DataAccess(string ConnectionStringItem)
        {
            _isolationLevel = IsolationLevel.ReadCommitted;
            _connString = GetConnectionString(ConnectionStringItem);
            _commandText = string.Empty;
            _commandType = CommandType.Text;
            _parameters = new ParamCollection();
        }
        #endregion

        #region "Connectionstring"

        protected static internal string GetConnectionString(string ConnectionStringItem)
        {
            string strConnection = string.Empty;

            if (ConnectionStringItem == null || ConnectionStringItem == string.Empty)
            {
                ConnectionStringItem = DefaultConnectionStringItem;
            }

            if (strConnection == string.Empty)
            {
                if (cacheCMS[ConnectionStringItem] == null)
                {
                    //insert cache connection string
                    cacheCMS.Insert(ConnectionStringItem, ConfigurationManager.ConnectionStrings[ConnectionStringItem].ConnectionString, null, DateTime.MaxValue, TimeSpan.FromMinutes(10));
                    strConnection = (string)cacheCMS[ConnectionStringItem];
                }
                else
                {
                    strConnection = (string)cacheCMS[ConnectionStringItem];
                }
            }
            return strConnection;
        }

        protected static internal SqlConnection GetConnection(string strConnString)
        {
            SqlConnection conn = new SqlConnection();

            if (strConnString == null || strConnString == string.Empty)
            {
                strConnString = GetConnectionString(strConnString);
            }

            strConnString = strConnString.Trim();

            if (strConnString.EndsWith(";"))
            {
                strConnString = strConnString.Remove(strConnString.Length - 1, 1);
            }

            conn.ConnectionString = strConnString;
            return conn;

        }
        #endregion

        #region "Transactions"

        public void BeginTrans(IsolationLevel transisolationLevel)
        {
            _conn = GetConnection(_connString);
            _conn.Open();
            _trans = GetTransaction(_conn, transisolationLevel);
        }

        public void CommitTrans()
        {
            CommitTrans(true);
        }

        public void CommitTrans(bool CloseConnection)
        {
            if (IsInTransaction())
            {
                _trans.Commit();
            }
            DisposeTrans(CloseConnection);
        }

        public void AbortTrans()
        {
            RollbackTrans();
        }

        public void RollbackTrans()
        {
            if (IsInTransaction())
            {
                _trans.Rollback();
                DisposeTrans(true);
            }
        }

        private void DisposeTrans(bool CloseConnection)
        {
            if (CloseConnection)
            {
                if ((_conn != null))
                {
                    if (_conn.State != ConnectionState.Closed && _conn.State != ConnectionState.Broken)
                    {
                        _conn.Close();
                    }
                    _conn.Dispose();
                    _conn = null;
                }
            }
            if ((_trans != null))
            {
                _trans.Dispose();
                _trans = null;
            }
        }

        public bool IsInTransaction()
        {
            return ((_trans != null) && (_trans.Connection != null));
        }

        protected static internal SqlTransaction GetTransaction(SqlConnection conn, IsolationLevel transisolationLevel)
        {
            return conn.BeginTransaction(transisolationLevel);
        }
        #endregion

        #region "Parameters"

        protected static internal IDbDataParameter GetParameter(string paramName, ParameterDirection paramDirection, object paramValue, DbType paramtype, Int32 size)
        {

            SqlParameter param = new SqlParameter();

            param.ParameterName = paramName;
            param.DbType = paramtype;
            if (size > 0)
            {
                param.Size = size;
            }
            if ((paramValue != null))
            {
                param.Value = paramValue;
            }
            param.Direction = paramDirection;
            return param;
        }

        #endregion

        #region "Prepare for Database exec"

        public void PrepareAll(ref SqlCommand cmd, ref SqlConnection conn, string strSQL, CommandType cmdType, ParamCollection parameterArray)
        {
            if (!IsInTransaction())
            {
                conn = GetConnection(ConnectionString);
                cmd = GetCommand(strSQL, cmdType, parameterArray);
                cmd.Connection = conn;
                conn.Open();
            }
            else
            {
                cmd = GetCommand(strSQL, cmdType, parameterArray);
                cmd.Connection = _conn;
                cmd.Transaction = _trans;
            }
        }

        protected SqlCommand GetCommand(string strSQL, CommandType cmdType, ParamCollection ParameterArray)
        {

            SqlCommand cmd = new SqlCommand();
            Int32 i = default(Int32);
            Int32 j = default(Int32);


            SqlParameter[] para_SP = null;

            if (cmdType == CommandType.StoredProcedure)
            {
                para_SP = Get_SPParameterSet(strSQL);
            }

            if (para_SP != null)
            {
                //Duyệt từng tham số từ store procedure
                //Duyệt tham số từ code
                //Kiểm tra tham số giữa store và code có trùng tên không
                //Nếu có gán dữ liệu cho tham số store là dữ liệu tham số code
                //Ngược lại default nothing

                for (i = 0; i <= para_SP.Length - 2; i++)
                {
                    SqlParameter ps_SP = para_SP[i];

                    for (j = 0; j <= ParameterArray.Count - 1; j++)
                    {
                        ParamStruct ps_Code = ParameterArray[j];
                        if (ps_SP.ParameterName.ToUpper() == ps_Code.ParamName.ToUpper())
                        {
                            if (System.DBNull.Value == ps_Code.Value)
                            {
                                ps_SP.Value = null;
                            }
                            else
                            {
                                ps_SP.Value = ps_Code.Value;
                            }
                            break;
                        }
                        else
                        {
                            ps_SP.Value = null;
                        }

                    }

                    IDbDataParameter pm = GetParameter(ps_SP.ParameterName, ps_SP.Direction, ps_SP.Value, ps_SP.DbType, ps_SP.Size);
                    cmd.Parameters.Add(pm);
                }

            }
            else
            {
                if (((ParameterArray != null)) && ParameterArray.Count > 0)
                {
                    for (i = 0; i <= ParameterArray.Count - 1; i++)
                    {
                        ParamStruct ps = ParameterArray[i];
                        IDbDataParameter pm = GetParameter(ps.ParamName, ps.Direction, ps.Value, ps.DataType, ps.Size);
                        cmd.Parameters.Add(pm);
                    }
                }
            }


            cmd.CommandType = cmdType;
            cmd.CommandText = strSQL;
            return cmd;
        }

        protected SqlParameter[] Get_SPParameterSet(string strSQL)
        {
            try
            {
                SqlConnection conn = new SqlConnection();
                SqlCommand cmd = new SqlCommand();
                SqlParameter[] cachedParameters = null;

                if (!IsInTransaction())
                {
                    conn = GetConnection(ConnectionString);
                    conn.Open();
                }
                else
                {
                    conn = this._conn;
                    cmd.Transaction = this._trans;
                }
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;
                cmd.CommandText = strSQL;

                SqlCommandBuilder.DeriveParameters(cmd);

                cachedParameters = new SqlParameter[Convert.ToInt32(cmd.Parameters.Count) + 1];
                cmd.Parameters.CopyTo(cachedParameters, 0);

                return cachedParameters;


            }
            catch (Exception ex)
            {
            }

            return null;
        }

        #endregion

        #region "Exception"

        private void ODPExceptionHandler(SqlException ex, string SQLCommandText, ParamCollection Params)
        {
            //SqlInfoMessageEventArgs sqler = default(SqlInfoMessageEventArgs);
            StringBuilder sb = new StringBuilder();
            throw new Exception(ex.ToString());
        }


        private void GenericExceptionHandler(Exception ex, string SQLCommandText, ParamCollection Params)
        {
            ODPExceptionHandler((SqlException)ex, SQLCommandText, Params);

        }
        #endregion

        #region "ExecNonQuery"

        public int ExecNonQuery()
        {
            return ExecNonQuery(this.CommandText, this.CommandType, this.Parameters);
        }

        public Int32 ExecNonQuery(string strSQL, CommandType cmdType, ParamCollection parameterArray)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection();
            Int32 intRowAff = 0;
            Int32 intCounter;

            try
            {
                PrepareAll(ref cmd, ref conn, strSQL, cmdType, parameterArray);
                intRowAff = cmd.ExecuteNonQuery();

                if (intRowAff == -1)
                {
                    intRowAff = 1;
                }

                intCounter = -1;
                foreach (ParamStruct objParam in parameterArray)
                {
                    intCounter += 1;
                    if (objParam.Direction == ParameterDirection.InputOutput || objParam.Direction == ParameterDirection.Output || objParam.Direction == ParameterDirection.ReturnValue)
                    {
                        parameterArray[intCounter].Value = ((IDataParameter)cmd.Parameters[objParam.ParamName]).Value;
                    }
                }

                return intRowAff;
            }
            catch (Exception ex)
            {
                GenericExceptionHandler(ex, strSQL, parameterArray);
            }

            finally
            {
                if ((!IsInTransaction()) && (conn != null))
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                    conn.Dispose();
                }
                if (cmd != null)
                {
                    cmd.Dispose();
                }
            }
            return -1;

        }

        #endregion

        #region "ExecDataReader"

        public IDataReader ExecDataReader()
        {
            return ExecDataReader(this.CommandText, this.CommandType, this.Parameters);
        }

        public IDataReader ExecDataReader(string strSQL, CommandType cmdType, ParamCollection parameterArray)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection();

            try
            {
                PrepareAll(ref cmd, ref conn, strSQL, cmdType, parameterArray);
                return cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                if ((!IsInTransaction()) && (conn != null))
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                    conn.Dispose();
                }

                GenericExceptionHandler(ex, strSQL, parameterArray);
            }
            return null;
        }

        #endregion

        #region "ExecDataTable"

        public DataTable ExecDataTable()
        {
            return ExecDataTable(this.CommandText, this.CommandType, this.Parameters);
        }

        public DataTable ExecDataTable(string strSQL, CommandType cmdType, ParamCollection parameterArray)
        {
            DataTable tb = new DataTable();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {
                PrepareAll(ref cmd, ref conn, strSQL, cmdType, parameterArray);
                //Fill_DataSet(ref cmd, ref ds);
                da.SelectCommand = cmd;
                da.Fill(ds);

                if (ds != null && ds.Tables.Count > 0)
                {
                    return ds.Tables[0];
                }
                else
                {
                    ds = null;
                }
            }
            catch (Exception ex)
            {
                GenericExceptionHandler(ex, strSQL, parameterArray);
            }
            finally
            {
                if ((!IsInTransaction()) && (conn != null))
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                    conn.Dispose();
                }
                if (cmd != null)
                {
                    cmd.Dispose();
                }
                da.Dispose();
                if (ds != null)
                {
                    ds.Dispose();
                }
            }
            return null;
        }

        #endregion

        #region "ExecDataSet"

        public DataSet ExecDataSet()
        {
            return ExecDataSet(this.CommandText, this.CommandType, this.Parameters);
        }

        public DataSet ExecDataSet(string strSQL, CommandType cmdType, ParamCollection parameterArray)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {
                PrepareAll(ref cmd, ref conn, strSQL, cmdType, parameterArray);
                //Fill_DataSet(ref cmd, ref ds);
                da.SelectCommand = cmd;
                da.Fill(ds);
                if (ds != null && ds.Tables.Count > 0)
                {
                    return ds;
                }
            }
            catch (Exception ex)
            {
                GenericExceptionHandler(ex, strSQL, parameterArray);
            }
            finally
            {
                if ((!IsInTransaction()) && (conn != null))
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                    conn.Dispose();
                }
                if (cmd != null)
                {
                    cmd.Dispose();
                }
                da.Dispose();
            }
            return null;
        }
        public void Fill_DataSet(ref SqlCommand cmd, ref DataSet ds)
        {

            try
            {
                DataTable dTable_Schema = new DataTable();
                SqlDataReader rd;
                rd = cmd.ExecuteReader();
                dTable_Schema = rd.GetSchemaTable();

                DataTable dTable_Temp = new DataTable();
                dTable_Temp = dTable_Schema;

                bool flag = true;

                while (rd.Read())
                {
                    DataRow row = dTable_Temp.NewRow();
                    for (Int32 i = 0; i <= dTable_Temp.Columns.Count - 1; i++)
                    {
                        //row(i) = rd.GetValue(i)
                        for (Int32 j = 0; j <= rd.FieldCount - 1; j++)
                        {
                            if (dTable_Temp.Columns[i].ColumnName == rd.GetName(j))
                            {
                                flag = true;
                                for (Int32 k = 0; k <= j - 1; k++)
                                {
                                    if (rd.GetName(k) == rd.GetName(j))
                                    {
                                        flag = false;
                                    }
                                }
                                if (flag == true)
                                {
                                    row[i] = rd.GetValue(j);
                                }
                            }
                        }
                    }
                    dTable_Temp.Rows.Add(row);
                }

                if ((dTable_Temp != null))
                {
                    dTable_Temp.AcceptChanges();
                    ds.Tables.Clear();
                    ds.Tables.Add(dTable_Temp);
                }
                else
                {
                    ds = null;
                }


            }
            catch (Exception ex)
            {
            }
        }
        #endregion

        #region "ExecuteScalar"
        public object ExecuteScalar()
        {
            return this.ExecuteScalar(this.CommandText, this.CommandType);
        }

        public object ExecuteScalar(string commandText)
        {
            return this.ExecuteScalar(commandText, this.CommandType);
        }

        public object ExecuteScalar(string commandText, CommandType commandType)
        {
            object obj2 = null;
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {
                //this.PrepareCommand(this.Command, this.Connection, this.Transaction, this.CommandText, this.CommandType, this.Parameters);
                PrepareAll(ref cmd, ref conn, commandText, commandType, this.Parameters);
                obj2 = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                if (obj2 != null)
                {
                    return obj2;
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                if ((!IsInTransaction()) && (conn != null))
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                    conn.Dispose();
                }
                if (cmd != null)
                {
                    cmd.Dispose();
                }
            }
            return obj2;
        }


        #endregion

        #region "Command builder"
        #endregion
    }
}
