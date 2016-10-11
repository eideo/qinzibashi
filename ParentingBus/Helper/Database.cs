using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Helper
{
    public class Database
    {
        public Database()
        {
            _connection = new SqlConnection(ConnectionString);
        }

        public Database(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
        }

        //public static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public static readonly string ConnectionString = @"Data Source=121.41.60.226;Initial Catalog=pbs;User ID=sa;password=!@#123456abc";

        private readonly SqlConnection _connection;
        private SqlTransaction _transaction;

        public SqlConnection Connection
        {
            get { return _connection; }
        }

        public SqlTransaction Transaction
        {
            get { return _transaction; }
            set { _transaction = value; }
        }

        public void OpenConnection()
        {
            try
            {
                if (Connection.State != ConnectionState.Open)
                    Connection.Open();
            }
            catch { throw; }
        }

        public void CloseConnection()
        {
            if (Connection.State != ConnectionState.Closed)
            {
                try { Connection.Close(); }
                catch { throw; }
            }
        }

        public void BeginTrans()
        {
            try
            {
                OpenConnection();
                Transaction = Connection.BeginTransaction();
            }
            catch { throw; }
        }

        public void CommitTrans()
        {
            try
            {
                if (Transaction != null)
                {
                    Transaction.Commit();
                    Transaction.Dispose();
                    Transaction = null;
                }
            }
            catch { throw; }
            finally { CloseConnection(); }
        }

        public void RollbackTrans()
        {
            try
            {
                if (Transaction != null)
                {
                    Transaction.Rollback();
                    Transaction.Dispose();
                    Transaction = null;
                }
            }
            catch { throw; }
        }
    }
}
