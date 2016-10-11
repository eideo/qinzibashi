using System.Data;
using System.Data.SqlClient;

namespace Helper
{
    public abstract class DBOperation
    {
        private SqlTransaction _tran = null;

        public SqlTransaction Transaction
        {
            get
            {
                return _tran;
            }
            set
            {
                _tran = value;
            }
        }

        public DataSet ExecuteDataset(string commandText, params SqlParameter[] commandParameters)
        {
            return ExecuteDataset(commandText, CommandType.Text, commandParameters);
        }

        public DataSet ExecuteDataset(string commandText, CommandType commandType, params SqlParameter[] commandParameters)
        {
            if (_tran != null)
            {
                return SqlHelper.ExecuteDataset(_tran, commandType, commandText, commandParameters);
            }
            else
            {
                return SqlHelper.ExecuteDataset(Database.ConnectionString, commandType, commandText, commandParameters);
            }
        }

        public int ExecuteNonQuery(string commandText, params SqlParameter[] commandParameters)
        {
            return ExecuteNonQuery(commandText, CommandType.Text, commandParameters);
        }

        public int ExecuteNonQuery(string commandText, CommandType commandType, params SqlParameter[] commandParameters)
        {
            if (_tran != null)
            {
                return SqlHelper.ExecuteNonQuery(_tran, commandType, commandText, commandParameters);
            }
            else
            {
                return SqlHelper.ExecuteNonQuery(Database.ConnectionString, commandType, commandText, commandParameters);
            }
        }

        public bool Exists(string commandText, params SqlParameter[] commandParameters)
        {
            return Exists(commandText, CommandType.Text, commandParameters);
        }

        public bool Exists(string commandText, CommandType commandType, params SqlParameter[] commandParameters)
        {
            object obj = ExecuteScalar(commandText, commandType, commandParameters);

            if (null != obj)
            {
                return (int)obj > 0;
            }
            else
            {
                return false;
            }
        }

        public object ExecuteScalar(string commandText, params SqlParameter[] commandParameters)
        {
            return ExecuteScalar(commandText, CommandType.Text, commandParameters);
        }

        public object ExecuteScalar(string commandText, CommandType commandType, params SqlParameter[] commandParameters)
        {
            if (_tran != null)
            {
                return SqlHelper.ExecuteScalar(_tran, commandType, commandText, commandParameters);
            }
            else
            {
                return SqlHelper.ExecuteScalar(Database.ConnectionString, commandType, commandText, commandParameters);

            }
        }


        public SqlDataReader ExecuteReader(string commandText, params SqlParameter[] commandParameters)
        {
            return ExecuteReader(commandText, CommandType.Text, commandParameters);
        }


        public SqlDataReader ExecuteReader(string commandText, CommandType commandType, params SqlParameter[] commandParameters)
        {
            if (_tran != null)
            {
                return SqlHelper.ExecuteReader(_tran, commandType, commandText, commandParameters);
            }
            else
            {
                return SqlHelper.ExecuteReader(Database.ConnectionString, commandType, commandText, commandParameters);
            }
        }
    }
}
